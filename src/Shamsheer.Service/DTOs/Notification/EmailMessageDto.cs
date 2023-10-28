namespace Shamsheer.Service.DTOs.Notification;

public class EmailMessageDto
{
    public string Recipent { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}
