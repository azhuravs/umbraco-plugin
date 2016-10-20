using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.UI.WebControls;
using GatherContent.Connector.Managers.Interfaces;
using GatherContent.Connector.Managers.Managers;
using GatherContent.Connector.Managers.Models.Mapping;
using Umbraco.Core.Logging;
using Umbraco.Web.Editors;
using Umbraco.Web.Models.Trees;
using Umbraco.Web.Mvc;
using Umbraco.Web.Trees;
using TreeNode = Umbraco.Web.Models.Trees.TreeNode;
using TreeNodeCollection = Umbraco.Web.Models.Trees.TreeNodeCollection;

namespace GatherContent.Connector.UmbracoWebControllers.Controllers
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
        public IHttpActionResult GetAll()
        {
            try
            {
                return Ok(_mappingManager.GetMappingModel());
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
                throw new WebException(exception.Message + " Please check your credentials");
            }
            catch (Exception exception)
            {
                LogHelper.Error(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, exception.Message, exception);
                throw;
            }
        }

        [HttpGet]
        public IHttpActionResult Get(string gcId, string cmsId)
        {
            try
            {
                return Ok(_mappingManager.GetSingleMappingModel(gcId, cmsId));
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

        [HttpGet]
        public IHttpActionResult GetAllProjects()
        {
            try
            {
                return Ok(_mappingManager.GetAllGcProjects());
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

        [HttpGet]
        public IHttpActionResult GetTemplatesByProject(string id)
        {
            try
            {
                return Ok(_mappingManager.GetTemplatesByProjectId(id));
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

        [HttpGet]
        public IHttpActionResult GetFieldsByTemplateId(string id)
        {
            try
            {
                return Ok(_mappingManager.GetFieldsByTemplateId(id));
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

        [HttpGet]
        public IHttpActionResult GetAvailableTemplates()
        {
            try
            {
                return Ok(_mappingManager.GetAvailableTemplates());
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
        public IHttpActionResult Post(MappingModel model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.MappingId))
                    _mappingManager.CreateMapping(model);
                else
                    _mappingManager.UpdateMapping(model);
                return Ok();
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

        [HttpDelete]
        public IHttpActionResult DeleteMapping(int temlateId)
        {
            try
            {
                _mappingManager.DeleteMapping(temlateId.ToString());
                return Ok();
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
