using MassUprising24.Domain.Entities;
using MassUprising24.Domain.Model;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MassUprising24.DataAccess.CQRS.Command;

public class CreateAddressCmd : IRequest<CmdResponse>
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

public class AddressCommandHandler : IRequestHandler<CreateAddressCmd, CmdResponse>
{
    private MassUprising24Context _context;

    public AddressCommandHandler(MassUprising24Context context)
    {
        _context = context;
    }

    public async Task<CmdResponse> Handle(CreateAddressCmd request, CancellationToken cancellationToken)
    {
        try
        {
            if(request.WarriorId <= 0)
            {
                return new CmdResponse()
                {
                    Id = 0,
                    Message = "Warrior id cannot zero or null.",
                    Success = false,
                };
            }
            else
            {
                //validate warrior
                if(!IsExitWarrior(request.WarriorId))
                {
                    return new CmdResponse()
                    {
                        Id = 0,
                        Message = "Warrior does not exits.",
                        Success = false,
                    };
                }
                else
                {
                    //create addresss

                    Address address = new();
                    address.WarriorId = request.WarriorId;
                    address.AddressType = request.AddressType;
                    address.Village = request.Village;
                    address.Thana = request.Thana;
                    address.District = request.District;
                    address.Division = request.Division;

                    _context.Add(address);
                    await _context.SaveChangesAsync();

                    if (address.Id > 0)
                    {
                        return new CmdResponse()
                        {
                            Id = address.Id,
                            Message = "Address create successfully",
                            Success = true,
                        };
                    }
                    else
                    {
                        return new CmdResponse()
                        {
                            Id = 0,
                            Message = "Address create failed.",
                            Success = false,
                        };
                    }
                }
                
            }
        }
        catch (Exception ex)
        {
            return new CmdResponse()
            {
                Id = 0,
                Message = ex.Message,
                Success = false,
            };
        }
    }

    private bool IsExitWarrior(int warriorId)
    {
        var result = _context.Warriors.Any(w => w.Id == warriorId);
        if (result == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}