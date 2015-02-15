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
    public class MemberTransferController : TableController<MemberTransfer>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<MemberTransfer>(context, Request, Services);
        }

        // GET tables/MemberTransfer
        public IQueryable<MemberTransfer> GetAllMemberTransfer()
        {
            return Query(); 
        }

        // GET tables/MemberTransfer/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<MemberTransfer> GetMemberTransfer(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/MemberTransfer/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<MemberTransfer> PatchMemberTransfer(string id, Delta<MemberTransfer> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/MemberTransfer
        public async Task<IHttpActionResult> PostMemberTransfer(MemberTransfer item)
        {
            MemberTransfer current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/MemberTransfer/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteMemberTransfer(string id)
        {
             return DeleteAsync(id);
        }

    }
}