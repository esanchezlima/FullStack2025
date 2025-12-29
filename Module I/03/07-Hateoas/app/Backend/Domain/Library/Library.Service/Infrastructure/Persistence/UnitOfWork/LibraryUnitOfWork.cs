using Library.Service.Domain.Authors.Interfaces;
using Library.Service.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Infrastructure.Persistence.UnitOfWork
{
    public class LibraryUnitOfWork: UnitOfWork
    {
        public  IAuthorRepository Authors { get; }
        public IBookRepository Books { get; }
        public LibraryContext _context { get; }

        public LibraryUnitOfWork(
            LibraryContext context,
            IAuthorRepository authorRepository,
            IBookRepository bookRepository
        ) :base(context)
        {
            _context = context;
            Authors = authorRepository;
            Books = bookRepository;
        }
    }
}
