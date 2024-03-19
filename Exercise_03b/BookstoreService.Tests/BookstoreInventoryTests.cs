namespace PrimeService.Tests;

[TestClass]
public class BookstoreInventoryTests
{
    [TestMethod]
    public void AddBook_BookDidNotExistBefore_ShouldAddBookAndReturnTrue()
    {
        // Arrange
        BookstoreInventory bookstoreInventory = new BookstoreInventory();
        Book book = new Book("12345", "A nice book", "John Doe", 1);
        
        // Act
        var result = bookstoreInventory.AddBook(book);
        var stock = bookstoreInventory.CheckStock(book.ISBN);
        
        // Assert
        Assert.IsTrue(result);
        Assert.AreEqual(stock, 1);
    }

    [TestMethod]
    public void AddBook_BookAlreadyExists_ShouldRestockAndReturnFalse()
    {
        // Arrange
        BookstoreInventory bookstoreInventory = new BookstoreInventory();
        Book book = new Book("12345", "A nice book", "John Doe", 1);
        bookstoreInventory.AddBook(book);
        Book sameBook = new Book(book.ISBN, book.Title, book.Author, 3);

        // Act
        var result = bookstoreInventory.AddBook(sameBook);
        var stock = bookstoreInventory.CheckStock(sameBook.ISBN);
        
        // Assert
        Assert.IsFalse(result);
        Assert.AreEqual(4, stock);
    }
}