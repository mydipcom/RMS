using System.ComponentModel.DataAnnotations;
using Rms.Web.Framework.Mvc;

namespace Rms.Web.Models.Industry
{
    public class IndustryModel : BaseNopEntityModel
    {
        [Required(ErrorMessage = "Industry.Fields.Name.Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Industry.Fields.DisplayOrder.Required")]
        public int DisplayOrder { get; set; }
    }
}