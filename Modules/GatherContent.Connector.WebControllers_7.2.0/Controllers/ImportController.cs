using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GatherContent.Connector.Managers.Interfaces;
using GatherContent.Connector.Managers.Models.ImportItems;
using GatherContent.Connector.Managers.Models.ImportItems.New;
using GatherContent.Connector.Managers.Models.Mapping;
using Umbraco.Core.Logging;
using Umbraco.Web.Mvc;
using FiltersModel = GatherContent.Connector.Managers.Models.ImportItems.New.FiltersModel;

namespace GatherContent.Connector.WebControllers_7._2._0.Controllers
{
    [PluginController("GatherContent")]
    public class ImportController : BaseController
    {
        private readonly IImportManager _itemManager;
        private readonly IMappingManager _mappingManager;

        public ImportController(IImportManager importManager, IMappingManager mappingManager)
        {
            _itemManager = importManager;
            _mappingManager = mappingManager;
        }

        [System.Web.Http.HttpGet]
        public List<ItemModel> GetItems(string projectId = "", string templateId = "")
        {
            try
            {
                if (string.IsNullOrWhiteSpace(projectId))
                    return new List<ItemModel>();

                return _itemManager.GetImportDialogModel(null, projectId);
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

        [System.Web.Http.HttpGet]
        public FiltersModel GetFilters(int projectId)
        {
            try
            {
                return _itemManager.GetFilters(projectId.ToString());
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

        [HttpGet]
        public List<GcProjectModel> GetProjectsWithMapp()
        {
            try
            {
                return _mappingManager.GetGcProjectsWithMappings();
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

        [System.Web.Http.HttpPost]
        public List<ItemResultModel> Post([FromBody]List<ImportItemModel> items, [FromUri]string id, [FromUri]string projectId, [FromUri]string statusId)
        {
            try
            {
                return _itemManager.ImportItems(id, items, projectId, statusId, null);
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

        [System.Web.Http.HttpPost]
        public List<ItemResultModel> PostWithLocations([FromBody]List<LocationImportItemModel> items, [FromUri]string projectId, [FromUri]string statusId)
        {
            try
            {
                return _itemManager.ImportItemsWithLocation(items, projectId, statusId, null);
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
