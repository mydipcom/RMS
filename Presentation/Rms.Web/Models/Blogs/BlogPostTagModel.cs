using Rms.Web.Framework.Mvc;

namespace Rms.Web.Models.Blogs
{
    public partial class BlogPostTagModel : BaseNopModel
    {
        public string Name { get; set; }

        public int BlogPostCount { get; set; }
    }
}