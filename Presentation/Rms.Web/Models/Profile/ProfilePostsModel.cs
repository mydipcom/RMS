﻿using System.Collections.Generic;
using Rms.Web.Models.Common;

namespace Rms.Web.Models.Profile
{
    public partial class ProfilePostsModel
    {
        public IList<PostsModel> Posts { get; set; }
        public PagerModel PagerModel { get; set; }
    }
}