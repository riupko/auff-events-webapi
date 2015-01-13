using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using AuffEventsMobileService.DataObjects;
using AuffEventsMobileService.Models;
using System.Net.Http;
using System.Web.Http.Filters;
using System.Data.Entity;

namespace AuffEventsMobileService.Controllers
{
    public class MemberController : ImageTableController<Member>
    {
        public MemberController()
        {
            ImageFolder = "member";
        }

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Member>(context, Request, Services);
        }

        // GET tables/Member
        public IQueryable<Member> GetAllMember()
        {
            return Query();
        }

        // GET tables/Member/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Member> GetMember(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Member/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Member> PatchMember(string id, Delta<Member> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Member
        public async Task<IHttpActionResult> PostMember(Member item)
        {
            Member current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Member/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteMember(string id)
        {
             return DeleteAsync(id);
        }

        #region Image Methods
        [Route("images/Member/{id}")]
        public override async Task<HttpResponseMessage> GetImage(string id)
        {
            return await base.GetImage(id);
        }

        [HttpPost]
        [Route("images/Member/{id}")]
        public override async Task<HttpResponseMessage> PostImage(string id)
        {
            return await base.PostImage(id);
        }

        [HttpDelete]
        [Route("images/Member/{id}")]
        public override Task DeleteImage(string id)
        {
            return base.DeleteImage(id);
        }
        #endregion
    }
}