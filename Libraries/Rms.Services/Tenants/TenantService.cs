using Rms.Core;
using Rms.Core.Data;
using Rms.Core.Domain.Tenants;
using Rms.Services.Events;
using System;
using System.Linq;

namespace Rms.Services.Tenants
{
    public partial class TenantService : ITenantService
    {
        #region Fields

        private readonly IRepository<Tenant> _tenantRepository;
        private readonly IEventPublisher _eventPublisher;

        #endregion

        #region Ctor

        public TenantService(IRepository<Core.Domain.Tenants.Tenant> tenantRepository,
            IEventPublisher eventPublisher)
        {
            this._tenantRepository = tenantRepository;
            this._eventPublisher = eventPublisher;
        }

        #endregion

        #region Methods

        public virtual Tenant GetTenantById(int tenantId)
        {
            if (tenantId == 0)
                return null;

            return _tenantRepository.GetById(tenantId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tenant"></param>
        public virtual void DeleteTenant(Tenant tenant)
        {
            if (tenant == null)
                throw new ArgumentNullException("tenant");
            _tenantRepository.Delete(tenant);

            //event notification
            _eventPublisher.EntityDeleted(tenant);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        public virtual IPagedList<Tenant> GetAllTenantss(int pageIndex, int pageSize, bool showHidden = false)
        {
            var query = _tenantRepository.Table;

            query = query.OrderByDescending(a => a.Id);

            var tenants = new PagedList<Tenant>(query, pageIndex, pageSize);
            return tenants;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tenant"></param>
        public virtual void InsertTenant(Tenant tenant)
        {
            if (tenant == null)
                throw new ArgumentNullException("tenant");

            _tenantRepository.Insert(tenant);

            //event notification
            _eventPublisher.EntityInserted(tenant);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tenant"></param>
        public virtual void UpdateTenant(Tenant tenant)
        {
            if (tenant == null)
                throw new ArgumentNullException("tenant");

            _tenantRepository.Update(tenant);

            //event notification
            _eventPublisher.EntityUpdated(tenant);
        }

        #endregion

    }
}