﻿using System;
using System.Web.Mvc;
using Rms.Core;
using Rms.Core.Domain.Customers;
 
using Rms.Services.Media;
 

namespace Rms.Web.Controllers
{
    public partial class DownloadController : BasePublicController
    {
        private readonly IDownloadService _downloadService;
         
        private readonly IWorkContext _workContext;

        private readonly CustomerSettings _customerSettings;

        public DownloadController(IDownloadService downloadService,  
             IWorkContext workContext, CustomerSettings customerSettings)
        {
            this._downloadService = downloadService;
          
            this._workContext = workContext;
            this._customerSettings = customerSettings;
        }
        
  
     

        

        public ActionResult GetFileUpload(Guid downloadId)
        {
            var download = _downloadService.GetDownloadByGuid(downloadId);
            if (download == null)
                return Content("Download is not available any more.");

            if (download.UseDownloadUrl)
            {
                //return result
                return new RedirectResult(download.DownloadUrl);
            }
            else
            {
                if (download.DownloadBinary == null)
                    return Content("Download data is not available any more.");

                //return result
                string fileName = !String.IsNullOrWhiteSpace(download.Filename) ? download.Filename : downloadId.ToString();
                string contentType = !String.IsNullOrWhiteSpace(download.ContentType) ? download.ContentType : "application/octet-stream";
                return new FileContentResult(download.DownloadBinary, contentType) { FileDownloadName = fileName + download.Extension };
            }
        }

       
    }
}
