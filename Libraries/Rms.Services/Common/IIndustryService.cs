using Rms.Core;
using Rms.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Services.Common
{ 
    public partial interface IIndustryService
    {

        void DeleteIndustry(Industry industry);


        Industry GetIndustryById(int industryId);


        IList<Industry> GetAllIndustries();

        /// <summary>
        /// Gets all industrys.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        IPagedList<Industry> GetAllIndustrys(int pageIndex, int pageSize); 

        void InsertIndustry(Industry industry);


        void UpdateIndustry(Industry industry);

 
    }
}