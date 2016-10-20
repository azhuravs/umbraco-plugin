using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GatherContent.Connector.Managers.Interfaces;
using GatherContent.Connector.Managers.Models.ImportItems.New;
using GatherContent.Connector.Managers.Models.UpdateItems;
using GatherContent.Connector.Managers.Models.UpdateItems.New;
using Umbraco.Core.Logging;
using Umbraco.Web.Mvc;

namespace GatherContent.Connector.WebControllers_7._2._0.Controllers
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
        public UpdateModel Get(string id)
        {
            try
            {
                UpdateModel updateModel = UpdateManager.GetItemsForUpdate(id, "");
                return updateModel;
            }
            catch (WebException exception)
            {
                LogHelper.Error(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, exception.Message, exception);
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    exception.Message + " Please check your credentials"));
            }
            catch (Exception exception)
            {
                LogHelper.Error(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, exception.Message, exception);
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, exception.Message));
            }
        }

        [HttpPost]
        public List<ItemResultModel> UpdateItems([FromUri]string id, [FromBody]List<UpdateListIds> items)
        {
            try
            {
                var result = UpdateManager.UpdateItems(id, items, null);
                return result;
            }
            catch (WebException exception)
            {
                LogHelper.Error(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, exception.Message, exception);
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    exception.Message + " Please check your credentials"));
            }
            catch (Exception exception)
            {
                LogHelper.Error(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, exception.Message, exception);
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, exception.Message));
            }
        }
    }
}
