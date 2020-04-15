using FlexCore;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Unity;

namespace Corp.Cencosud.Supermercados.Corp.Cencosud.Supermercados.Sua.IWMS.Dal
{
    /// <summary>
    ///  Data Layer global settings
    /// </summary>
    public static class DalSettings
    {
        /// <summary>
        /// Loads settings needed in this layer and invokes configuration method for child layers
        /// </summary>
        public static void Configure()
        {
            if (Unity.Container == null)
            {
                // initialize de UnityContainer
                Unity.Container = new Microsoft.Practices.Unity.UnityContainer();
                Unity.Container.AddNewExtension<EnterpriseLibraryCoreExtension>();
            }
        }
    }
}
