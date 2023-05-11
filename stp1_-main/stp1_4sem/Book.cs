using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace stp1_4sem
{
    public class Book
    {

        public Book(string new_ID, string new_author, string new_title, string new_year_of_publication, string new_thematic, string new_status, string new_date_of_issue, int Count)
        {
            this.ID = new_ID;
            this.Author = new_author;
            this.Title = new_title;
            this.Year_of_publication = new_year_of_publication;
            this.Thematic = new_thematic;
            this.Status = new_status;
            this.Date_of_issue = new_date_of_issue;
            this.Count = 0;
            
        }

        public Book() { }

        public string ID { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Year_of_publication { get; set; }
        public string Thematic { get; set; }
        public string Status { get; set; }
        public string Date_of_issue { get; set; }
        public int Count { get; set; }
    }
}
