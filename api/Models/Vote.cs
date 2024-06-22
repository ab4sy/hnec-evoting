using System;
using System.Collections.Generic;

namespace models;

public partial class Vote
{
    public int Id { get; set; }

    public int VoterId { get; set; }

    public int CandidateId { get; set; }

    public DateOnly VotingDate { get; set; }

    public short Status { get; set; }

    public virtual Voter Voter { get; set; } = null!;
}
