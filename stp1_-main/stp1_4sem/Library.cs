using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace stp1_4sem
{
    public class Library
    {
        public List<Book> Books = new List<Book>();
        

        public Library()
        {
            Books = new List<Book>();
        }

        public void Add_book(string new_ID, string new_author, string new_title, string new_year_of_publication,string new_thematic, string new_status,string new_date_of_issue)
        {
            Book book = new Book();
            book.ID = new_ID;
            book.Author = new_author;
            book.Title = new_title;
            book.Year_of_publication = new_year_of_publication;
            book.Thematic = new_thematic;
            book.Status = new_status;
            book.Date_of_issue = new_date_of_issue;
            book.Count = 1;
            Books.Add(book);
            
        }

        public void load_archive(string file_name)
        {
            try
            {
                
                string text = File.ReadAllText(file_name);
                var arr = text.Split('_');
                for (int i = 0; i < arr.Length; i += 7 )
                {
                    Add_book(arr[i], arr[i + 1], arr[i + 2], arr[i + 3], arr[i + 4], arr[i + 5], arr[i + 6]);
                }
                
            }
            catch (Exception e)
            {
                throw new Exception("Ошибка при чтении файла: " + e.Message);
            }
        }

        public string delete_book(List<Book> Books, int delete_id)
        {
            foreach (Book book in new List<Book>(Books))
            {
                int book_id = Convert.ToInt32(book.ID);
                if (book_id == delete_id)
                { 
                    book.ID = Convert.ToString(book_id);
                    book.Author = "";
                    book.Title = "";
                    book.Year_of_publication = "";
                    book.Thematic = "";
                    book.Status = "";
                    book.Date_of_issue = "";
                    book.Count = 0;
                    break;
                }
                
            }
            return Convert.ToString(delete_id);
        }

        public string check_id(List<Book> Books, int get_id)
        {
            string condition = "";
            foreach (Book book in Books)
            {
                int book_id = Convert.ToInt32(book.ID);
                if (book_id == get_id)
                {
                    condition = book.Status + " " + book.Date_of_issue;
                    break;
                }
            }
            return condition;
        }

        public string accept_book(List<Book> Books, int get_id) 
        {
            string write = ""; 
            foreach (Book book in Books) 
            {
                int book_id = Convert.ToInt32(book.ID);
                if ((get_id == book_id) && (book.Status == "Выдано")) 
                {
                    book.Status = "В архиве";
                    book.Date_of_issue = "";
                    write = book.Status + " " + book.Date_of_issue;
                }
            }
            return write;
        }

        public string give_out(List<Book> Books, int get_id)
        {
            string write = ""; 
            foreach (Book book in Books)
            {
                int book_id = Convert.ToInt32(book.ID);
                if ((get_id == book_id) && (book.Status == "В архиве"))
                {
                    book.Status = "Выдано";
                    book.Date_of_issue = Convert.ToString(DateTime.Now);
                    write = book.Status + " " + book.Date_of_issue;
                }
            }
            return write;
        }

        public void manual_text_input(List<Book> Books, string id, string author, string title, string theme, string year)
        {
            foreach (Book book in new List<Book>(Books))
            {
                if ((book.Author == "") && (book.ID != "") && (book.ID == id))
                {
                    Book new_book = new Book();
                    new_book.ID = id;
                    new_book.Author = author;
                    new_book.Title = title;
                    new_book.Thematic = theme;
                    new_book.Year_of_publication = year;
                    new_book.Status = "В архиве";
                    new_book.Date_of_issue = "";
                    new_book.Count = 1;
                    Books.RemoveAt(Convert.ToInt32(book.ID));
                    Books.Insert(Convert.ToInt32(book.ID), new_book);
                    break;
                }
                else if (Convert.ToInt32(id) == Books.Count())
                {
                    Add_book(id, author, title, year, theme, "В архиве", "");
                    break;
                }
                
            }
        }

        public List<Book> count_book(List<Book> Books1, List<Book> Books2)
        {
            foreach (Book book1 in new List<Book> (Books1))
            {
                foreach (Book book2 in new List<Book> (Books2))
                {
                    if ((book1.Author == book2.Author) && (book1.Title == book2.Title))
                    {
                        
                        if ((book1.Count > 1) && (book1.ID != book2.ID))
                        {
                            Books2.RemoveAt(Convert.ToInt32(book2.ID));
                            book2.Count++;
                        }
                        
                    }
                }
                
            }
            
            return Books2;
            
        }
            
        

    }
}
