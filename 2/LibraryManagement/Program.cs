using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace LibraryManagement;

//Book Class
public class Book 
{
    //Fields that give the books characteristics
    public string Title;
    public string Author;
    public string Genre;

    //Constructor of Book object
    public Book(string title, string author, string genre) 
    {
        Title = title;
        Author = author;
        Genre = genre;
    }
    //Method that displays the books characteristics
    public void DisplayInfo() {
        Console.WriteLine($"Title: {Title}, Author: {Author}, Genre: {Genre}");
    }
}
public class Library
{
    //This is the library's set of books (books is the list)
    private List<Book> bookList = new List<Book>();

    public void AddBook(Book book) 
    {
        //bookList.add adds the passed parameter of book to the list, bookList
        bookList.Add(book);
        Console.WriteLine("Book added Succesfully!");
    }

    public void DisplayBooks()
    {
        Console.WriteLine("Books in the Library:");
        foreach (var book in bookList) 
        {
            book.DisplayInfo();
        }
    }
    public void SearchForBook(string title) 
    {
        //runs through each book's title (book.Title) in bookList and matches the one in the library
        foreach (var book in bookList) 
        {
            if (book.Title.ToLower() == title.ToLower()) {
                Console.WriteLine("Book Found:");
                //when it finds the matching book, it uses the method to display it's info
                book.DisplayInfo();
                return;
            }
        }
        Console.WriteLine("Book Not Found :(");
    }
    public void RemoveBook(string title) 
    {
        int index = 0;
        //runs through each book's title (book.Title) in bookList and matches the one in the library
        foreach (var book in bookList) 
        {
            if (book.Title.ToLower() == title.ToLower()) {
                //when it finds the matching book, it uses the method to display it's info
                bookList.RemoveAt(index);
                Console.WriteLine("Book Taken");
                return;
            }
            index++;
        }
        Console.WriteLine("Book Not Found :(");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        //This generates a new library object, which it can Add, Display, and Search for books
        Library myLibrary = new Library();
        bool inLibrary = true;
        //This Creates a new Book Object inside of the library using the library class's AddBook Method
        myLibrary.AddBook(new Book("Uzumaki Volume 1", "Junji Ito", "Horror"));
        myLibrary.AddBook(new Book("The Bible", "Various Authors", "Religious"));


        Console.WriteLine("Welcome to the Library!");
        while (inLibrary) 
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("");
            Console.WriteLine("1< Add a Book");
            Console.WriteLine("2< Take a Book");
            Console.WriteLine("3< Display all Books");
            Console.WriteLine("4< Search for a Book");
            Console.WriteLine("5< Exit Library");

            int action = Convert.ToInt32(Console.ReadLine());

            if (action == 1) 
            {
                Console.WriteLine("What is the title of the book you would like to add?");
                string addedTitle = Console.ReadLine();
                Console.WriteLine($"Who is the author of {addedTitle}?");
                string addedAuthor = Console.ReadLine();
                Console.WriteLine($"What is the genre of {addedTitle}?");
                string addedGenre = Console.ReadLine();

                myLibrary.AddBook(new Book(addedTitle, addedAuthor, addedGenre));
                Console.WriteLine($"Added {addedTitle} by {addedAuthor}!");
            }
            if (action == 2) 
            {
                Console.WriteLine("What is the title of the book that you would you like to take?");
                string removedBook = Console.ReadLine();

                myLibrary.RemoveBook(removedBook);
            }
            if (action == 3) 
            {
                myLibrary.DisplayBooks(); 

            }
            if (action == 4) 
            {
                Console.WriteLine("What is the title of the book you would like to find?");
                string searchedBook = Console.ReadLine();

                myLibrary.SearchForBook(searchedBook);
            }
            if (action == 5) 
            {
                inLibrary = false;
            }
        }


        
    }
}