namespace MassUprising24.Domain
{
    public class Warrior
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public string Address { get; set; }
        public string DeathPlace { get; set; }
        public Gender Gender { get; set; }
        public UniqueIdentity UniqueIdentity { get; set; }
        public AddressType AddressType { get; set; }
        public string Notes { get; set; }
    }

    public class Address
    {
        public int Id { get; set; }
        public string Village { get; set; }
        public string Thana { get; set; }
        public string District { get; set; }
        public string Division { get; set; }


        public int WarriorId { get; set; }
        public Warrior Warrior { get; set; }
    }

    public class Allowance
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateGranted { get; set; }
        public string Remarks { get; set; }

        public int WarriorId { get; set; }
        public Warrior Warrior { get; set; }
    }

    public enum Gender
    {
        Male = 1,
        Female = 2,
        Other = 3
    }

    public enum UniqueIdentity
    {
        NID = 1,
        DOB = 2,
        PASSPORT = 3,
        Other = 4,
    }

    public enum AddressType
    {
        Persent = 1,
        Permanent = 2,

    }
}
