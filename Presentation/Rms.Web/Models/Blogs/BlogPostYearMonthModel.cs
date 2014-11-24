﻿using System.Collections.Generic;
using Rms.Web.Framework.Mvc;

namespace Rms.Web.Models.Blogs
{
    public partial class BlogPostYearModel : BaseNopModel
    {
        public BlogPostYearModel()
        {
            Months = new List<BlogPostMonthModel>();
        }
        public int Year { get; set; }
        public IList<BlogPostMonthModel> Months { get; set; }
    }
    public partial class BlogPostMonthModel : BaseNopModel
    {
        public int Month { get; set; }

        public int BlogPostCount { get; set; }
    }
}