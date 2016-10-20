using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GatherContent.Connector.Managers.Interfaces;
using GatherContent.Connector.Managers.Models.Mapping;
using Umbraco.Core.Logging;
using Umbraco.Web.Mvc;

namespace GatherContent.Connector.WebControllers_7._2._0.Controllers
{
    [PluginController("GatherContent")]
    public class MappingController : BaseController
    {
        protected IMappingManager _mappingManager;
        public MappingController(IMappingManager mappingManager)
        {
            _mappingManager = mappingManager;
        }

        [HttpGet]
        public List<MappingModel> GetAll()
        {
            try
            {
                return _mappingManager.GetMappingModel();
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
        public IEnumerable<MappingModel> GetMappingMenu()
        {
            try
            {
                return _mappingManager.GetMappingModel();
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
        public MappingModel Get(string gcId, string cmsId)
        {
            try
            {
                return _mappingManager.GetSingleMappingModel(gcId, cmsId);
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
        public List<GcProjectModel> GetAllProjects()
        {
            try
            {
                return _mappingManager.GetAllGcProjects();
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
        public List<GcTemplateModel> GetTemplatesByProject(string id)
        {
            try
            {
                return _mappingManager.GetTemplatesByProjectId(id);
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
        public List<GcTabModel> GetFieldsByTemplateId(string id)
        {
            try
            {
                return _mappingManager.GetFieldsByTemplateId(id);
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
        public List<CmsTemplateModel> GetAvailableTemplates()
        {
            try
            {
                return _mappingManager.GetAvailableTemplates();
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
        public void Post(MappingModel model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.MappingId))
                    _mappingManager.CreateMapping(model);
                else
                    _mappingManager.UpdateMapping(model);
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

        [HttpDelete]
        public void DeleteMapping(int temlateId)
        {
            try
            {
                _mappingManager.DeleteMapping(temlateId.ToString());
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
