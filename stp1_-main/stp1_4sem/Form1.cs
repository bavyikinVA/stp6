using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stp1_4sem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Library library;

        public void Form1_Load_1(object sender, EventArgs e)
        {
            library = new Library();
            library.load_archive("Library.txt");
            Show(library.Books);
        }

        private void Show(List<Book> Books)
        {
            dataGridView1.Rows.Clear();

            foreach (Book book in Books)
            {
                dataGridView1.Rows.Add(book.ID,book.Author,book.Title, book.Year_of_publication);
            }
        }

        public void button2_Click(object sender, EventArgs e)
        {
            int get_id = Convert.ToInt32(textBox1.Text);
            if (checkBox3.Checked == true)
            {
                MessageBox.Show("Книга ID: " + textBox1.Text + " " + library.check_id(library.Books, get_id),"Состояние книги", MessageBoxButtons.OK);
                checkBox3.Checked = false;
            }
            if (checkBox2.Checked == true) 
            {
                MessageBox.Show("Книга ID: " + textBox1.Text + " " + library.accept_book(library.Books, get_id), "Состояние книги", MessageBoxButtons.OK);
                checkBox2.Checked = false;
            }
            if (checkBox1.Checked == true)
            {
                MessageBox.Show("Книга ID: " + textBox1.Text + " " + library.give_out(library.Books, get_id) ,"Состояние книги", MessageBoxButtons.OK);
                checkBox1.Checked = false;
            }

            textBox1.Clear();
        }

        public void button4_Click(object sender, EventArgs e)
        {
            int delete_id = Convert.ToInt32(textBox6.Text);
            string delete = library.delete_book(library.Books, delete_id);

            dataGridView1.Rows.RemoveAt(delete_id);
            dataGridView1.Rows.Insert(delete_id, delete_id, "", "", "");
            
            textBox6.Clear();
        }

        public void button3_Click(object sender, EventArgs e)
        {
            string id = textBox7.Text;
            string author = textBox2.Text;
            string title = textBox3.Text;
            string year_of_publication = textBox4.Text;
            string thematic = textBox5.Text;
            library.manual_text_input(library.Books,id, author, title, thematic, year_of_publication);
            Show(library.Books);
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox7.Clear();
        }

        
        

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 archive_Form = new Form2(this);
            archive_Form.Show();
        }
        
    }
}
