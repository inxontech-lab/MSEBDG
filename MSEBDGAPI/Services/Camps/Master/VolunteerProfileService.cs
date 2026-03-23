using Domain.CampsModels.RespDTO;
using Domain.Core;
using Microsoft.AspNetCore.StaticFiles;

namespace MSEBDGAPI.Services.Camps.Master;

public class VolunteerProfileService
{
    private readonly CampaignVolunteerService _campaignVolunteerService;
    private readonly IHostEnvironment _hostEnvironment;
    private readonly IConfiguration _configuration;

    public VolunteerProfileService(
        CampaignVolunteerService campaignVolunteerService,
        IHostEnvironment hostEnvironment,
        IConfiguration configuration)
    {
        _campaignVolunteerService = campaignVolunteerService;
        _hostEnvironment = hostEnvironment;
        _configuration = configuration;
    }

    public async Task<CampaignVolunteerProfileRespDTO> GetVolunteerProfileAsync(int volunteerId)
    {
        var response = new CampaignVolunteerProfileRespDTO();

        try
        {
            var volunteerListResponse = await _campaignVolunteerService.GetCampaignVolunteerListAsync(false);
            var volunteer = volunteerListResponse.VolunteerList?.FirstOrDefault(x => x.VolunteerId == volunteerId);

            if (volunteerListResponse.RESPONSE_CODE != ConfigClass.SUCCESS || volunteer == null)
            {
                response.RESPONSE_CODE = volunteerListResponse.RESPONSE_CODE == ConfigClass.SUCCESS
                    ? ConfigClass.DATA_NOT_FOUND
                    : volunteerListResponse.RESPONSE_CODE;
                response.RESPONSE_DESCRPTION = volunteerListResponse.RESPONSE_CODE == ConfigClass.SUCCESS
                    ? ConfigClass.DATA_NOT_FOUND_MESSAGE
                    : volunteerListResponse.RESPONSE_DESCRPTION;
                return response;
            }

            var (photoBase64, photoMimeType) = await GetVolunteerPhotoAsync(volunteer.VolunteerId, volunteer.PhotoLocation);

            response.RESPONSE_CODE = ConfigClass.SUCCESS;
            response.RESPONSE_DESCRPTION = ConfigClass.SUCCESS_MESSAGE;
            response.Volunteer = new CampaignVolunteerProfileDto
            {
                VolunteerId = volunteer.VolunteerId,
                FullNameEn = volunteer.FullNameEn,
                FullNameBn = volunteer.FullNameBn,
                FatherNameEn = volunteer.FatherNameEn,
                FatherNameBn = volunteer.FatherNameBn,
                MotherNameEn = volunteer.MotherNameEn,
                MotherNameBn = volunteer.MotherNameBn,
                GenderName = volunteer.GenderName,
                BloodGroupName = volunteer.BloodGroupName,
                DivisionName = volunteer.DivisionName,
                ZillaName = volunteer.ZillaName,
                ThanaName = volunteer.ThanaName,
                VillageName = volunteer.VillageName,
                PostOfficeName = volunteer.PostOfficeName,
                PhoneNumber = volunteer.PhoneNumber,
                WhatsAppNumber = volunteer.WhatsAppNumber,
                Email = volunteer.Email,
                DateOfBirth = volunteer.DateOfBirth,
                UnitCommitteeName = volunteer.UnitCommitteeName,
                BloodDonationsCount = volunteer.BloodDonationsCount,
                GroupingCampParticipationCount = volunteer.GroupingCampParticipationCount,
                Active = volunteer.Active,
                CreatedDate = volunteer.CreatedDate,
                UpdatedDate = volunteer.UpdatedDate,
                PhotoLocation = volunteer.PhotoLocation,
                PhotoBase64 = photoBase64,
                PhotoMimeType = photoMimeType
            };
        }
        catch (Exception ex)
        {
            response.RESPONSE_CODE = ConfigClass.FAILURE;
            response.RESPONSE_DESCRPTION = $"{ConfigClass.FAILURE_MESSAGE} - {ex.Message}";
        }

        return response;
    }

    private async Task<(string? PhotoBase64, string? PhotoMimeType)> GetVolunteerPhotoAsync(int volunteerId, string? photoLocation)
    {
        var photoPath = ResolvePhotoPath(volunteerId, photoLocation);
        if (string.IsNullOrWhiteSpace(photoPath) || !File.Exists(photoPath))
        {
            return (null, null);
        }

        var bytes = await File.ReadAllBytesAsync(photoPath);
        var provider = new FileExtensionContentTypeProvider();
        var mimeType = provider.TryGetContentType(photoPath, out var detectedMimeType)
            ? detectedMimeType
            : "image/jpeg";

        return (Convert.ToBase64String(bytes), mimeType);
    }

    private string? ResolvePhotoPath(int volunteerId, string? photoLocation)
    {
        var controlPanelWebRoot = Path.GetFullPath(Path.Combine(_hostEnvironment.ContentRootPath, "..", "MSEBDGCP", "wwwroot"));
        var imageRootPath = Path.GetFullPath(_configuration["VolunteerImageStorage:RootPath"]
            ?? Path.Combine(controlPanelWebRoot, "images", "volunteers"));

        if (!string.IsNullOrWhiteSpace(photoLocation))
        {
            var relativePath = photoLocation.TrimStart('/').Replace('/', Path.DirectorySeparatorChar);
            var directPath = Path.Combine(controlPanelWebRoot, relativePath);
            if (File.Exists(directPath))
            {
                return directPath;
            }

            var fileName = Path.GetFileName(relativePath);
            var filePathFromRoot = Path.Combine(imageRootPath, fileName);
            if (File.Exists(filePathFromRoot))
            {
                return filePathFromRoot;
            }
        }

        if (!Directory.Exists(imageRootPath))
        {
            return null;
        }

        return Directory.GetFiles(imageRootPath, $"{volunteerId}.*")
            .OrderBy(path => path)
            .FirstOrDefault();
    }
}
