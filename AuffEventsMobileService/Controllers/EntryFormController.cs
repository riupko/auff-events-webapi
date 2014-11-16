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
    public class EntryFormController : TableController<EntryForm>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<EntryForm>(context, Request, Services);
        }

        // GET tables/EntryForm
        public IQueryable<EntryForm> GetAllEntryForm()
        {
            return Query();
        }

        // GET tables/EntryForm/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<EntryForm> GetEntryForm(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/EntryForm/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<EntryForm> PatchEntryForm(string id, Delta<EntryForm> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/EntryForm/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public async Task<IHttpActionResult> PostEntryForm(EntryForm item)
        {
            EntryForm current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/EntryForm/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteEntryForm(string id)
        {
             return DeleteAsync(id);
        }

    }
}