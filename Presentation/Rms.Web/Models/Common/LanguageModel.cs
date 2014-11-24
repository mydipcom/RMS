using Rms.Web.Framework.Mvc;

namespace Rms.Web.Models.Common
{
    public partial class LanguageModel : BaseNopEntityModel
    {
        public string Name { get; set; }

        public string FlagImageFileName { get; set; }

    }
}