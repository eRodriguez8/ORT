using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Corp.Cencosud.Supermercados.Corp.Cencosud.Supermercados.Sua.IWMS.Biz
{
    /// <summary>
    ///  Business Layer global settings
    /// </summary>
    public static class BizSettings
    {
        /// <summary>
        /// Loads settings needed in this layer and invokes configuration method for child layers
        /// </summary>
        public static void Configure()
        {
            // add dependencies needed in this layer 
            // configure global settings for the data layer
            Dal.DalSettings.Configure();
        }
    }
}
