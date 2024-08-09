using MassUprising24.Domain.Entities;
using MassUprising24.Domain.Model;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MassUprising24.DataAccess.CQRS.Command;

public class CreateWarriorCmd : IRequest<CmdResponse>
{
    [Required]
    public string Name { get; set; }
    [Required]
    public DateTime DateOfBirth { get; set; }
    public DateTime? DateOfDeath { get; set; }
    public string? DeathPlace { get; set; } = string.Empty;
    [Required]
    public Gender Gender { get; set; }
    [Required]
    public UniqueIdentity UniqueIdentity { get; set; }
    public string? Notes { get; set; } = string.Empty;
    [Required]
    public string UniqueId { get; set; }
}
public class ProductCommandHandler : IRequestHandler<CreateWarriorCmd, CmdResponse>
{
    private MassUprising24Context _context;

    public ProductCommandHandler(MassUprising24Context context)
    {
        _context = context;
    }

    public async Task<CmdResponse> Handle(CreateWarriorCmd request, CancellationToken cancellationToken)
    {
        try
        {
            Warrior warrior = new();
            warrior.Name = request.Name;
            warrior.Gender = request.Gender;
            warrior.DeathPlace = request.DeathPlace;
            warrior.DateOfDeath = request.DateOfDeath;
            warrior.DateOfDeath = request.DateOfDeath;
            warrior.Notes = request.Notes;
            warrior.UniqueIdentity = request.UniqueIdentity;
            warrior.UniqueId = request.UniqueId;

            _context.Add(warrior);
            await _context.SaveChangesAsync();

            if (warrior.Id > 0)
            {
                return new CmdResponse
                {
                    Id = warrior.Id,
                    Message = "Warrior create successfully",
                    Success = true
                };
            }
            else
            {
                return new CmdResponse
                {
                    Id = 0,
                    Message = "Warrior create failed.",
                    Success = true

                };
            }
        }
        catch (Exception ex)
        {
            return new CmdResponse
            {
                Id = 0,
                Message = ex.Message,
                Success = false

            };
        }
    }
}