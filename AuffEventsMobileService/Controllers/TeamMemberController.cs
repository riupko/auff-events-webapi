using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using AuffEventsMobileService.DataObjects;
using AuffEventsMobileService.Models;

namespace AuffEventsMobileService.Controllers
{
    public class TeamMemberController : TableController<TeamMember>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<TeamMember>(context, Request, Services);
        }

        // GET tables/TeamMember
        public IQueryable<TeamMember> GetAllTeamMember()
        {
            return Query(); 
        }

        // GET tables/TeamMember/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<TeamMember> GetTeamMember(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/TeamMember/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<TeamMember> PatchTeamMember(string id, Delta<TeamMember> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/TeamMember/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public async Task<IHttpActionResult> PostTeamMember(TeamMember item)
        {
            TeamMember current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/TeamMember/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteTeamMember(string id)
        {
             return DeleteAsync(id);
        }

    }
}