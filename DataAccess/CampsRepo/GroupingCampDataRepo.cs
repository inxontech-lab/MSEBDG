using Domain.CampsModels.DBModels;
using Domain.CampsModels.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CampsRepo
{
    public class GroupingCampDataRepo : IGroupingCampDataRepo
    {
        private MsebdgcampsContext _MsebdgcampsContext;

        public GroupingCampDataRepo(MsebdgcampsContext MsebdgcampsContext)
        {
            _MsebdgcampsContext = MsebdgcampsContext;
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public async Task<DashboardResultGrouping> GetDashboardSummaryAsync(int? campId, int? unitCommitteeId, DateTime? startDate, DateTime? endDate)
        {
            var result = new DashboardResultGrouping();
            using var conn = _MsebdgcampsContext.Database.GetDbConnection();
            await conn.OpenAsync();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "GroupCamp.sp_GetDashboardSummary";
            cmd.CommandType = CommandType.StoredProcedure;

            var p1 = cmd.CreateParameter(); p1.ParameterName = "@CampId"; p1.Value = (object?)campId ?? DBNull.Value; cmd.Parameters.Add(p1);
            var p2 = cmd.CreateParameter(); p2.ParameterName = "@UnitCommitteeId"; p2.Value = (object?)unitCommitteeId ?? DBNull.Value; cmd.Parameters.Add(p2);
            var p3 = cmd.CreateParameter(); p3.ParameterName = "@StartDate"; p3.Value = (object?)startDate ?? DBNull.Value; cmd.Parameters.Add(p3);
            var p4 = cmd.CreateParameter(); p4.ParameterName = "@EndDate"; p4.Value = (object?)endDate ?? DBNull.Value; cmd.Parameters.Add(p4);

            using var reader = await cmd.ExecuteReaderAsync();

            // 1) Summary
            if (await reader.ReadAsync())
            {
                result.Total = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                result.Male = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                result.Female = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                result.Other = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
            }

            // 2) Blood groups
            if (await reader.NextResultAsync())
            {
                while (await reader.ReadAsync())
                {
                    result.BloodGroups.Add(new BloodGroupSummary
                    {
                        BloodGroup = reader.IsDBNull(0) ? "Unknown" : reader.GetString(0),
                        Total = reader.IsDBNull(1) ? 0 : reader.GetInt32(1)
                    });
                }
            }

            // 3) Camps list
            //if (await reader.NextResultAsync())
            //{
            //    while (await reader.ReadAsync())
            //    {
            //        result.Camps.Add(new CampItem
            //        {
            //            CampId = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
            //            CampNameEn = reader.IsDBNull(1) ? "" : reader.GetString(1),
            //            CampNameBn = reader.IsDBNull(2) ? "" : reader.GetString(2),
            //            CampDate = reader.IsDBNull(3) ? null : (DateTime?)reader.GetDateTime(2)
            //        });
            //    }
            //}

            //// 4) Unit committees list
            //if (await reader.NextResultAsync())
            //{
            //    while (await reader.ReadAsync())
            //    {
            //        result.UnitCommittees.Add(new UnitCommitteeItem
            //        {
            //            UnitCommitteeId = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
            //            UnitCommitteeNameEn = reader.IsDBNull(1) ? "" : reader.GetString(1),
            //            UnitCommitteeNameBn = reader.IsDBNull(2) ? "" : reader.GetString(2)
            //        });
            //    }
            //}

            // 5) Trend
            if (await reader.NextResultAsync())
            {
                while (await reader.ReadAsync())
                {
                    result.Trend.Add(new TrendPoint
                    {
                        YearMonth = reader.IsDBNull(0) ? "" : reader.GetString(0),
                        BeneficiaryCount = reader.IsDBNull(1) ? 0 : reader.GetInt32(1)
                    });
                }
            }

            return result;
        }
    }
}
