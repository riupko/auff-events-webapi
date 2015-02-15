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
    public class ClubController : ImageTableController<Club>
    {
        public ClubController()
        {
            ImageFolder = "club";
        }

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Club>(context, Request, Services);
        }

        // GET tables/Club
        public IQueryable<Club> GetAllClub()
        {
            return Query(); 
        }

        // GET tables/Club/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Club> GetClub(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Club/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Club> PatchClub(string id, Delta<Club> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Club
        public async Task<IHttpActionResult> PostClub(Club item)
        {
            Club current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Club/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteClub(string id)
        {
             return DeleteAsync(id);
        }

        #region Image Methods
        [Route("images/Club/{id}")]
        public override async Task<HttpResponseMessage> GetImage(string id)
        {
            return await base.GetImage(id);
        }

        [HttpPost]
        [Route("images/Club/{id}")]
        public override async Task<HttpResponseMessage> PostImage(string id)
        {
            return await base.PostImage(id);
        }

        [HttpDelete]
        [Route("images/Club/{id}")]
        public override Task DeleteImage(string id)
        {
            return base.DeleteImage(id);
        }
        #endregion
    }
}