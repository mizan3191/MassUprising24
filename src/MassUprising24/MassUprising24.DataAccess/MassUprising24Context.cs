using MassUprising24.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MassUprising24.DataAccess;

public class MassUprising24Context : DbContext
{
    public MassUprising24Context(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Warrior> Warriors { get; set; }
    public DbSet<Address> Addresses { get; set; }
}
