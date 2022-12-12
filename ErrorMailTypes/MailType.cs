using System;
using System.Collections.Generic;

namespace TemplateContent;

public partial class MailType
{
    public int MailTypeId { get; set; }

    public string MailType1 { get; set; } = null!;

    public string MailBody { get; set; } = null!;
}
