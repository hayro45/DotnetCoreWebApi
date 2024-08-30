using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        public RepositoryContext _context;
        private readonly Lazy<Contracts.IQueryable> _bookRepository;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _bookRepository = new Lazy<Contracts.IQueryable>(()=>new BookRepository(_context));
        }

        public Contracts.IQueryable Book => _bookRepository.Value;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
