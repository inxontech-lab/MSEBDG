using Domain.Core;
using Domain.CampsModels.RespDTO;
using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;
using Shared.CampsClient.Master;

namespace MSEBDGCP.Components.Pages.Camps
{
    public partial class CampaignVolunteers
    {
        [Inject] protected CampaignVolunteerService CampaignVolunteerService { get; set; } = default!;
        [Inject] protected DialogService DialogService { get; set; } = default!;
        [Inject] protected NotificationService NotificationService { get; set; } = default!;

        protected RadzenDataGrid<CampaignVolunteerDto>? volunteerGrid;
        protected List<CampaignVolunteerDto> volunteers = new();

        protected override async Task OnInitializedAsync()
        {
            await LoadVolunteersAsync();
        }

        protected async Task LoadVolunteersAsync()
        {
            try
            {
                var response = await CampaignVolunteerService.GetCampaignVolunteerListAsync();
                volunteers = response?.RESPONSE_CODE == ConfigClass.SUCCESS && response.VolunteerList != null
                    ? response.VolunteerList
                    : new List<CampaignVolunteerDto>();
            }
            catch
            {
                volunteers = new List<CampaignVolunteerDto>();
                NotificationService.Notify(NotificationSeverity.Error, "Load failed", "Unable to load volunteers.");
            }
        }

        protected string GetPhoto(string? photoLocation)
        {
            return string.IsNullOrWhiteSpace(photoLocation) ? "images/app_logo.jpeg" : photoLocation;
        }

        protected async Task OpenCreateDialog()
        {
            var result = await DialogService.OpenAsync<VolunteerEditor>("Create Volunteer", null, new DialogOptions
            {
                Width = "1100px",
                Resizable = true,
                Draggable = true,
                CloseDialogOnOverlayClick = false
            });

            if (result is bool saved && saved)
            {
                await LoadVolunteersAsync();
                await volunteerGrid!.RefreshDataAsync();
            }
        }

        protected async Task OpenEditDialog(int volunteerId)
        {
            var parameters = new Dictionary<string, object>
            {
                [nameof(VolunteerEditor.VolunteerId)] = volunteerId
            };

            var result = await DialogService.OpenAsync<VolunteerEditor>("Edit Volunteer", parameters, new DialogOptions
            {
                Width = "1100px",
                Resizable = true,
                Draggable = true,
                CloseDialogOnOverlayClick = false
            });

            if (result is bool saved && saved)
            {
                await LoadVolunteersAsync();
                await volunteerGrid!.RefreshDataAsync();
            }
        }

        protected async Task ViewQrCode(CampaignVolunteerDto volunteer)
        {
            var parameters = new Dictionary<string, object>
            {
                [nameof(VolunteerQrDialog.VolunteerId)] = volunteer.VolunteerId,
                [nameof(VolunteerQrDialog.VolunteerName)] = volunteer.FullNameEn,
                [nameof(VolunteerQrDialog.WhatsAppNumber)] = volunteer.WhatsAppNumber,
                [nameof(VolunteerQrDialog.Email)] = volunteer.Email
            };

            await DialogService.OpenAsync<VolunteerQrDialog>("Volunteer QR Code", parameters, new DialogOptions
            {
                Width = "520px",
                Resizable = true,
                Draggable = true,
                CloseDialogOnOverlayClick = true
            });
        }

        protected async Task DeleteVolunteer(int volunteerId, string volunteerName)
        {
            bool? confirmed = await DialogService.Confirm(
                $"Are you sure you want to delete {volunteerName}?",
                "Confirm delete",
                new ConfirmOptions { OkButtonText = "Yes", CancelButtonText = "No" });

            if (confirmed != true)
            {
                return;
            }

            try
            {
                var response = await CampaignVolunteerService.DeleteCampaignVolunteerAsync(volunteerId);
                if (response?.RESPONSE_CODE == ConfigClass.SUCCESS)
                {
                    volunteers = response.VolunteerList ?? new List<CampaignVolunteerDto>();
                    NotificationService.Notify(NotificationSeverity.Success, "Deleted", "Volunteer deleted successfully.");
                    await volunteerGrid!.RefreshDataAsync();
                }
                else
                {
                    NotificationService.Notify(NotificationSeverity.Error, "Delete failed", response?.RESPONSE_DESCRPTION ?? "Unable to delete volunteer.");
                }
            }
            catch
            {
                NotificationService.Notify(NotificationSeverity.Error, "Delete failed", "Unable to delete volunteer.");
            }
        }
    }
}
