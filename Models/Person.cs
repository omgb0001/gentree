using System;
using System.Collections.Generic;

namespace gentreeAPI.Models;

public partial class Person
{
    public int Id { get; set; }

    public string? Nom { get; set; }

    public string? Prenom { get; set; }

    public string? Sexe { get; set; }

    public byte[]? Photo { get; set; }

    public DateTime? Datedec { get; set; }

    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();

    public virtual ICollection<Engendre> EngendreAvecNavigations { get; set; } = new List<Engendre>();

    public virtual ICollection<Engendre> EngendreEnfantNavigations { get; set; } = new List<Engendre>();

    public virtual ICollection<Engendre> EngendreParentNavigations { get; set; } = new List<Engendre>();
}
