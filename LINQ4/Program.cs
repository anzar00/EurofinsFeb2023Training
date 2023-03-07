using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LINQ4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XDocument xml = XDocument.Load("XMLFile1.xml");
            // Get all titles which belong to fantasy

            XElement doc = new XElement("books",
            from book in xml.Descendants("book")
            where book.Element("genre").Value== "Fantasy"
            select new XElement("book",
                            new XElement("id", book.Attribute("id").Value),
                            new XElement("Title", book.Element("title").Value),
                            new XElement("Author", book.Element("author").Value)
                            )
            );
            //var fantacyBooks
            //                   select new BookTitleAuthor
            //                   {
            //                       Title = book.Element("title").Value,
            //                       Author = book.Element("author").Value
            //                   };
            //foreach (var book in fantacyBooks)
            //{
            //    Console.WriteLine(book);
            //};

            doc.Save("FantacyBooks.xml");
        }
    }

    class BookTitleAuthor
    {
        public string Title { get; set; }
        public string Author { get; set; }
    }
}
