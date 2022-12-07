namespace ErrorMailTypes.Models;

public class Template
{
    public int MailTypeId { get; set; }

    public string MailType { get; set; } = null!;

    public string MailBody { get; set; } = null!;
}
