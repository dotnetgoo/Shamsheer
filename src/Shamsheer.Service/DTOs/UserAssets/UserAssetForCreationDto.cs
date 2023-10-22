namespace Shamsheer.Service.DTOs.UserAssets;

public class UserAssetForCreationDto
{
    public string Name { get; set; }
    public string Path { get; set; }
    public string Extension { get; set; }
    public long Size { get; set; }
    public string Type { get; set; }
}