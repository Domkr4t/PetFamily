using Microsoft.EntityFrameworkCore;
using PetFamily.Application.Volunteers;
using PetFamily.Domain.Pets.Entity;
using PetFamily.Domain.Shared;

namespace PetFamily.Infrastucture.Repositories
{
    public class VolunteersRepository : IVolunteersRepository
    {
        public readonly ApplicationDbConbext _dbConbext;

        public VolunteersRepository(ApplicationDbConbext dbConbext)
        {
            _dbConbext = dbConbext;
        }

        public async Task<Guid> Add(Volunteer volunteer, CancellationToken cancellationToken = default)
        {
            await _dbConbext.Volunteers.AddAsync(volunteer, cancellationToken);

            await _dbConbext.SaveChangesAsync(cancellationToken);

            return volunteer.Id.Value;
        }

        public async Task<Result<Volunteer, Error>> GetByEmail(
            string volunteerEmail,
            CancellationToken cancellationToken = default)
        {
            var volunteer = await _dbConbext.Volunteers
                                            .Include(v => v.Pets)
                                            .FirstOrDefaultAsync(v => v.Email == volunteerEmail);

            if (volunteer == null)
                return Errors.General.NotFound("volunteer");

            return Result<Volunteer, Error>.Success(volunteer);
        }
    }
}
