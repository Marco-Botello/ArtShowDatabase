//MADE BY MARCO BOTELLO

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;
using MySql.Data;
using System.IO;

namespace ArtShow
{
    public partial class Form1 : Form
    {
        //initialize connection
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=password");
        DataTable dt = new DataTable("Artists");
        //Initialize the form
        public Form1()
        {
            InitializeComponent();
        }

        //Do Nothing When the form loads, was used earlier to test DB connection
        private void Form1_Load(object sender, EventArgs e)
        {// TODO: This line of code loads data into the 'artshowDataSet1.artist' table. You can move, or remove it, as needed.
            this.artistTableAdapter.Fill(this.artshowDataSet1.artist);
        }

        //Gets data from customer table
        private DataTable GetCustomerList()
        {
            DataTable dtCustomers = new DataTable();
            string connString = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM customer", con))
                {
                    con.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dtCustomers.Load(reader);
                }
            }
                return dtCustomers;
        }

        //Gets data from artist table
        private DataTable GetArtistList()
        {
            DataTable dtArtists = new DataTable();
            string connString = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM artist", con))
                {
                    con.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dtArtists.Load(reader);
                }
            }
            return dtArtists;
        }
        
        //Get data from art show table 
        private DataTable GetArtShowList()
        {
            DataTable dtArtShows = new DataTable();
            string connString = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM artshows", con))
                {
                    con.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dtArtShows.Load(reader);
                }
            }
            return dtArtShows;
        }

        //get data from art work table
        private DataTable GetArtWorkList()
        {
            DataTable dtArtWorks = new DataTable();
            string connString = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM artwork", con))
                {
                    con.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dtArtWorks.Load(reader);
                }
            }
            return dtArtWorks;
        }

        //Gets data when you click
        private void Button1_Click(object sender, EventArgs e)
        {
            customerList.DataSource = GetCustomerList();
        }

        //Gets data when you click
        private void button2_Click(object sender, EventArgs e)
        {
            customerList.DataSource = GetArtistList();
        }

        //Gets data when you click
        private void Button3_Click(object sender, EventArgs e)
        {
            customerList.DataSource = GetArtShowList();
        }

        //Gets data when you click
        private void button4_Click(object sender, EventArgs e)
        {
            customerList.DataSource = GetArtWorkList();
        

        }
 
        //Search button
        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.artistTableAdapter.SearchName(this.artshowDataSet1.artist);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

    }
}
    

