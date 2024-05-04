using System;
using System.Collections.Generic;

namespace Shared.Models;

public partial class Scoring
{
    public string Scoreid { get; set; } = null!;

    public int Score { get; set; }

    public string Comment { get; set; } = null!;

    public string Criteriaid { get; set; } = null!;

    public virtual Criterion Criteria { get; set; } = null!;

    public virtual ICollection<RatingCriterion> RatingCriterionScoreidinternNavigations { get; set; } = new List<RatingCriterion>();

    public virtual ICollection<RatingCriterion> RatingCriterionScoreidsupervisorNavigations { get; set; } = new List<RatingCriterion>();
}
