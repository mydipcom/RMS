using System.Collections.Generic;
using Rms.Web.Framework.Mvc;
 
using Rms.Web.Models.Topics;

namespace Rms.Web.Models.Common
{
    public partial class SitemapModel : BaseNopModel
    {
        public SitemapModel()
        {
            
            Topics = new List<TopicModel>();
        }
       
        public IList<TopicModel> Topics { get; set; }

        public bool NewsEnabled { get; set; }
        public bool BlogEnabled { get; set; }
        public bool ForumEnabled { get; set; }
    }
}