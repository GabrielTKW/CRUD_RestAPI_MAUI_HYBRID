using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Shared.Models;

public partial class Users
{
    public string Userid { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string Name { get; set; } = null!;

    public bool Isintern { get; set; }

    public string? Supervisoruserid { get; set; }

    public DateTime? Startdate { get; set; }

    public DateTime? Enddate { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public virtual ICollection<RatingMonth>? RatingMonths { get; set; } = new List<RatingMonth>();
}
