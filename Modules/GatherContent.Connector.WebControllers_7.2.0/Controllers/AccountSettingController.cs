using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GatherContent.Connector.Entities;
using GatherContent.Connector.Managers.Interfaces;
using Umbraco.Core.Logging;
using Umbraco.Web.Mvc;

namespace GatherContent.Connector.WebControllers_7._2._0.Controllers
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
        public GCAccountSettings Get()
        {
            try
            {
                return _accountSettingManager.GetSettings();
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
        public void Post(GCAccountSettings model)
        {
            if (model == null)
                throw new Exception("Gather Content settings is null");
            try
            {
                _accountSettingManager.SetSettings(model);
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
