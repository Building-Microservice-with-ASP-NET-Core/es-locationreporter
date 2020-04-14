using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StatlerWaldorfCorp.LocationReporter.Events;
using StatlerWaldorfCorp.LocationReporter.Models;
using StatlerWaldorfCorp.LocationReporter.Services;

namespace StatlerWaldorfCorp.LocationReporter.Controllers
{
    [Route("/api/members/{memberId}/locationreports")]
    public class LocationReportsController : ControllerBase
    {
        private ICommandEventConverter converter;
        private IEventEmitter eventEmitter;
        private ITeamServiceClient teamServiceClient;


        public LocationReportsController(ICommandEventConverter converter,
            IEventEmitter eventEmitter,
            ITeamServiceClient teamServiceClient)
        {
            this.converter = converter;
            this.eventEmitter = eventEmitter;
            this.teamServiceClient = teamServiceClient;
        }

        [HttpPost]
        public async Task<ActionResult> PostLocationReport(Guid memberId, [FromBody]LocationReport locationReport)
        {
            MemberLocationRecordedEvent locationRecordedEvent = converter.CommandToEvent(locationReport);
            locationRecordedEvent.TeamID = await teamServiceClient.GetTeamForMember(locationReport.MemberID);
            eventEmitter.EmitLocationRecordedEvent(locationRecordedEvent);

            return this.Created($"/api/members/{memberId}/locationreports/{locationReport.ReportID}", locationReport);
        }
    }
}