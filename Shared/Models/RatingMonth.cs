using System;
using System.Collections.Generic;

namespace Shared.Models;

public partial class RatingMonth
{
    public string Ratingmonthid { get; set; } = null!;

    public string Month { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string Userid { get; set; } = null!;

    public virtual ICollection<RatingCriterion> RatingCriteria { get; set; } = new List<RatingCriterion>();

    public virtual Users User { get; set; } = null!;
}
