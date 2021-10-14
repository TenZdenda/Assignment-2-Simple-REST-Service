using System;
using System.Collections.Generic;
using BookLibrary;

namespace Simple_CRUD_API.Managers
{
    public class BookManager
    {
        public List<Book> Books = new List<Book>()
        {
            new Book("ALCHYMIE", "Rory Sutherland", 400, 978807111),
            new Book("Spotify", "Sven Carlsson", 256, 978807222),
            new Book("Konec stárnutí", "David Sinclair", 384, 978807333),
            new Book("Stát se investorem", "Mikuláš Splítek", 320, 978807444)
        };
        
        public IEnumerable<Book> AllBooks()
        {
            return Books;
        }

        public Book SpecificBook (string isbn13)
        {
            Book book = Books.Find(book => book.ISBN13.Equals(isbn13));
            
            return book;
        }

        public Book NewBook(Book newBook)
        {
            Books.Add(newBook);
            return newBook;
        }

        public Book UpdateBook(string isbn13, Book update )
        {
            Book book = Books.Find(book => book.ISBN13.Equals(isbn13));
            
            if (book.Equals(null))
            {
                return null;
            }
            
            book.Title = update.Title;
            book.Author = update.Author;
            book.PageNumber = update.PageNumber;
            book.ISBN13 = update.ISBN13;
            
            return book;
        }

        public Book DeleteBook(string isbn13)
        {
            Book book = Books.Find(book => book.ISBN13.Equals(isbn13));

            if (book.Equals(null))
            {
                return null;
            }
            
            Books.Remove(book);
            return book;
        }
    }
}