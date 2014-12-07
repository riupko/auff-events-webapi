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
    public class TeamRoleController : TableController<TeamRole>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<TeamRole>(context, Request, Services);
        }

        // GET tables/TeamRole
        public IQueryable<TeamRole> GetAllTeamRole()
        {
            return Query(); 
        }

        // GET tables/TeamRole/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<TeamRole> GetTeamRole(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/TeamRole/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<TeamRole> PatchTeamRole(string id, Delta<TeamRole> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/TeamRole
        public async Task<IHttpActionResult> PostTeamRole(TeamRole item)
        {
            TeamRole current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/TeamRole/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteTeamRole(string id)
        {
             return DeleteAsync(id);
        }

    }
}