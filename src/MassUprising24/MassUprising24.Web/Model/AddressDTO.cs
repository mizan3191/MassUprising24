using System.ComponentModel.DataAnnotations;

namespace MassUprising24.Web.Model;

public class AddressDTO
{
    [Required]
    public int WarriorId { get; set; }
    [Required]
    public string Village { get; set; }
    [Required]
    public string Thana { get; set; }
    [Required]
    public string District { get; set; }
    [Required]
    public string Division { get; set; }
    [Required]
    public AddressType AddressType { get; set; }
}



public enum AddressType
{
    Persent = 1,
    Permanent = 2,

}
