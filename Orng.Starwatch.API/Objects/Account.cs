namespace Orng.Starwatch.API.Objects;

public class Account
{
    public string? Name { get; set; }
    public bool? IsAdmin { get; set; }
    public string? Password { get; set; }
    public DateTime? LastSeen { get; set; }
    public bool? IsActive { get; set; }
}
