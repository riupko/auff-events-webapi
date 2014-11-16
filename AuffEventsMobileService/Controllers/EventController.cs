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
    public class EventController : TableController<Event>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Event>(context, Request, Services);
        }

        // GET tables/Event
        public IQueryable<Event> GetAllEvent()
        {
            return Query(); 
        }

        // GET tables/Event/48D68C86-6EA6-4C25-AA33-223FC9A27959
        /// <summary>
        /// Получение события по ключу
        /// </summary>
        /// <param name="id">ключ события</param>
        /// <returns></returns>
        public SingleResult<Event> GetEvent(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Event/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Event> PatchEvent(string id, Delta<Event> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Event/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public async Task<IHttpActionResult> PostEvent(Event item)
        {
            Event current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Event/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteEvent(string id)
        {
             return DeleteAsync(id);
        }

    }
}