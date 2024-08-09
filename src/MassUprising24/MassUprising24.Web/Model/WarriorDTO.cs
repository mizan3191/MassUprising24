namespace MassUprising24.Web.Model;

public class WarriorDTO
{
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime? DateOfDeath { get; set; }
    public string? DeathPlace { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public UniqueIdentity UniqueIdentity { get; set; }
    public string? Notes { get; set; } = string.Empty;
    public string UniqueId { get; set; }
}

public enum UniqueIdentity
{
    NID = 1,
    DOB = 2,
    PASSPORT = 3,
    Other = 4,
}

public enum Gender
{
    Male = 1,
    Female = 2,
    Other = 3
}