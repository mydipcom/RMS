using Rms.Core.Plugins;
using Rms.Web.Framework.Menu;

namespace Rms.Web.Framework.Web
{
    public interface IAdminMenuPlugin : IPlugin
    {
        /// <summary>
        /// Authenticate a user (can he see this plugin menu item?)
        /// </summary>
        /// <returns></returns>
        bool Authenticate();

        /// <summary>
        /// Build menu item
        /// </summary>
        /// <returns>Site map item</returns>
        SiteMapNode BuildMenuItem();
    }
}
