namespace GRS.Model;

public class JwtSettings
{
    public static readonly string JwtSectionName = "Jwt";
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public int Validity { get; set; }
    public string Key { get; set; } = string.Empty;
}