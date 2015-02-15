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
    public class MemberLicenseController : TableController<MemberLicense>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<MemberLicense>(context, Request, Services);
        }

        // GET tables/MemberLicense
        public IQueryable<MemberLicense> GetAllMemberLicense()
        {
            return Query(); 
        }

        // GET tables/MemberLicense/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<MemberLicense> GetMemberLicense(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/MemberLicense/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<MemberLicense> PatchMemberLicense(string id, Delta<MemberLicense> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/MemberLicense
        public async Task<IHttpActionResult> PostMemberLicense(MemberLicense item)
        {
            MemberLicense current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/MemberLicense/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteMemberLicense(string id)
        {
             return DeleteAsync(id);
        }

    }
}