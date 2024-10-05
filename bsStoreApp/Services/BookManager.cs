using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.LinkModels;
using Entities.Models;
using Entities.RequesFeatures;
using Repositories.Contracts;
using Services.Contracts;


namespace Services
{
    public class BookManager : IBookService
    {
        private readonly ICategoryService _categoryService;
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        private readonly IDataShaper<BookDto> _shaper;
        private readonly IBookLinks _bookLinks;

        public BookManager(IRepositoryManager manager, 
            ILoggerService logger, 
            IMapper mapper,  
            IBookLinks bookLinks,
            ICategoryService categoryService)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
            _bookLinks = bookLinks;
            _categoryService = categoryService;
        }


        public async Task<(LinkResponse linkResponse, MetaData metaData)> GetAllBooksAsync(LinkParameters linkParameters, bool trackChanges)
        {
            if (!linkParameters.BookParameters.ValidPriceRange)
                throw new PriceOutofRangeBadRequestException();

            var booksWithMetaData = await _manager
                .Book
                .GetAllBooksAsync(linkParameters.BookParameters, trackChanges);

            var booksDto = _mapper.Map<IEnumerable<BookDto>>(booksWithMetaData);

            var links = _bookLinks.TryGenerateLinks(booksDto, 
                linkParameters.BookParameters.Fields, 
                linkParameters.HttpContext);

            return (linkResponse: links, metaData: booksWithMetaData.MetaData);
        }

        public async Task<BookDto> CreateOneBookAsync(BookDtoForInsertion bookDto)
        {
            var category = await _categoryService.GetOneCategoryByIdAsync(bookDto.CategoryId, false);

            var entity = _mapper.Map<Book>(bookDto);
            entity.CategoryId = bookDto.CategoryId;

            _manager.Book.CreateOneBook(entity);
            await _manager.SaveAsync();
            return _mapper.Map<BookDto>(entity);
        }

        public async Task DeleteOneBookAsync(int id, bool trackChanges)
        {
            var entity = await GetOneBookAndCheckExistence(id, trackChanges);

            _manager.Book.DeleteOneBook(entity);
            await _manager.SaveAsync();
        }

        public async Task<BookDto> GetOneBookByIdAsync(int id, bool trackChanges)
        {
            var book = await GetOneBookAndCheckExistence(id, trackChanges);

            return _mapper.Map<BookDto>(book);
        }

        public async Task UpdateOneBookAsync(int id, BookDtoForUpdate bookDto, bool trackChanges)
        {
            var entity = await _manager.Book.GetOneBooksByIdAsync(id, true);

            //check entity
            if (entity is null)
                throw new BookNotFoundException(id);

            entity = _mapper.Map<Book>(entity);
            _manager.Book.Update(entity);
            await _manager.SaveAsync();
        }

        public async Task<(BookDtoForUpdate bookDtoForUpdate, Book book)> GetOneBookForPatchAsync(int id, bool trackChanges)
        {
            var book = await GetOneBookAndCheckExistence(id, trackChanges);

            var bookDtoForUpdate = _mapper.Map<BookDtoForUpdate>(book);

            return (bookDtoForUpdate, book);
        }

        public async Task SaveChangesForPatchAsync(BookDtoForUpdate bookDtoForUpdate, Book book)
        {
            _mapper.Map(bookDtoForUpdate, book);
            await _manager.SaveAsync();
        }

        private async Task<Book> GetOneBookAndCheckExistence(int id, bool trackChanges)
        {
            var book = await _manager.Book.GetOneBooksByIdAsync(id, trackChanges);
            if (book is null)
                throw new BookNotFoundException(id);
            return book;
        }

        public async Task<List<Book>> GetAllBooksAsync(bool trackChanges)
        {
            var books = await _manager.Book.GetAllBooksAsync(trackChanges);
            return books;

        }

        public async Task<IEnumerable<Book>> GetAllBooksWithDetailsAsync(bool trackChanges)
        {
            return await _manager.Book.GetAllBooksWithDetailsAsync(trackChanges);
        }
    }
}
