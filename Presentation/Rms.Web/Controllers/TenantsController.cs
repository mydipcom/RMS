using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rms.Core.Domain.Tenants;
using Rms.Services.Tenants;
using Rms.Web.Models.Common;
using Rms.Web.Models.Customer;
using Rms.Web.Models.Tenants;
using Rms.Web.Validators.Tenants;

namespace Rms.Web.Controllers
{
    public class TenantsController : BasePublicController
    {
        #region Fields

        private readonly ITenantService _tenantService;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TenantsController"/> class.
        /// </summary>
        /// <param name="tenantService">The tenant service.</param>
        public TenantsController(ITenantService tenantService)
        {
            _tenantService = tenantService;
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
            var data = _tenantService.GetAllTenantss(param.pagecurrent, param.length);
            var dataitems = data.Select(x =>
            {
                var model = new TenantsModel();
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
            var entity = _tenantService.GetTenantById(id);
            var model = new TenantsModel();
            EntityMapToModel(entity, model);
            return Json(model);
        }


        /// <summary>
        /// Creates the or update.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public JsonResult CreateOrUpdate(TenantsModel model)
        {
            var validator = new TenantsValidator();
            var results = validator.Validate(model);

            if (results.IsValid)
            {
                var entity = model.Id == 0 ? new Tenant() : _tenantService.GetTenantById(model.Id);
                ModelMapToEntity(model, entity);
                if (model.Id == 0)
                {
                    entity.CreateDate = DateTime.Now;
                    entity.LastModified = DateTime.Now;
                    entity.StatusChanged = DateTime.Now;
                    _tenantService.InsertTenant(entity);
                }
                else
                {
                    _tenantService.UpdateTenant(entity);
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
            var entity = _tenantService.GetTenantById(id);
            _tenantService.DeleteTenant(entity);
            return Success();
        }

        #endregion

        #region Utilities
        
        protected void ModelMapToEntity(TenantsModel model, Tenant entity)
        {
            entity.TenantName = model.TenantName;
            entity.MappedDomain = model.MappedDomain;
            entity.Version = model.Version;
            entity.Timezone = model.Timezone;
            entity.IsPublic = model.IsPublic;
        }



        protected void EntityMapToModel(Tenant entity, TenantsModel model)
        {
            model.Id = entity.Id;
            model.TenantName = entity.TenantName;
            model.MappedDomain = entity.MappedDomain;
            model.Version = entity.Version;
            model.Timezone = entity.Timezone;
            model.IsPublic = entity.IsPublic;
            model.CreateDate = entity.CreateDate.ToString("yyyy-MM-dd");
        }

        #endregion

    }
}