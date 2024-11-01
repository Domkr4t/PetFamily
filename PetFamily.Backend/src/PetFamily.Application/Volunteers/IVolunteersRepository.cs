using PetFamily.Domain.Pets.Entity;
using PetFamily.Domain.Shared;

namespace PetFamily.Application.Volunteers
{
    public interface IVolunteersRepository
    {
        Task<Guid> Add(Volunteer volunteer, CancellationToken cancellationToken = default);
        Task<Result<Volunteer, Error>> GetByEmail(string volunteerEmail,
                                                  CancellationToken cancellationToken = default);
    }
}
