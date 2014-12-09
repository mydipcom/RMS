using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rms.Core.Domain.Common;
using Rms.Core.Data;
using Rms.Services.Logging;
using Rms.Services.Localization;
using Rms.Core.Caching;
using Rms.Services.Events;

namespace Rms.Services.Common
{
    public partial class IndustryService : IIndustryService
    {
        #region Constants
        #endregion
        #region Fields
        private readonly IRepository<Industry> _industryRepository;
        private readonly ILogger _logger;
        private readonly IGenericAttributeService _genericAttributeService;
        private readonly ILocalizationService _localizationService;
        private readonly ICacheManager _cacheManager;
        private readonly IEventPublisher _eventPublisher;
        #endregion

        #region Ctor

        public IndustryService(IRepository<Industry> industryRepository,
            ILogger logger,
            IGenericAttributeService genericAttributeService,
            ILocalizationService localizationService,
            IEventPublisher eventPublisher,
            ICacheManager cacheManager)
        {
            this._industryRepository = industryRepository;
            this._logger = logger;
            this._genericAttributeService = genericAttributeService;
            this._localizationService = localizationService;
            this._cacheManager = cacheManager;
            this._eventPublisher = eventPublisher;
        }

        #endregion

        #region Methods


        #region Delivery dates

        /// <summary>
        /// 
        /// </summary>
        /// <param name="industry"></param>
        public virtual void DeleteIndustry(Industry industry)
        {
            if (industry == null)
                throw new ArgumentNullException("industry");

            _industryRepository.Delete(industry);
            _eventPublisher.EntityDeleted(industry);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="industryId"></param>
        /// <returns></returns>
        public virtual Industry GetIndustryById(int industryId)
        {
            if (industryId == 0)
                return null;

            return _industryRepository.GetById(industryId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual IList<Industry> GetAllIndustries()
        {
            var query = from dd in _industryRepository.Table
                        orderby dd.DisplayOrder
                        select dd;
            var industries = query.ToList();
            return industries;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="industry"></param>
        public virtual void InsertIndustry(Industry industry)
        {
            if (industry == null)
                throw new ArgumentNullException("industry");

            _industryRepository.Insert(industry);

            //event notification
            _eventPublisher.EntityInserted(industry);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="industry"></param>
        public virtual void UpdateIndustry(Industry industry)
        {
            if (industry == null)
                throw new ArgumentNullException("industry");

            _industryRepository.Update(industry);

            //event notification
            _eventPublisher.EntityUpdated(industry);
        }

        #endregion



        #endregion
    }
}
