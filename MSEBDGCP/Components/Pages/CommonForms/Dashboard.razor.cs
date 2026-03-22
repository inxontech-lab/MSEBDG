using Domain.Core;
using Domain.CampsModels.DBModels;
using Domain.CampsModels.DTOs;
using Domain.CampsModels.ReqDTO;
using Domain.CampsModels.RespDTO;
using Microsoft.AspNetCore.Components;
using Shared.CampsClient.CommonForms;
using Shared.CampsClient.Master;
using Shared.CampsClient.Transactions;
using Radzen;
using Shared;

namespace MSEBDGCP.Components.Pages.CommonForms
{
    public partial class Dashboard
    {
        [Inject] NotificationService NotificationService { get; set; }
        [Inject] protected DashboardService _DashboardService { get; set; }
        [Inject] protected CampDetailsService? _CampDetailsService { get; set; }
        private CampDetailsReqDTO _CampDetailsReqDTO { get; set; } = new();
        public List<CampDetailsDTO>? _CampDetailsList { get; set; } = new();
        public List<UnitCommitteeList>? _UnitCommitteList { get; set; } = new();
        private GroupingDashboardReqDTO Request { get; set; } = new();

        int selectedCampId, selectedUnitCommitteeId;
        bool showDataLabels = true;
        // data
        DashboardResultGrouping summary = new();
        //List<UnitCommitteeItem> unitCommitteeList = new();
        List<RadzenChartPoint> trendSeries = new(); // small helper class below
        private BanglaDate BanglaDate = new();

        protected override async Task OnInitializedAsync()
        {
            //await LoadDashboardAsync();
            GetCampDetails();
        }

        async Task OnFilterClicked()
        {
            await LoadDashboardAsync();
        }

        void OnSeriesClick(SeriesClickEventArgs args)
        {

        }

        private void GetCampDetails()
        {
            _CampDetailsReqDTO = new();
            try
            {
                var result = _CampDetailsService?.GetCampDetailsList(_CampDetailsReqDTO).Result;

                if (result?.RESPONSE_CODE == (ConfigClass.SUCCESS))
                {
                    _CampDetailsList = result.CampDetailsList;
                    _CampDetailsList = _CampDetailsList
                        .Select(x => {
                            x.CampNameBn = $"{x.CampNameBn} ({BanglaDate.ToBanglaDate(x.CampDate):dd-MMM-yyyy}) ";
                            return x;
                        })
                        .ToList();
                    //if (_CampDetailsList != null)
                    //{
                    //    _UnitCommitteList = _CampDetailsList
                    //                        .Where(x => x.UnitCommitteeId != null)
                    //                        .GroupBy(x => new { x.UnitCommitteeId, x.UnitCommitteeNameEn, x.UnitCommitteeNameBn }).Select(g => new UnitCommitteeList
                    //                        {
                    //                            UnitCommitteeId = g.Key.UnitCommitteeId,
                    //                            UnitCommitteeNameEn = g.Key.UnitCommitteeNameEn,
                    //                            UnitCommitteeNameBn = g.Key.UnitCommitteeNameBn
                    //                        })
                    //                        .ToList();
                    //}
                }
            }
            catch (Exception ex)
            {
                _CampDetailsList = null;
            }
        }

        async Task LoadDashboardAsync()
        {
            //Request.campId = selectedCampId;
            //Request.unitCommitteeId = selectedUnitCommitteeId;

            //Request.startDate = startDate;
            //Request.endDate = endDate;

            if ( (Request.campId == null) && (Request.startDate == null || Request.endDate == null) )
            {
                NotificationService.Notify(NotificationSeverity.Warning, "Warning", "Please select camp name or date range to view the information");
            }
            else
            {
                var res = await _DashboardService.GetDasboardForGrouping(Request);
                if (res == null) return;
                summary = res ?? new DashboardResultGrouping(); // avoid null

                //campList = res?.Camps ?? new List<CampItem>();
                //unitCommitteeList = res?.UnitCommittees ?? new List<UnitCommitteeItem>();

                if (summary.BloodGroups == null)
                {
                    summary.BloodGroups = new List<BloodGroupSummary>();
                }

                trendSeries = res?.Trend
                    .Select(t => new RadzenChartPoint { Category = t.YearMonth ?? "", Value = t.BeneficiaryCount })
                    .ToList() ?? new List<RadzenChartPoint>();
            }
        }

        // small helper class used only in UI to bind line chart
        public class RadzenChartPoint
        {
            public string Category { get; set; } = "";
            public int Value { get; set; }
        }

        public class UnitCommitteeList
        {
            public int? UnitCommitteeId { get; set; }
            public string? UnitCommitteeNameEn { get; set; }
            public string? UnitCommitteeNameBn { get; set; }
        }
    }
}
