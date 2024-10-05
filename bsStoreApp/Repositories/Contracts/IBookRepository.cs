﻿using Entities.Models;
using Entities.RequesFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
        Task<PagedList<Book>> GetAllBooksAsync(BookParameters bookParameters,
            bool trackChanges);
        Task<Book> GetOneBooksByIdAsync(int id, bool trackChanges);
        
        void CreateOneBook(Book book);
        void UpdateOneBook(Book book);
        void DeleteOneBook(Book book);

        Task<List<Book>> GetAllBooksAsync(bool trackChanges);

        Task<IEnumerable<Book>> GetAllBooksWithDetailsAsync(bool trackChanges);
    }
}
