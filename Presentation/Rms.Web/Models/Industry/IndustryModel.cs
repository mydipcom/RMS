using Rms.Web.Framework.Mvc;

namespace Rms.Web.Models.Industry
{
    public class IndustryModel : BaseNopEntityModel
    { 
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}