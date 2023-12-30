using System;
using System.Collections.Generic;

namespace gentreeAPI.Models;

public partial class Engendre
{
    public int Id { get; set; }

    public int Parent { get; set; }

    public int Enfant { get; set; }

    public int? Avec { get; set; }

    public DateTime? Datenais { get; set; }

    public virtual Person? AvecNavigation { get; set; }

    public virtual Person EnfantNavigation { get; set; } = null!;

    public virtual Person ParentNavigation { get; set; } = null!;
}
