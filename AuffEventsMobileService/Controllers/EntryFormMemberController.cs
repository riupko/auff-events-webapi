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
    public class EntryFormMemberController : TableController<EntryFormMember>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<EntryFormMember>(context, Request, Services);
        }

        // GET tables/EntryFormMember
        public IQueryable<EntryFormMember> GetAllEntryFormMember()
        {
            return Query(); 
        }

        // GET tables/EntryFormMember/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<EntryFormMember> GetEntryFormMember(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/EntryFormMember/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<EntryFormMember> PatchEntryFormMember(string id, Delta<EntryFormMember> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/EntryFormMember/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public async Task<IHttpActionResult> PostEntryFormMember(EntryFormMember item)
        {
            EntryFormMember current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/EntryFormMember/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteEntryFormMember(string id)
        {
             return DeleteAsync(id);
        }

    }
}