using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstFormApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Note nextNote = new Note(textBox1.Text); // create a new note from text user entered
            
            // then add the 3 pieces of data from our new object to the ListView
            listView1.Items.Add(nextNote.NoteNumber);
            listView1.Items[listView1.Items.Count - 1].SubItems.Add(nextNote.Date.ToString());
            listView1.Items[listView1.Items.Count - 1].SubItems.Add(nextNote.Text);
            // listView1.Items.Count-1 gets the current listView item we just added
            // -1 because like arrays, the first item in [0]
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.BackColor = System.Drawing.Color.LightCoral;
            listView1.ForeColor = System.Drawing.Color.White;
            listView1.BorderStyle = BorderStyle.Fixed3D;
            listView1.View = View.Details;
            listView1.Columns.Add("Note Number", 80, HorizontalAlignment.Left);
            listView1.Columns.Add("When", 140, HorizontalAlignment.Left);
            listView1.Columns.Add("Note", 400, HorizontalAlignment.Left);
            listView1.GridLines = true;
            // this sets up appearance, puts it in detail mode (rather than icon mode, think of  Windows File Explorer as a ListView)
            // and then it creates 3 columns, with widths and header names
        }
    } //end of Form1 class
    public class Note
    {
        private DateTime _date;
        private static int _NoteNumber = 0;
        private string _text = "";

        public Note(string newText)  // constructor sets the Date field to "now"
        {
            _date = DateTime.UtcNow;
            _NoteNumber++; // bump up our count of Notes
            _text = newText; // set the text
        }
        //  Class Properties
        public string NoteNumber // each "record" gets a new, unique NoteNumber
        {
            get { return _NoteNumber.ToString(); }
        }
        public string Text // the text for our Note
        {
            get { return _text; }
        }
        public DateTime Date  // can read this property, but it is set only in constructor
        {
            get { return _date.ToLocalTime(); }
        }
    }
}
