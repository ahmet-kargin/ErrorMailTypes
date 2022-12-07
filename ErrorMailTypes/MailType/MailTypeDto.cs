using System;
using System.Collections.Generic;

namespace ErrorMailTypes.MailType;

public partial class MailTypeDto
{
    public int MailTypeId { get; set; }

    public string? MailType { get; set; }

    public string? MailBody { get; set; }
}
