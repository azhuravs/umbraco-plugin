using System;
using System.Net;
using System.Web.Http;
using GatherContent.Connector.Entities;
using GatherContent.Connector.Managers.Interfaces;
using Umbraco.Core.Logging;
using Umbraco.Web.Mvc;

namespace GatherContent.Connector.UmbracoWebControllers.Controllers
{
    [PluginController("GatherContent")]
    public class AccountSettingController : BaseController
    {
        private readonly IAccountSettingManager _accountSettingManager;
        public AccountSettingController(IAccountSettingManager accountSettingManager)
        {
             _accountSettingManager = accountSettingManager;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_accountSettingManager.GetSettings());
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
        public bool TestSettings()
        {
            try
            {
                return _accountSettingManager.TestSettings();
            }
            catch (Exception exception)
            {
                LogHelper.Error(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, exception.Message, exception);
            }
            return false;
        }

        [HttpPost]
        public IHttpActionResult Post(GCAccountSettings model)
        {
            if (model == null)
                BadRequest("Gather Content settings is null");
            try
            {
                _accountSettingManager.SetSettings(model);
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
