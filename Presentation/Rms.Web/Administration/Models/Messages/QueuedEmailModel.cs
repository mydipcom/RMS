﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Rms.Admin.Validators.Messages;
using Rms.Web.Framework;
using Rms.Web.Framework.Mvc;

namespace Rms.Admin.Models.Messages
{
    [Validator(typeof(QueuedEmailValidator))]
    public partial class QueuedEmailModel: BaseNopEntityModel
    {
        [NopResourceDisplayName("Admin.System.QueuedEmails.Fields.Id")]
        public override int Id { get; set; }

        [NopResourceDisplayName("Admin.System.QueuedEmails.Fields.Priority")]
        public int Priority { get; set; }

        [NopResourceDisplayName("Admin.System.QueuedEmails.Fields.From")]
        [AllowHtml]
        public string From { get; set; }

        [NopResourceDisplayName("Admin.System.QueuedEmails.Fields.FromName")]
        [AllowHtml]
        public string FromName { get; set; }

        [NopResourceDisplayName("Admin.System.QueuedEmails.Fields.To")]
        [AllowHtml]
        public string To { get; set; }

        [NopResourceDisplayName("Admin.System.QueuedEmails.Fields.ToName")]
        [AllowHtml]
        public string ToName { get; set; }

        [NopResourceDisplayName("Admin.System.QueuedEmails.Fields.ReplyTo")]
        [AllowHtml]
        public string ReplyTo { get; set; }

        [NopResourceDisplayName("Admin.System.QueuedEmails.Fields.ReplyToName")]
        [AllowHtml]
        public string ReplyToName { get; set; }

        [NopResourceDisplayName("Admin.System.QueuedEmails.Fields.CC")]
        [AllowHtml]
        public string CC { get; set; }

        [NopResourceDisplayName("Admin.System.QueuedEmails.Fields.Bcc")]
        [AllowHtml]
        public string Bcc { get; set; }

        [NopResourceDisplayName("Admin.System.QueuedEmails.Fields.Subject")]
        [AllowHtml]
        public string Subject { get; set; }

        [NopResourceDisplayName("Admin.System.QueuedEmails.Fields.Body")]
        [AllowHtml]
        public string Body { get; set; }

        [NopResourceDisplayName("Admin.System.QueuedEmails.Fields.AttachmentFilePath")]
        [AllowHtml]
        public string AttachmentFilePath { get; set; }

        [NopResourceDisplayName("Admin.System.QueuedEmails.Fields.CreatedOn")]
        public DateTime CreatedOn { get; set; }

        [NopResourceDisplayName("Admin.System.QueuedEmails.Fields.SentTries")]
        public int SentTries { get; set; }

        [NopResourceDisplayName("Admin.System.QueuedEmails.Fields.SentOn")]
        [DisplayFormat(DataFormatString="{0}", NullDisplayText="Not sent yet")]
        public DateTime? SentOn { get; set; }

        [NopResourceDisplayName("Admin.System.QueuedEmails.Fields.EmailAccountName")]
        [AllowHtml]
        public string EmailAccountName { get; set; }
    }
}