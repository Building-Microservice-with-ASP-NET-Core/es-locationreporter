using System;
using System.Threading.Tasks;
using StatlerWaldorfCorp.LocationReporter.Services;

namespace StatlerWaldorfCorp.LocationReporter.Tests.Fakes
{
    public class FakeTeamServiceClient : ITeamServiceClient
    {
        private Guid teamGuid;

        public FakeTeamServiceClient()
        {
            teamGuid = Guid.NewGuid();
        }

        public async Task<Guid> GetTeamForMember(Guid memberId)
        {
            return await Task.FromResult(teamGuid);//  teamGuid;
        }

        public Guid FixedID
        {
            get
            {
                return teamGuid;
            }
        }
    }
}