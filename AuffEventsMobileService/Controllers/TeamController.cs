using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using AuffEventsMobileService.DataObjects;
using AuffEventsMobileService.Models;
using System.Net.Http;

namespace AuffEventsMobileService.Controllers
{
    public class TeamController : ImageTableController<Team>
    {
        public TeamController()
        {
            ImageFolder = "team";
        }

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Team>(context, Request, Services);
        }

        // GET tables/Team
        public IQueryable<Team> GetAllTeam()
        {
            return Query();
        }

        // GET tables/Team/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Team> GetTeam(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Team/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Team> PatchTeam(string id, Delta<Team> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Team/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public async Task<IHttpActionResult> PostTeam(Team item)
        {
            Team current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Team/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteTeam(string id)
        {
             return DeleteAsync(id);
        }

        #region Image Methods
        [Route("images/Team/{id}")]
        public override async Task<HttpResponseMessage> GetImage(string id)
        {
            return await base.GetImage(id);
        }

        [HttpPost]
        [Route("images/Team/{id}")]
        public override async Task<HttpResponseMessage> PostImage(string id)
        {
            return await base.PostImage(id);
        }

        [HttpDelete]
        [Route("images/Team/{id}")]
        public override Task DeleteImage(string id)
        {
            return base.DeleteImage(id);
        }
        #endregion
    }
}