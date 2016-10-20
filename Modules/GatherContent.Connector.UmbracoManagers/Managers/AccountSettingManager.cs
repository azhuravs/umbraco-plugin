using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GatherContent.Connector.Entities;
using GatherContent.Connector.GatherContentService.Interfaces;
using GatherContent.Connector.IRepositories.Interfaces;
using GatherContent.Connector.Managers.Interfaces;
using GatherContent.Connector.Managers.Managers;
using GatherContent.Connector.UmbracoRepositories.Repositories;

namespace GatherContent.Connector.Managers.Managers
{
    public class AccountSettingManager : BaseManager, IAccountSettingManager
    {
        private readonly IAccountsRepository _accountsRepository;

        public AccountSettingManager(IAccountsService accountsService,
            IProjectsService projectsService,
            ITemplatesService templateService,
            ICacheManager cacheManager) : base(accountsService, projectsService, templateService, cacheManager)
        {
            _accountsRepository = new AccountsRepository();
        }

        public GCAccountSettings GetSettings()
        {
            return _accountsRepository.GetAccountSettings();
        }

        public void SetSettings(GCAccountSettings accountSettings)
        {
            _accountsRepository.SetAccountSettings(accountSettings);
        }

        public bool TestSettings()
        {
            try
            {
                AccountsService.GetAccounts();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
