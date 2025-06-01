using DY.Application.Contract.DTOs;
using DY.Application.Contract.ViewModels.Course;
using DY.Domain.CourseAgg;
using DY.Domain.CourseCategoryAgg;
using Mapster;

namespace DY.Application.Mapper
{
    public class CourseMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            #region Entity → Create ViewModel
            config.NewConfig<Course, Create_CorceVM>()
                .Map(dest => dest.SelectedCategoryId, src => (int)src.CategoryId)
                .Map(dest => dest.IsSucceeded, src => true)
                .Map(dest => dest.Message, src => "Course created successfully")
                .Ignore(dest => dest.ImageFile);
            #endregion

            #region Entity → Update ViewModel
            config.NewConfig<Course, Update_CourseVM>()
                .Map(dest => dest.SelectedCategoryId, src => (int)src.CategoryId)
                .Map(dest => dest.Title, src => src.Title)
                .Map(dest => dest.Slug, src => src.Slug)
                .Map(dest => dest.Price, src => src.Price)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.CourseUrl, src => src.CourseUrl)
                .Map(dest => dest.SiteSource, src => src.SiteSource)
                .Map(dest => dest.IsFree, src => src.IsFree)
                .Map(dest => dest.IsFinished, src => src.IsFinished)
                .Map(dest => dest.MetaTitle, src => src.MetaTitle)
                .Map(dest => dest.MetaDescription, src => src.MetaDescription)
                .Map(dest => dest.MetaKeyword, src => src.MetaKeyword)
                .Map(dest => dest.IsSucceeded, src => true)
                .Map(dest => dest.Message, src => "Course loaded successfully")
                .Ignore(dest => dest.ImageFile);
            #endregion

            #region Create ViewModel → Dto
            config.NewConfig<Create_CorceVM, CourseCreateDto>()
                .Map(dest => dest.ImageUrl, src => src.ImageFile != null ? src.ImageFile.FileName : string.Empty)
                .Map(dest => dest.Title, src => src.Title)
                .Map(dest => dest.Price, src => src.Price)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.CourseUrl, src => src.CourseUrl)
                .Map(dest => dest.SiteSource, src => src.SiteSource)
                .Map(dest => dest.Slug, src => src.Slug)
                .Map(dest => dest.IsFree, src => src.IsFree)
                .Map(dest => dest.IsFinished, src => src.IsFinished)
                .Map(dest => dest.MetaTitle, src => src.MetaTitle)
                .Map(dest => dest.MetaDescription, src => src.MetaDescription)
                .Map(dest => dest.MetaKeyword, src => src.MetaKeyword)
                .Map(dest => dest.SelectedCategoryId, src => src.SelectedCategoryId);
            #endregion

            #region Update ViewModel → Dto
            config.NewConfig<Update_CourseVM, CourseUpdateDto>()
                .Map(dest => dest.ImageUrl, src => src.ImageFile != null ? src.ImageFile.FileName : string.Empty)
                .Map(dest => dest.Title, src => src.Title)
                .Map(dest => dest.Price, src => src.Price)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.CourseUrl, src => src.CourseUrl)
                .Map(dest => dest.SiteSource, src => src.SiteSource)
                .Map(dest => dest.Slug, src => src.Slug)
                .Map(dest => dest.IsFree, src => src.IsFree)
                .Map(dest => dest.IsFinished, src => src.IsFinished)
                .Map(dest => dest.MetaTitle, src => src.MetaTitle)
                .Map(dest => dest.MetaDescription, src => src.MetaDescription)
                .Map(dest => dest.MetaKeyword, src => src.MetaKeyword)
                .Map(dest => dest.SelectedCategoryId, src => src.SelectedCategoryId);
            #endregion

            #region CourseCreateDto → Course (NEW INSTANCE)
            config.NewConfig<CourseCreateDto, Course>()
               .MapWith(src => new Course(
                   src.Title,
                   src.Price,
                   src.Description,
                   src.CourseUrl,
                   src.SiteSource,
                   src.Slug,
                   src.ImageUrl,
                   src.ThumbnailUrl ?? string.Empty,
                   src.IsFree,
                   src.IsFinished,
                   src.MetaTitle ?? string.Empty,
                   src.MetaDescription ?? string.Empty,
                   src.MetaKeyword ?? string.Empty,
                   src.SelectedCategoryId
               ));
            #endregion

            #region CourseUpdateDto → Course (NEW INSTANCE)
            config.NewConfig<CourseUpdateDto, Course>()
                .MapWith(src => new Course(
                    src.Title,
                    src.Price,
                    src.Description,
                    src.CourseUrl,
                    src.SiteSource,
                    src.Slug,
                    src.ImageUrl ?? string.Empty,
                    src.ThumbnailUrl ?? string.Empty,
                    src.IsFree,
                    src.IsFinished,
                    src.MetaTitle ?? string.Empty,
                    src.MetaDescription ?? string.Empty,
                    src.MetaKeyword ?? string.Empty,
                    src.SelectedCategoryId
                ));
            #endregion

            #region CourseUpdateDto → Course (UPDATE EXISTING INSTANCE)
            config.NewConfig<CourseUpdateDto, Course>()
                        .IgnoreNullValues(true)
                        .Map(dest => dest.Title, src => src.Title)
                        .Map(dest => dest.Price, src => src.Price)
                        .Map(dest => dest.Description, src => src.Description)
                        .Map(dest => dest.CourseUrl, src => src.CourseUrl)
                        .Map(dest => dest.SiteSource, src => src.SiteSource)
                        .Map(dest => dest.Slug, src => src.Slug)
                        .Ignore(dest => dest.ImageUrl)         // 👈 جلوگیری از بازنویسی دستی
                        .Ignore(dest => dest.ThumbnailUrl)     // 👈 جلوگیری از بازنویسی دستی
                        .Map(dest => dest.IsFree, src => src.IsFree)
                        .Map(dest => dest.IsFinished, src => src.IsFinished)
                        .Map(dest => dest.MetaTitle, src => src.MetaTitle)
                        .Map(dest => dest.MetaDescription, src => src.MetaDescription)
                        .Map(dest => dest.MetaKeyword, src => src.MetaKeyword)
                        .Map(dest => dest.CategoryId, src => src.SelectedCategoryId);


            #endregion

            #region Course → List_CourseVM
            config.NewConfig<Course, List_CourseVM>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.SelectedCategoryId, src => (int)src.CategoryId)
                .Map(dest => dest.Title, src => src.Title)
                .Map(dest => dest.Slug, src => src.Slug)
                .Map(dest => dest.Price, src => src.Price)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.CourseUrl, src => src.CourseUrl)
                .Map(dest => dest.SiteSource, src => src.SiteSource)
                .Map(dest => dest.ImageUrl, src => src.ImageUrl)
                .Map(dest => dest.IsFree, src => src.IsFree)
                .Map(dest => dest.IsFinished, src => src.IsFinished)
                .Map(dest => dest.MetaTitle, src => src.MetaTitle)
                .Map(dest => dest.MetaDescription, src => src.MetaDescription)
                .Map(dest => dest.MetaKeyword, src => src.MetaKeyword)
                .Map(dest => dest.IsSucceeded, src => true)
                .Map(dest => dest.Message, src => "Course loaded successfully");
            #endregion

        }
    }
}

