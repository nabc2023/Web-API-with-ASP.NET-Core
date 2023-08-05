// Assuming you have a Book class with properties like Id, Title, Author, etc.

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private List<Book> books = new List<Book>(); // In a real application, you'd use a database.

    [HttpGet]
    public IActionResult GetAllBooks()
    {
        return Ok(books);
    }

    [HttpGet("{id}")]
    public IActionResult GetBook(int id)
    {
        var book = books.Find(b => b.Id == id);
        if (book == null)
            return NotFound();

        return Ok(book);
    }

    [HttpPost]
    public IActionResult AddBook(Book book)
    {
        // In a real application, you'd validate and save the book to a database.
        books.Add(book);

        return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id, Book updatedBook)
    {
        var book = books.Find(b => b.Id == id);
        if (book == null)
            return NotFound();

        book.Title = updatedBook.Title;
        book.Author = updatedBook.Author;
        // Update other properties as needed.

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        var book = books.Find(b => b.Id == id);
        if (book == null)
            return NotFound();

        books.Remove(book);
        return NoContent();
    }
}
