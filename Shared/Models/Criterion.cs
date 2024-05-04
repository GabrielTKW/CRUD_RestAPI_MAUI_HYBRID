using System;
using System.Collections.Generic;

namespace Shared.Models;

public partial class Criterion
{
    public string Criteriaid { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool Isactive { get; set; }

    public DateTime Datecreated { get; set; }

    public virtual ICollection<RatingCriterion> RatingCriteria { get; set; } = new List<RatingCriterion>();

    public virtual ICollection<Scoring> Scorings { get; set; } = new List<Scoring>();
}
