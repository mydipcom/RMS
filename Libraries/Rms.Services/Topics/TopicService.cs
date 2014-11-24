using System;
using System.Collections.Generic;
using System.Linq;
using Rms.Core.Data;
using Rms.Core.Domain.Catalog;
using Rms.Core.Domain.Stores;
using Rms.Core.Domain.Topics;
using Rms.Services.Events;
using Rms.Services.Stores;

namespace Rms.Services.Topics
{
    /// <summary>
    /// Topic service
    /// </summary>
    public partial class TopicService : ITopicService
    {
        #region Fields

        private readonly IRepository<Topic> _topicRepository;
        private readonly IRepository<StoreMapping> _storeMappingRepository;
        private readonly IStoreMappingService _storeMappingService;
        
        private readonly IEventPublisher _eventPublisher;

        #endregion

        #region Ctor

        public TopicService(IRepository<Topic> topicRepository, 
            IRepository<StoreMapping> storeMappingRepository,
            IStoreMappingService storeMappingService,
           
            IEventPublisher eventPublisher)
        {
            this._topicRepository = topicRepository;
            this._storeMappingRepository = storeMappingRepository;
            this._storeMappingService = storeMappingService;
           
            this._eventPublisher = eventPublisher;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Deletes a topic
        /// </summary>
        /// <param name="topic">Topic</param>
        public virtual void DeleteTopic(Topic topic)
        {
            if (topic == null)
                throw new ArgumentNullException("topic");

            _topicRepository.Delete(topic);

            //event notification
            _eventPublisher.EntityDeleted(topic);
        }

        /// <summary>
        /// Gets a topic
        /// </summary>
        /// <param name="topicId">The topic identifier</param>
        /// <returns>Topic</returns>
        public virtual Topic GetTopicById(int topicId)
        {
            if (topicId == 0)
                return null;

            return _topicRepository.GetById(topicId);
        }

        /// <summary>
        /// Gets a topic
        /// </summary>
        /// <param name="systemName">The topic system name</param>
        /// <param name="storeId">Store identifier; pass 0 to ignore filtering by store and load the first one</param>
        /// <returns>Topic</returns>
        public virtual Topic GetTopicBySystemName(string systemName, int storeId = 0)
        {
            if (String.IsNullOrEmpty(systemName))
                return null;

            var query = _topicRepository.Table;
            query = query.Where(t => t.SystemName == systemName);
            query = query.OrderBy(t => t.Id);
            var topics = query.ToList();
            if (storeId > 0)
            {
                topics = topics.Where(x => _storeMappingService.Authorize(x, storeId)).ToList();
            }
            return topics.FirstOrDefault();
        }

        /// <summary>
        /// Gets all topics
        /// </summary>
        /// <param name="storeId">Store identifier; pass 0 to load all records</param>
        /// <returns>Topics</returns>
        public virtual IList<Topic> GetAllTopics(int storeId)
        {
            var query = _topicRepository.Table;
            query = query.OrderBy(t => t.SystemName);

            //Store mapping
            if (storeId > 0 )
            {
                query = from t in query
                        join sm in _storeMappingRepository.Table
                        on new { c1 = t.Id, c2 = "Topic" } equals new { c1 = sm.EntityId, c2 = sm.EntityName } into t_sm
                        from sm in t_sm.DefaultIfEmpty()
                        where !t.LimitedToStores || storeId == sm.StoreId
                        select t;

                //only distinct items (group by ID)
                query = from t in query
                        group t by t.Id
                        into tGroup
                        orderby tGroup.Key
                        select tGroup.FirstOrDefault();
                query = query.OrderBy(t => t.SystemName);
            }

            return query.ToList();
        }

        /// <summary>
        /// Inserts a topic
        /// </summary>
        /// <param name="topic">Topic</param>
        public virtual void InsertTopic(Topic topic)
        {
            if (topic == null)
                throw new ArgumentNullException("topic");

            _topicRepository.Insert(topic);

            //event notification
            _eventPublisher.EntityInserted(topic);
        }

        /// <summary>
        /// Updates the topic
        /// </summary>
        /// <param name="topic">Topic</param>
        public virtual void UpdateTopic(Topic topic)
        {
            if (topic == null)
                throw new ArgumentNullException("topic");

            _topicRepository.Update(topic);

            //event notification
            _eventPublisher.EntityUpdated(topic);
        }

        #endregion
    }
}
