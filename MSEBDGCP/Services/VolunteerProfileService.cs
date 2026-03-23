using Domain.CampsModels.RespDTO;
using Domain.Core;
using Microsoft.AspNetCore.StaticFiles;
using Shared.CampsClient.Master;

namespace MSEBDGCP.Services;

public class VolunteerProfileService
{
    private readonly CampaignVolunteerService _campaignVolunteerService;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IConfiguration _configuration;

    public VolunteerProfileService(
        CampaignVolunteerService campaignVolunteerService,
        IWebHostEnvironment webHostEnvironment,
        IConfiguration configuration)
    {
        _campaignVolunteerService = campaignVolunteerService;
        _webHostEnvironment = webHostEnvironment;
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
                ThanaName = volunteer.ThanaName,
                ZillaName = volunteer.ZillaName,
                DivisionName = volunteer.DivisionName,
                Email = volunteer.Email,
                UnitCommitteeName = volunteer.UnitCommitteeName,
                BloodDonationsCount = volunteer.BloodDonationsCount,
                GroupingCampParticipationCount = volunteer.GroupingCampParticipationCount,
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
        if (!string.IsNullOrWhiteSpace(photoLocation))
        {
            var relativePath = photoLocation.TrimStart('/').Replace('/', Path.DirectorySeparatorChar);
            var directPath = Path.Combine(_webHostEnvironment.WebRootPath, relativePath);
            if (File.Exists(directPath))
            {
                return directPath;
            }
        }

        var relativeFolder = (_configuration["VolunteerImageStorage:RelativePath"] ?? "images/volunteers")
            .Trim('/')
            .Replace('/', Path.DirectorySeparatorChar);
        var physicalFolder = Path.Combine(_webHostEnvironment.WebRootPath, relativeFolder);

        if (!Directory.Exists(physicalFolder))
        {
            return null;
        }

        return Directory.GetFiles(physicalFolder, $"{volunteerId}.*")
            .OrderBy(path => path)
            .FirstOrDefault();
    }
}
