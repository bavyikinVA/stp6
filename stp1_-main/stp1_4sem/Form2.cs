using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace stp1_4sem
{
    public partial class Form2 : Form
    {
        private Form1 frm1;

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(Form1 f1)
        {
            InitializeComponent();
            frm1 = f1;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            List<Book> Books2 = new List<Book>();
            Books2 = frm1.library.Books;
            List<Book> Books3 = new List<Book>();
            Books3 = Books_change(frm1.library.Books, Books2);

            foreach (Book book in Books3)
            {

                dataGridView1.Rows.Add(book.Author, book.Title, book.Thematic, book.Count);
                if (book.Author == "") 
                {
                    dataGridView1.Rows.RemoveAt(Convert.ToInt32(book.ID));
                }
            }
            
        }

        public List<Book> Books_change(List<Book> Books1, List<Book> Books2) 
        {
            return frm1.library.count_book(Books1, Books2);
        }
        
        
    }
}
