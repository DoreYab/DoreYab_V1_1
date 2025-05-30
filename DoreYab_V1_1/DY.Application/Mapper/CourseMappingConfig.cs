using DY.Application.Contract.DTOs;
using DY.Application.Contract.ViewModels.Course;
using DY.Domain.CourseAgg;
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
                .Ignore(dest => dest.ImageFile) // فایل جداگانه هنگام آپلود دستی ست میشه
                .Map(dest => dest.IsFree, src => src.IsFree)
                .Map(dest => dest.IsFinished, src => src.IsFinished)
                .Map(dest => dest.MetaTitle, src => src.MetaTitle)
                .Map(dest => dest.MetaDescription, src => src.MetaDescription)
                .Map(dest => dest.MetaKeyword, src => src.MetaKeyword)
                .Map(dest => dest.IsSucceeded, src => true)
                .Map(dest => dest.Message, src => "Course loaded successfully");
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

            #region CourseCreateDto → Course
            config.NewConfig<CourseCreateDto, Course>()
                .ConstructUsing(src => new Course(
                    src.Title,
                    src.Price,
                    src.Description,
                    src.CourseUrl,
                    src.SiteSource,
                    src.Slug,
                    src.ImageFile,
                    src.IsFree,
                    src.IsFinished,
                    src.MetaTitle ?? string.Empty,
                    src.MetaDescription ?? string.Empty,
                    src.MetaKeyword ?? string.Empty,
                    src.SelectedCategoryId
                ));
            #endregion

            // Update ViewModel → Entity (اگر نیاز داری)
            config.NewConfig<Update_CourseVM, Course>()
                .ConstructUsing(src => new Course(
                    src.Title,
                    src.Price,
                    src.Description,
                    src.CourseUrl,
                    src.SiteSource,
                    src.Slug,
                    src.ImageUrl,
                    src.IsFree,
                    src.IsFinished,
                    src.MetaTitle ?? string.Empty,
                    src.MetaDescription ?? string.Empty,
                    src.MetaKeyword ?? string.Empty,
                    src.SelectedCategoryId
                ));

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

            #region Course → Create_CorceVM
            config.NewConfig<Course, Create_CorceVM>()
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
                .Map(dest => dest.SelectedCategoryId, src => (int)src.CategoryId)
                .Ignore(dest => dest.ImageFile)
                .Ignore(dest => dest.CourseCategories)
                .Ignore(dest => dest.IsSucceeded)
                .Ignore(dest => dest.Message);
            #endregion


        }
    }
}

