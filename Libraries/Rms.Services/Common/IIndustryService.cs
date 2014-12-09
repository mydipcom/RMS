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


        void InsertIndustry(Industry industry);


        void UpdateIndustry(Industry industry);

 
    }
}