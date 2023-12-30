using System;
using System.Collections.Generic;

namespace gentreeAPI.Models;

public partial class Contact
{
    public int Id { get; set; }

    public int? Idperson { get; set; }

    public string? Designation { get; set; }

    public string? Valeur { get; set; }

    public virtual Person? IdpersonNavigation { get; set; }
}
