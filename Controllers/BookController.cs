using Educational_Medical_platform.DTO.Blog;
using Educational_Medical_platform.DTO.BookDTO;
using Educational_Medical_platform.Helpers;
using Educational_Medical_platform.Models;
using Educational_Medical_platform.Repositories.Implementations;
using Educational_Medical_platform.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shoghlana.Api.Response;
using Shoghlana.Core.DTO;
using Shoghlana.Core.Models;

namespace Educational_Medical_platform.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly string _imagesPath;
        private readonly long _maxImageSize;


        public BookController(IBookRepository BookRepository,
            IWebHostEnvironment webHostEnvironment,
            UserManager<ApplicationUser> userManager,
            ICategoryRepository categoryRepository,
            ISubCategoryRepository subCategoryRepository
            )
        {
            _bookRepository = BookRepository;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
            _categoryRepository = categoryRepository;
            _subCategoryRepository = subCategoryRepository;

            _maxImageSize = StorageInfo.MaxImageSize;
            _imagesPath = StorageInfo.BooksImagesPath;
        }

        [HttpGet]
        public ActionResult<GeneralResponse> GetAllBooks()
        {
            try
            {
                List<Book> books = (List<Book>)_bookRepository.FindAll();

                List<BookDTO> bookDTOs = books.Select(book => new BookDTO
                {
                    Id = book.Id,
                    Title = book.Title,
                    Description = book.Description,
                    ThumbnailURL = book.ThumbnailURL,
                    Url = book.Url,
                    SubCategoryId = book.SubCategoryId,
                    CategoryId = book.CategoryId,
                    CreatedDate = book.PublishDate,
                    PublisherName = book.PublisherName,
                    PublisherRole = book.PublisherRole,

                }).ToList();

                if (bookDTOs is null)
                {
                    return new GeneralResponse()
                    {
                        IsSuccess = false,
                        Message = "There Is no Books Yet."
                    };
                }

                return new GeneralResponse()
                {
                    IsSuccess = true,
                    Data = bookDTOs,
                };

            }
            catch (Exception ex)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = $"An error occurred: {ex.Message}"
                };
            }


        }

        [HttpGet("GetAllBooksPaginated")]
        public ActionResult<GeneralResponse> GetAllBooksPaginated(int page = 1, int pageSize = 10)
        {
            try
            {
                var booksPaginatedList = _bookRepository.FindPaginated(page: page, pageSize: pageSize);

                if (booksPaginatedList == null || !booksPaginatedList.Items.Any())
                {
                    return new GeneralResponse
                    {
                        IsSuccess = true,
                        Data = new List<BookDTO>(),
                        Message = "There are no books available."
                    };
                }

                var bookDTOs = booksPaginatedList.Items.Select(book => new BookDTO()
                {
                    Id = book.Id,
                    Title = book.Title,
                    Description = book.Description,
                    ThumbnailURL = book.ThumbnailURL,
                    Url = book.Url,
                    SubCategoryId = book.SubCategoryId,
                    CategoryId = book.CategoryId,
                    CreatedDate = book.PublishDate,
                    PublisherName = book.PublisherName,
                    PublisherRole = book.PublisherRole,
                }).ToList();

                return new GeneralResponse
                {
                    IsSuccess = true,
                    Data = new PaginatedListDTO<BookDTO>
                    {
                        CurrentPage = booksPaginatedList.CurrentPage,
                        Items = bookDTOs,
                        TotalItems = booksPaginatedList.TotalItems,
                        TotalPages = booksPaginatedList.TotalPages,
                    },
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = $"An error occurred: {ex.Message}"
                };
            }
        }

        [HttpGet("GetBooksByCategoryPaginated/{id:int}")]
        public ActionResult<GeneralResponse> GetBooksByCategoryPaginated(int id , int page = 1, int pageSize = 10)
        {
            try
            {
                var booksPaginatedList = _bookRepository.FindPaginated(page: page, pageSize: pageSize , criteria: book => book.CategoryId == id);

                if (booksPaginatedList == null || !booksPaginatedList.Items.Any())
                {
                    return new GeneralResponse
                    {
                        IsSuccess = true,
                        Data = new List<BookDTO>(),
                        Message = "There are no books available in this category"
                    };
                }

                var bookDTOs = booksPaginatedList.Items.Select(book => new BookDTO()
                {
                    Id = book.Id,
                    Title = book.Title,
                    Description = book.Description,
                    ThumbnailURL = book.ThumbnailURL,
                    Url = book.Url,
                    SubCategoryId = book.SubCategoryId,
                    CategoryId = book.CategoryId,
                    CreatedDate = book.PublishDate,
                    PublisherName = book.PublisherName,
                    PublisherRole = book.PublisherRole,
                }).ToList();


                return new GeneralResponse
                {
                    IsSuccess = true,
                    Data = new PaginatedListDTO<BookDTO>
                    {
                        CurrentPage = booksPaginatedList.CurrentPage,
                        Items = bookDTOs,
                        TotalItems = booksPaginatedList.TotalItems,
                        TotalPages = booksPaginatedList.TotalPages,
                    },
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = $"An error occurred: {ex.Message}"
                };
            }
        }

        [HttpGet("GetBooksBySubCategoryPaginated/{id:int}")]
        public ActionResult<GeneralResponse> GetBooksBySubCategoryPaginated(int id, int page = 1, int pageSize = 10)
        {
            try
            {
                var booksPaginatedList = _bookRepository.FindPaginated(page: page, pageSize: pageSize, criteria: book => book.SubCategoryId == id);

                if (booksPaginatedList == null || !booksPaginatedList.Items.Any())
                {
                    return new GeneralResponse
                    {
                        IsSuccess = true,
                        Data = new List<BookDTO>(),
                        Message = "There are no books available in this subcategory"
                    };
                }

                var bookDTOs = booksPaginatedList.Items.Select(book => new BookDTO()
                {
                    Id = book.Id,
                    Title = book.Title,
                    Description = book.Description,
                    ThumbnailURL = book.ThumbnailURL,
                    Url = book.Url,
                    SubCategoryId = book.SubCategoryId,
                    CategoryId = book.CategoryId,
                    CreatedDate = book.PublishDate,
                    PublisherName = book.PublisherName,
                    PublisherRole = book.PublisherRole,
                }).ToList();


                return new GeneralResponse
                {
                    IsSuccess = true,
                    Data = new PaginatedListDTO<BookDTO>
                    {
                        CurrentPage = booksPaginatedList.CurrentPage,
                        Items = bookDTOs,
                        TotalItems = booksPaginatedList.TotalItems,
                        TotalPages = booksPaginatedList.TotalPages,
                    },
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = $"An error occurred: {ex.Message}"
                };
            }
        }
        [HttpGet("{id:int}")]
        public ActionResult<GeneralResponse> GetBookById(int id)
        {
            try
            {
                Book book = _bookRepository.GetById(id);

                if (book == null)
                {
                    return new GeneralResponse
                    {
                        IsSuccess = false,
                        Message = "Book not found"
                    };
                }

                BookDTO bookDTO = new BookDTO
                {
                    Id = book.Id,
                    Title = book.Title,
                    Description = book.Description,
                    ThumbnailURL = book.ThumbnailURL,
                    Url = book.Url,
                    SubCategoryId = book.SubCategoryId,
                    CategoryId = book.CategoryId,
                    CreatedDate = book.PublishDate,
                    PublisherName = book.PublisherName,
                    PublisherRole = book.PublisherRole,

                };

                return new GeneralResponse
                {
                    IsSuccess = true,
                    Message = "Book retrieved successfully",
                    Data = bookDTO
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = $"An error occurred: {ex.Message}"
                };
            }
        }

        [HttpPost]
        public async Task<ActionResult<GeneralResponse>> AddBook([FromForm] AddBookDTO bookDTO)
        {
            if (!ModelState.IsValid)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = "Invalid Model State",
                    Data = ModelState
                };
            }

            var user = await _userManager.FindByIdAsync(bookDTO.UserID);
            if (user is null)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = $"No User Found with this ID : {bookDTO.UserID}"
                };
            }

            if (bookDTO.CategoryId is null && bookDTO.SubCategoryId is null)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = $"the book must be related to category or subcategory !"
                };
            }

            Category? category = null;
            if (bookDTO.CategoryId is not null)
            {
                category = _categoryRepository.GetById((int)bookDTO.CategoryId);

                if (category is null)
                {
                    return new GeneralResponse
                    {
                        IsSuccess = false,
                        Message = $"There is no Category Found with this ID : {bookDTO.CategoryId}"
                    };
                }

                if (category.Type != CategoryType.Books)
                {
                    return new GeneralResponse
                    {
                        IsSuccess = false,
                        Message = $"The Book must added to books categories only , this category type is : {category.Type.GetDisplayName()!}"
                    };
                }
            }

            SubCategory? subCategory = null;
            if (bookDTO.SubCategoryId is not null)
            {
                subCategory = _subCategoryRepository.GetById((int)bookDTO.SubCategoryId);

                if (subCategory is null)
                {
                    return new GeneralResponse
                    {
                        IsSuccess = false,
                        Message = $"There is no subCategory Found with this ID : {bookDTO.SubCategoryId}"
                    };
                }

                if (subCategory.Type != SubCategoryType.Books)
                {
                    return new GeneralResponse
                    {
                        IsSuccess = false,
                        Message = $"The Book must added to books subCategories only , this subCategory type is : {subCategory.Type.GetDisplayName()!}"
                    };
                }
            }

            if (bookDTO.SubCategoryId is not null && bookDTO.CategoryId is not null)
            {
                if (subCategory?.CategoryId != category?.Id)
                {
                    return new GeneralResponse
                    {
                        IsSuccess = false,
                        Message = $"This subcategory witht ID : {subCategory?.Id} is not related to the category with ID : {category?.Id}"
                    };
                }
            }

            var fileName = string.Empty;

            if (bookDTO.Thumbnail != null)
            {
                // Validate that the file is an image by checking the MIME type
                if (!bookDTO.Thumbnail.ContentType.StartsWith("image/"))
                {
                    return new GeneralResponse()
                    {
                        IsSuccess = false,
                        Message = "The uploaded file is not a valid image.",
                        Status = 409
                    };
                }

                // Validate image size (e.g., max 2MB)
                if (bookDTO.Thumbnail.Length > _maxImageSize)
                {
                    return new GeneralResponse()
                    {
                        IsSuccess = false,
                        Message = "Image size exceeds the maximum allowed size of 2MB.",
                        Status = 410
                    };
                }

                fileName = $"{Path.GetFileNameWithoutExtension(bookDTO.Thumbnail.FileName)}_{Guid.NewGuid()}{Path.GetExtension(bookDTO.Thumbnail.FileName)}";
                var filePath = Path.Combine(_imagesPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await bookDTO.Thumbnail.CopyToAsync(stream);
                }

                bookDTO.Thumbnail = null; // Remove the image from DTO after saving
            }

            var roles = await _userManager.GetRolesAsync(user);

            Book book = new Book
            {
                Title = bookDTO.Title,
                Description = bookDTO.Description,
                ThumbnailURL = $"/Images/Book/{fileName}",
                Url = bookDTO.Url,
                SubCategoryId = bookDTO.SubCategoryId,
                CategoryId = bookDTO?.CategoryId ?? subCategory?.CategoryId,
                PublishDate = bookDTO?.CreatedDate ?? null,
                PublisherName = $"{user.FirstName} {user.LastName}",
                PublisherRole = roles.FirstOrDefault(),
                UserId = user.Id,
            };

            Book addedBook = _bookRepository.Add(book);
            _bookRepository.Save();

            BookDTO addedBookDTO = new BookDTO
            {
                Id = addedBook.Id,
                Title = addedBook.Title,
                Description = addedBook.Description,
                ThumbnailURL = addedBook.ThumbnailURL,
                Url = addedBook.Url,
                SubCategoryId = addedBook.SubCategoryId,
                CategoryId = addedBook.CategoryId
            };

            return new GeneralResponse
            {
                IsSuccess = true,
                Message = "Book Added Successfully",
                Data = addedBookDTO
            };
        }

        [HttpPut("{id:int}")]
        public ActionResult<GeneralResponse> UpdateBook(int id, [FromForm] BookDTO bookDTO)
        {
            try
            {
                Book existingBook = _bookRepository.GetById(id);

                if (existingBook == null)
                {
                    return new GeneralResponse
                    {
                        IsSuccess = false,
                        Message = "Book not found"
                    };
                }

                if (bookDTO.Thumbnail != null)
                {
                    string uploadpath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", "Book");
                    string imagename = Guid.NewGuid().ToString() + "_" + bookDTO.Thumbnail.FileName;
                    string filepath = Path.Combine(uploadpath, imagename);
                    using (FileStream fileStream = new FileStream(filepath, FileMode.Create))
                    {
                        bookDTO.Thumbnail.CopyTo(fileStream);
                    }
                    bookDTO.ThumbnailURL = imagename;


                }

                //Check if Category ID and Sub Category Id are Related to Books or not 

                Category category = _categoryRepository.GetById((int)bookDTO.CategoryId);
                SubCategory subCategory = _subCategoryRepository.GetById((int)bookDTO.SubCategoryId);
                if (category.Type != CategoryType.Books || subCategory.Type != SubCategoryType.Books)
                {
                    return new GeneralResponse()
                    {
                        IsSuccess = false,
                        Message = $"Category or SubCategory with these ID not related to Books."
                    };

                }

                if (ModelState.IsValid)
                {
                    existingBook.Title = bookDTO.Title;
                    existingBook.Description = bookDTO.Description;
                    if (bookDTO.Thumbnail != null)
                    {
                        existingBook.ThumbnailURL = $"/Images/Book/{bookDTO.ThumbnailURL}";
                    }
                    existingBook.Url = bookDTO.Url;
                    existingBook.SubCategoryId = bookDTO.SubCategoryId;
                    existingBook.CategoryId = bookDTO.CategoryId;
                    existingBook.PublisherRole = bookDTO.PublisherRole ?? existingBook.PublisherRole;
                    existingBook.PublisherName = bookDTO.PublisherName ?? existingBook.PublisherName;
                    existingBook.PublishDate = bookDTO.CreatedDate;
                    _bookRepository.Update(existingBook);
                    _bookRepository.Save();


                    BookDTO updatedBookDTO = new BookDTO
                    {
                        Id = existingBook.Id,
                        Title = existingBook.Title,
                        Description = existingBook.Description,
                        ThumbnailURL = existingBook.ThumbnailURL,
                        Url = existingBook.Url,
                        SubCategoryId = existingBook.SubCategoryId,
                        CategoryId = existingBook.CategoryId,
                        PublisherRole = existingBook.PublisherRole,
                        PublisherName = existingBook.PublisherName,
                        CreatedDate = existingBook.PublishDate,
                    };

                    return new GeneralResponse
                    {
                        IsSuccess = true,
                        Message = "Book updated successfully",
                        Data = updatedBookDTO
                    };
                }
                else
                {
                    return new GeneralResponse
                    {
                        IsSuccess = false,
                        Message = "Invalid book data"
                    };
                }
            }
            catch (Exception ex)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = $"An error occurred: {ex.Message}"
                };
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<GeneralResponse> DeleteBook(int id)
        {
            try
            {
                Book existingBook = _bookRepository.GetById(id);

                if (existingBook == null)
                {
                    return new GeneralResponse
                    {
                        IsSuccess = false,
                        Message = "Book not found"
                    };
                }

                _bookRepository.Delete(existingBook);
                _bookRepository.Save();

                return new GeneralResponse
                {
                    IsSuccess = true,
                    Message = "Book deleted successfully"
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = $"An error occurred: {ex.Message}"
                };
            }
        }
    }
}