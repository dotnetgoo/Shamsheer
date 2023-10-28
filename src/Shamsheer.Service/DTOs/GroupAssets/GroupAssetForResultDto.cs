namespace Shamsheer.Service.DTOs.GroupAssets;

public class GroupAssetForResultDto
{
    public long Id { get; set; }
    public long GroupId { get; set; }
    public string Name { get; set; }
    public string Path { get; set; }
    public string Extension { get; set; }
    public long Size { get; set; }
    public string Type { get; set; }
}