using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orng.Starwatch.API.Objects;
public class Statistics
{
    public int? Connections { get; set; }
    public int? LastConnectionID { get; set; }
    public MemoryUsage? MemoryUsage { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public double? Uptime { get; set; }
    public long? UptimeId { get; set; }
    public int? TotalAccounts { get; set; }
    public string? LastShutdownReason { get; set; }
}
