﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Rms.Web.Framework;
using Rms.Web.Framework.Mvc;

namespace Rms.Admin.Models.Messages
{
    public partial class QueuedEmailListModel : BaseNopModel
    {
        public QueuedEmailListModel()
        {
            SearchLoadNotSent = true;
            SearchMaxSentTries = 10;
        }

        [NopResourceDisplayName("Admin.System.QueuedEmails.List.StartDate")]
        [UIHint("DateNullable")]
        public DateTime? SearchStartDate { get; set; }

        [NopResourceDisplayName("Admin.System.QueuedEmails.List.EndDate")]
        [UIHint("DateNullable")]
        public DateTime? SearchEndDate { get; set; }

        [NopResourceDisplayName("Admin.System.QueuedEmails.List.FromEmail")]
        [AllowHtml]
        public string SearchFromEmail { get; set; }

        [NopResourceDisplayName("Admin.System.QueuedEmails.List.ToEmail")]
        [AllowHtml]
        public string SearchToEmail { get; set; }

        [NopResourceDisplayName("Admin.System.QueuedEmails.List.LoadNotSent")]
        public bool SearchLoadNotSent { get; set; }

        [NopResourceDisplayName("Admin.System.QueuedEmails.List.MaxSentTries")]
        public int SearchMaxSentTries { get; set; }

        [NopResourceDisplayName("Admin.System.QueuedEmails.List.GoDirectlyToNumber")]
        public int GoDirectlyToNumber { get; set; }
    }
}