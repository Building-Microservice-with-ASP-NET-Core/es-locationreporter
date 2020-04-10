using System;
using System.Threading.Tasks;

namespace StatlerWaldorfCorp.LocationReporter.Services
{
    public interface ITeamServiceClient
    {
        Task<Guid> GetTeamForMember(Guid memberId);
    }
}