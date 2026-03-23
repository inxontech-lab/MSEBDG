using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Shared.VolunteerLinks;

public static class VolunteerPublicLinkEncoder
{
    private const string TokenPurpose = "msebdg-volunteer-public-link";
    private const string SecretConfigKey = "PublicUrls:VolunteerDetailsTokenSecret";
    private const string DefaultSecret = "MSEBDG-Volunteer-Link-Secret-2026";

    public static string EncodeVolunteerId(int volunteerId, IConfiguration configuration)
    {
        var plainText = $"{TokenPurpose}:{volunteerId}";
        var key = BuildKey(configuration);

        using var aes = Aes.Create();
        aes.Key = key;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;
        aes.GenerateIV();

        using var encryptor = aes.CreateEncryptor();
        var plainBytes = Encoding.UTF8.GetBytes(plainText);
        var cipherBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);

        var payload = new byte[aes.IV.Length + cipherBytes.Length];
        Buffer.BlockCopy(aes.IV, 0, payload, 0, aes.IV.Length);
        Buffer.BlockCopy(cipherBytes, 0, payload, aes.IV.Length, cipherBytes.Length);

        return ToBase64Url(payload);
    }

    public static bool TryDecodeVolunteerId(string? token, IConfiguration configuration, out int volunteerId)
    {
        volunteerId = 0;
        if (string.IsNullOrWhiteSpace(token))
        {
            return false;
        }

        if (int.TryParse(token, out volunteerId))
        {
            return true;
        }

        try
        {
            var payload = FromBase64Url(token);
            var key = BuildKey(configuration);

            using var aes = Aes.Create();
            aes.Key = key;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            var ivLength = aes.BlockSize / 8;
            if (payload.Length <= ivLength)
            {
                return false;
            }

            var iv = payload[..ivLength];
            var cipherBytes = payload[ivLength..];
            aes.IV = iv;

            using var decryptor = aes.CreateDecryptor();
            var plainBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
            var plainText = Encoding.UTF8.GetString(plainBytes);

            if (!plainText.StartsWith($"{TokenPurpose}:", StringComparison.Ordinal))
            {
                return false;
            }

            return int.TryParse(plainText[(TokenPurpose.Length + 1)..], out volunteerId);
        }
        catch
        {
            return false;
        }
    }

    public static string BuildVolunteerDetailsPath(int volunteerId, IConfiguration configuration)
        => $"/volunteers/{EncodeVolunteerId(volunteerId, configuration)}";

    private static byte[] BuildKey(IConfiguration configuration)
    {
        var secret = configuration[SecretConfigKey];
        if (string.IsNullOrWhiteSpace(secret))
        {
            secret = DefaultSecret;
        }

        return SHA256.HashData(Encoding.UTF8.GetBytes(secret));
    }

    private static string ToBase64Url(byte[] bytes)
        => Convert.ToBase64String(bytes).TrimEnd('=').Replace('+', '-').Replace('/', '_');

    private static byte[] FromBase64Url(string value)
    {
        var normalized = value.Replace('-', '+').Replace('_', '/');
        var padding = normalized.Length % 4;
        if (padding > 0)
        {
            normalized = normalized.PadRight(normalized.Length + (4 - padding), '=');
        }

        return Convert.FromBase64String(normalized);
    }
}
