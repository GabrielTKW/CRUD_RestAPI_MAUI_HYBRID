using System;
using System.Collections.Generic;

namespace Shared.Models;

public partial class RatingCriterion
{
    public string Rcid { get; set; } = null!;

    public string Ratingmonthid { get; set; } = null!;

    public string Criteriaid { get; set; } = null!;

    public string? Scoreidintern { get; set; }

    public string? Scoreidsupervisor { get; set; }

    public virtual Criterion Criteria { get; set; } = null!;

    public virtual RatingMonth Ratingmonth { get; set; } = null!;

    public virtual Scoring? ScoreidinternNavigation { get; set; }

    public virtual Scoring? ScoreidsupervisorNavigation { get; set; }
}
