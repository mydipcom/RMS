using FluentValidation;
using Rms.Services.Localization;
using Rms.Web.Models.Blogs;

namespace Rms.Web.Validators.Blogs
{
    public class BlogPostValidator : AbstractValidator<BlogPostModel>
    {
        public BlogPostValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.AddNewComment.CommentText).NotEmpty().WithMessage(localizationService.GetResource("Blog.Comments.CommentText.Required")).When(x => x.AddNewComment != null);
        }}
}