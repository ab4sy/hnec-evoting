using System;
using System.Collections.Generic;

namespace models;

public partial class Voter
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string? CardNo { get; set; }

    public DateOnly? CardExpDate { get; set; }

    public string? CardPin { get; set; }

    public short VotingCenterId { get; set; }

    public string? NationalNo { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? PlaceOfBirth { get; set; }

    public string PhoneNo { get; set; } = null!;

    public string? Email { get; set; }

    public short? CityId { get; set; }

    public short? MunicipalityId { get; set; }

    public string? Address { get; set; }

    public short Status { get; set; }

    public virtual ICollection<Vote> Votes { get; set; } = new List<Vote>();
}
