using Domain.Core;
using Domain.CampsModels.DBModels;
using Domain.CampsModels.ReqDTO;
using Domain.CampsModels.RespDTO;
using Microsoft.AspNetCore.Components;
using Shared.CampsClient.Master;
using Radzen;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MSEBDGCP.Components.Pages.Camps
{
    public partial class BloodGroupUpdate
    {
        [Inject]
        protected NotificationService? NotificationService { get; set; }
        [Inject]
        protected DialogService DialogService { get; set; }
        [Inject]
        protected BeneficiaryService _BeneficiaryService { get; set; }
        [Inject] protected BloodGroupService? BloodGroupService { get; set; }

        public Beneficiary _Beneficiary { get; set; } = new();
        private string MobileNumber { get; set; } = "";
        private int? BloodGroupId { get; set; }
        private List<BloodGroup> bloodGroupList { get; set; } = new();
        private BeneficiaryInfoRespDTO _BeneficiaryInfoRespDTO { get; set; } = new();
        protected override async Task OnInitializedAsync()
        {
            await GetBloodGroupList();
        }
        private async Task GetBeneficiaryInfo()
        {
            _BeneficiaryInfoRespDTO = new();
            _BeneficiaryInfoRespDTO = await _BeneficiaryService.GetBeneficiaryByMobile(MobileNumber);
            if (_BeneficiaryInfoRespDTO != null)
            {
                if (_BeneficiaryInfoRespDTO.RESPONSE_CODE.Equals(ConfigClass.SUCCESS))
                {
                    _Beneficiary = _BeneficiaryInfoRespDTO.Beneficiary;
                }
                else
                {
                    NotificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Error, 
                        Summary = "Error", Detail = "No data found" });
                }
            }
            else
            {
                NotificationService.Notify(new NotificationMessage
                {
                    Severity = NotificationSeverity.Error,
                    Summary = "Error",
                    Detail = "No data found"
                });
            }
        }

        private async Task GetBloodGroupList()
        {
            try
            {
                BloodGroupListRespDTO resp = await BloodGroupService.GetBloodGroupList();
                if (resp != null)
                {
                    if (resp.BloodGroupList != null)
                    {
                        bloodGroupList = resp.BloodGroupList;
                    }
                }
            }
            catch (Exception ex)
            {
                bloodGroupList = null;
            }
        }

        private async Task ClearForm()
        {
            MobileNumber = "";
            _Beneficiary = new();
        }
        private async Task CloseForm()
        {
            MobileNumber = "";
            _Beneficiary = new();
            DialogService.Close();
        }

        private async Task UpdateBloodGroup()
        {
            bool? confirmed = await DialogService.Confirm(
                 "Are you sure to update benificiery blood group?",
                 "Confirm update",
                 new ConfirmOptions() { OkButtonText = "Yes", CancelButtonText = "No" }
            );
            if (confirmed == true)
            {
                var result = await _BeneficiaryService.UpdateBloodGroupByMobile(_Beneficiary.BloodGroup, MobileNumber);
                if (result != null)
                {
                    if (result.RESPONSE_CODE != null)
                    {
                        if (result.RESPONSE_CODE.Equals(ConfigClass.SUCCESS))
                        {
                            _Beneficiary = new();
                            BloodGroupId = new();
                            NotificationService.Notify(NotificationSeverity.Success, "Saved", "Blood group updated");
                        }
                        else
                        {
                            NotificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = "Blood group not updated" });
                        }
                    }
                    else
                    {
                        NotificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = "Blood group not updated" });
                    }
                }
                else
                {
                    NotificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = "Blood group not updated" });
                }
            }
        }
    }
}
