using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rms.Core.Domain.Common;
using Rms.Services.Common;
using Rms.Web.Models.Common;
using Rms.Web.Models.Customer;
using Rms.Web.Models.Industry;
using Rms.Web.Validators.Industry;

namespace Rms.Web.Controllers
{
    public class IndustryController : BasePublicController
    {
        #region Fields

        private readonly IIndustryService _industryService;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="IndustryController"/> class.
        /// </summary>
        /// <param name="industryService">The industry service.</param>
        public IndustryController(IIndustryService industryService)
        {
            _industryService = industryService;
        }

        #endregion


        #region Methods


        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// Lists the specified parameter.
        /// </summary>
        /// <param name="param">The parameter.</param>
        /// <returns></returns>
        public JsonResult List(DataTableParameter param)
        {
            var data = _industryService.GetAllIndustrys(param.pagecurrent, param.length);
            var dataitems = data.Select(x =>
            {
                var model = new IndustryModel();
                EntityMapToModel(x, model);
                return model;
            });

            return Json(new
            {
                param.draw,
                data = dataitems,
                recordsTotal = data.TotalCount,
                recordsFiltered = data.TotalCount
            }, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// Gets the entity by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public JsonResult GetEntityById(int id)
        {
            var entity = _industryService.GetIndustryById(id);
            var model = new IndustryModel();
            EntityMapToModel(entity, model);
            return Json(model);
        }


        /// <summary>
        /// Creates the or update.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public JsonResult CreateOrUpdate(IndustryModel model)
        {
            var validator = new IndustryValidator();
            var results = validator.Validate(model);

            if (results.IsValid)
            {
                var entity = model.Id == 0 ? new Industry() : _industryService.GetIndustryById(model.Id);
                ModelMapToEntity(model, entity);
                if (model.Id == 0)
                {
                    _industryService.InsertIndustry(entity);
                }
                else
                {
                    _industryService.UpdateIndustry(entity);
                }
                return Success();
            }
            var failmsg = results.Errors.ToList().Select(t => t.ErrorMessage).ToList();
            return Fail(failmsg);
        }



        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public JsonResult Delete(int id)
        {
            var entity = _industryService.GetIndustryById(id);
            _industryService.DeleteIndustry(entity);
            return Success();
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Models the map to entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="entity">The entity.</param>
        protected void ModelMapToEntity(IndustryModel model, Industry entity)
        {
            entity.Id = model.Id;
            entity.Name = model.Name;
            entity.DisplayOrder = model.DisplayOrder;
        }


        /// <summary>
        /// Entities the map to model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="model">The model.</param>
        protected void EntityMapToModel(Industry entity, IndustryModel model)
        {
            model.Id = entity.Id;
            model.Name = entity.Name;
            model.DisplayOrder = entity.DisplayOrder;
        }

        #endregion

    }
}