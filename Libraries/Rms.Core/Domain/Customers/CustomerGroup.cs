using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rms.Core.Domain.Groups;

namespace Rms.Core.Domain.Customers
{
    /// <summary>
    /// 
    /// </summary>
    public partial class CustomerGrop : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public int CustomerId { get; set; }

       /// <summary>
       /// 
       /// </summary>
        public int GroupId { get; set; }

       /// <summary>
       /// 
       /// </summary>
        public bool IsLeader { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }

       /// <summary>
       /// 
       /// </summary>
        public virtual Group Group { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Customer Customer { get; set; }

    }

}
