using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using GatherContent.Connector.Managers.Interfaces;
using GatherContent.Connector.Managers.Models.UpdateItems;
using GatherContent.Connector.Managers.Models.UpdateItems.New;
using Umbraco.Core.Logging;
using Umbraco.Web.Mvc;

namespace GatherContent.Connector.UmbracoWebControllers.Controllers
{
    [PluginController("GatherContent")]
    public class UpdateController : BaseController
    {
        protected IUpdateManager UpdateManager;
        protected IImportManager ImportManager;

        public UpdateController(IUpdateManager updateManager, IImportManager importManager)
        {
            ImportManager = importManager;
            UpdateManager = updateManager;
        }

        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            try
            {
                UpdateModel updateModel = UpdateManager.GetItemsForUpdate(id, "");
                return Ok(updateModel);
            }
            catch (WebException exception)
            {
                LogHelper.Error(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, exception.Message, exception);
                return BadRequest(exception.Message + " Please check your credentials");
            }
            catch (Exception exception)
            {
                LogHelper.Error(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, exception.Message, exception);
                return BadRequest(exception.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult UpdateItems([FromUri]string id, [FromBody]List<UpdateListIds> items)
        {
            try
            {
                var result = UpdateManager.UpdateItems(id, items, null);
                return Ok(result);
            }
            catch (WebException exception)
            {
                LogHelper.Error(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, exception.Message, exception);
                return BadRequest(exception.Message + " Please check your credentials");
            }
            catch (Exception exception)
            {
                LogHelper.Error(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, exception.Message, exception);
                return BadRequest(exception.Message);
            }
        }
    }
}
