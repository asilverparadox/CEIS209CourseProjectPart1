using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;

namespace Murphy_CourseProject_Part1
{
    public partial class MainForm : Form
    {
        // Class level references
        string[] titleArray = new string[5];
        string[] artistArray = new string[5];
        string[] genreArray = new string[5];
        int[] yearArray = new int[5];
        string[] urlArray = new string[5];
        int songCount = 0;

        public MainForm()
        {
            InitializeComponent();
        }


        public bool ValidInput()
        {
            // Return True if all fields are non-empty
            bool isValid = true;

            if (string.IsNullOrEmpty(titleText.Text))
            {
                // Title is blank
                MessageBox.Show("The song title cannot be blank.");
                isValid = false;
            }
            else if (string.IsNullOrEmpty(artistText.Text))
            {
                // Artist is blank
                MessageBox.Show("The artist cannot be blank.");
                isValid = false;
            }
            else if (string.IsNullOrEmpty(genreText.Text))
            {
                // Genre is blank
                MessageBox.Show("The genre cannot be blank.");
                isValid = false;
            }
            else if (string.IsNullOrEmpty(yearText.Text))
            {
                // Year is blank
                MessageBox.Show("The year cannot be blank.");
                isValid = false;
            }
            else if (string.IsNullOrEmpty(urlText.Text))
            {
                // URL is blank
                MessageBox.Show("The URL cannot be blank.");
                isValid = false;
            }

            return isValid;
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder(outputText.Text);
            string n1 = "\r\n";
            
            if( ValidInput() )
            {
                // Add title to ListBox and song list
                songList.Items.Add(titleText.Text);
                titleArray[songCount] = titleText.Text;
                artistArray[songCount] = artistText.Text;
                genreArray[songCount] = genreText.Text;
                yearArray[songCount] = int.Parse(yearText.Text);
                urlArray[songCount] = urlText.Text;

                // Increment the song counter
                songCount++;

                // All good! Build the output text

                    sb.Append(titleText.Text);
                    sb.Append(n1);
                    sb.Append(artistText.Text);
                    sb.Append(n1);
                    sb.Append(genreText.Text);
                    sb.Append(n1);
                    sb.Append(yearText.Text);
                    sb.Append(n1);
                    sb.Append(urlText.Text);
                    sb.Append(n1);

                    // Put the output text into the output textbox
                    outputText.Text = sb.ToString();


            }

        }

        private bool SongInLIst(string songTitle)
        {
            bool found = false;

            foreach (var item in songList.Items)
            {
                string currentSong = item as string;
                // lowercase comparison not case sensitive
                if( songTitle.ToLower() == currentSong.ToLower() )
                {
                    found = true;
                }
            }

            return found;
        }

        private int GetSongIndex(string songTitle)
        {
            int songIndex = songList.Items.IndexOf(songTitle);
            return songIndex;
        }
        private void allSongsButton_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder(string.Empty);
            string n1 = "\r\n";

            // Build the output text
            foreach (var item in songList.Items)
            {
                sb.Append(item.ToString());
                sb.Append(n1);
            }

            // Put the output text into the output textbox
            outputText.Text = sb.ToString();
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            if (SongInLIst(titleText.Text))
            {
                StringBuilder sb = new StringBuilder(string.Empty);
                string n1 = "\r\n";

                int songIndex = GetSongIndex(titleText.Text);

                // Build the output text
                sb.Append(titleArray[songIndex]);
                sb.Append(n1);
                sb.Append(artistArray[songIndex]);
                sb.Append(n1);
                sb.Append(genreArray[songIndex]);
                sb.Append(n1);
                sb.Append(yearArray[songIndex]);
                sb.Append(n1);
                sb.Append(urlArray[songIndex]);
                sb.Append(n1);

                outputText.Text = sb.ToString();
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            titleText.Text = "";  // one to clear textbox
            artistText.Text = String.Empty; //second way to clear
            genreText.Clear(); // third way to clear
            yearText.Clear();
            urlText.Clear();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            int songIndex = songList.SelectedIndex;
            string url = urlArray[songIndex];
            webViewDisplay.CoreWebView2.Navigate(url);
        }

        private void songList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int songIndex = songList.SelectedIndex;

            // If song is selected (index greater than -1), show the details
            if( songIndex > -1)
            {
                StringBuilder sb = new StringBuilder(string.Empty);
                string n1 = "\r\n";

                // Build the output text
                sb.Append(titleArray[songIndex]);
                sb.Append(n1);
                sb.Append(artistArray[songIndex]);
                sb.Append(n1);
                sb.Append(genreArray[songIndex]);
                sb.Append(n1);
                sb.Append(yearArray[songIndex]);
                sb.Append(n1);
                sb.Append(urlArray[songIndex]);
                sb.Append(n1);

                outputText.Text = sb.ToString();
            }
        }
    }
}
