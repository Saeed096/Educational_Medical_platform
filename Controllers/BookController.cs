using Educational_Medical_platform.DTO.BookDTO;
using Educational_Medical_platform.Helpers;
using Educational_Medical_platform.Models;
using Educational_Medical_platform.Repositories.Implementations;
using Educational_Medical_platform.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shoghlana.Api.Response;
using Shoghlana.Core.Models;

namespace Educational_Medical_platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository BookRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly ISubCategoryRepository subCategoryRepository;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly UserManager<ApplicationUser> userManager;


        public BookController(IBookRepository _BookRepository,
            IWebHostEnvironment _webHostEnvironment,
            UserManager<ApplicationUser> _userManager,
            ICategoryRepository _categoryRepository,
            ISubCategoryRepository _subCategoryRepository
            )
        {
            BookRepository = _BookRepository;
            webHostEnvironment = _webHostEnvironment;
            userManager = _userManager;
            categoryRepository = _categoryRepository;
            subCategoryRepository = _subCategoryRepository;

         
        }

        [HttpGet]
        public ActionResult<GeneralResponse> GetAllBooks()
        {
            try
            {
                List<Book> books = (List<Book>)BookRepository.FindAll();

                List<BookDTO> bookDTOs = books.Select(book => new BookDTO
                {
                    Id = book.Id,
                    Title = book.Title,
                    Description = book.Description,
                    ThumbnailURL = book.ThumbnailURL,
                    Url = book.Url,
                    SubCategoryId = book.SubCategoryId,
                    CategoryId = book.CategoryId,
                    CreatedDate=book.PublishDate,
                    PublisherName = book.PublisherName,
                    PublisherRole = book.PublisherRole,

                }).ToList();

                if (bookDTOs is null )
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

        [HttpGet("{id}")]
        public ActionResult<GeneralResponse> GetBookById(int id)
        {
            try
            {
                Book book = BookRepository.GetById(id);

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
        public async Task <ActionResult<GeneralResponse>> AddBook([FromForm] BookDTO bookDTO)
        {
            try
            {
                string uploadpath = Path.Combine(webHostEnvironment.WebRootPath, "Images","Book");
                string imagename = Guid.NewGuid().ToString() + "_" + bookDTO.Thumbnail.FileName;
                string filepath = Path.Combine(uploadpath, imagename);
                using (FileStream fileStream = new FileStream(filepath, FileMode.Create))
                {
                    bookDTO.Thumbnail.CopyTo(fileStream);
                }
                bookDTO.ThumbnailURL = imagename;
                if (ModelState.IsValid)
                {
                    var existinguser = await userManager.FindByIdAsync(bookDTO.UserID);

                    if (existinguser == null)
                    {
                        return new GeneralResponse
                        {
                            IsSuccess = false,
                            Message = "there is no such user "
                        };
                    }

                    //Check if Category ID and Sub Category Id are Related to Books or not 

                    Category category = categoryRepository.GetById((int)bookDTO.CategoryId);
                    SubCategory subCategory = subCategoryRepository.GetById((int)bookDTO.SubCategoryId);
                    if (category.Type != CategoryType.Books || subCategory.Type != SubCategoryType.Books)
                    {
                        return new GeneralResponse()
                        {
                            IsSuccess = false,
                            Message = $"Category or SubCategory with these ID not related to Books."
                        };

                    }
                    var roles = await userManager.GetRolesAsync(existinguser);

                    Book book = new Book
                    {
                        Title = bookDTO.Title,
                        Description = bookDTO.Description,
                        ThumbnailURL = $"/Images/Book/{imagename}",
                        Url = bookDTO.Url,
                        SubCategoryId = bookDTO.SubCategoryId,
                        CategoryId = bookDTO.CategoryId,
                        PublishDate = bookDTO.CreatedDate,
                        PublisherName=existinguser.UserName,
                        PublisherRole=roles.FirstOrDefault()
                    };
                   
                  Book addedBook = BookRepository.Add(book);

                    BookRepository.save();

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
                        Message = "Book added successfully",
                        Data = addedBookDTO
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
                return  new GeneralResponse
                {
                    IsSuccess = false,
                    Message = $"An error occurred: {ex.Message}"
                };
            }
        }

        [HttpPut("{id}")]
        public ActionResult<GeneralResponse> UpdateBook(int id, [FromForm] BookDTO bookDTO)
        {
            try
            {
                Book existingBook = BookRepository.GetById(id);

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
                    string uploadpath = Path.Combine(webHostEnvironment.WebRootPath, "Images", "Book");
                    string imagename = Guid.NewGuid().ToString() + "_" + bookDTO.Thumbnail.FileName;
                    string filepath = Path.Combine(uploadpath, imagename);
                    using (FileStream fileStream = new FileStream(filepath, FileMode.Create))
                    {
                        bookDTO.Thumbnail.CopyTo(fileStream);
                    }
                    bookDTO.ThumbnailURL = imagename;

                   
                }

                //Check if Category ID and Sub Category Id are Related to Books or not 

                Category category = categoryRepository.GetById((int)bookDTO.CategoryId);
                SubCategory subCategory = subCategoryRepository.GetById((int)bookDTO.SubCategoryId);
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
                    existingBook.ThumbnailURL = $"/Images/Book/{bookDTO.ThumbnailURL}" ?? existingBook.ThumbnailURL;
                    existingBook.Url = bookDTO.Url;
                    existingBook.SubCategoryId = bookDTO.SubCategoryId;
                    existingBook.CategoryId = bookDTO.CategoryId;
                    existingBook.PublisherRole=bookDTO.PublisherRole;
                    existingBook.PublisherName = bookDTO.PublisherName;
                    existingBook.PublishDate = bookDTO.CreatedDate;
                    BookRepository.Update(existingBook);  
                    BookRepository.save();  

                    
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

        [HttpDelete("{id}")]
        public ActionResult<GeneralResponse> DeleteBook(int id)
        {
            try
            {
                 Book existingBook = BookRepository.GetById(id);

                if (existingBook == null)
                {
                    return new GeneralResponse
                    {
                        IsSuccess = false,
                        Message = "Book not found"
                    };
                }

                 BookRepository.Delete(existingBook);
                BookRepository.save();  

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