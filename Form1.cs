using NAudio.Wave;
using System.Reflection.Emit;
using System.Windows.Forms;
using TagLib;

namespace MusicPlayer
{
    public partial class Form1 : Form
    {
        private WaveOutEvent? outputDevice;
        private AudioFileReader? audioFile;
        private bool isPlaying = false;
        private bool wasPlayingBeforeDrag;
        private ListViewItem? currentlyPlayingItem = null;
        private bool isShuffleMode = false;
        private bool isRepeatMode = false;
        private string currentFilePath = string.Empty;
        private Color originalButtonForeColor;

        public Form1()
        {
            InitializeComponent();
            btnOpenFile.Click += new EventHandler(btnOpenFile_Click);
            listView1.DoubleClick += new EventHandler(listView1_DoubleClick);
            originalButtonForeColor = button5.ForeColor;
        }

        private void btnOpenFile_Click(object? sender, EventArgs e)
        {
            int initialItemsCount = listView1.Items.Count;
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string filePath in openFileDialog1.FileNames)
                {
                    string fileName = Path.GetFileName(filePath);
                    ListViewItem item = new ListViewItem(fileName);
                    item.Tag = filePath;
                    listView1.Items.Add(item);
                }

                // Select and highlight the first track and load its metadata
                if (listView1.Items.Count > 0 && initialItemsCount == 0)
                {
                    listView1.Items[0].Selected = true;
                    listView1.Select();

                    if (listView1.Items[0].Tag is string filePath)
                    {
                        LoadTrackMetadata(filePath);
                        UpdateCurrentlyPlayingItem(listView1.Items[0]);
                    }
                }
            }

            AdjustListViewColumnWidth();
        }


        // Assuming you have another method to play a track when selected from the list
        private void PlaySelectedTrack(string filePath)
        {
            if (outputDevice != null)
            {
                outputDevice.Stop();
                outputDevice.Dispose();
            }

            if (audioFile != null)
            {
                audioFile.Dispose();
            }

            audioFile = new AudioFileReader(filePath);
            outputDevice = new WaveOutEvent();
            outputDevice.Init(audioFile);
            outputDevice.Play();
            currentFilePath = filePath;

            LoadTrackMetadata(filePath); // Load metadata
            UpdateCurrentlyPlayingItem(listView1.SelectedItems[0]); // Update currently playing item
            LoadTrack(filePath);
            isPlaying = true;
            button3.Text = "Pause";
            timer1.Start();
            
        }

        private void UpdateCurrentlyPlayingItem(ListViewItem? newItem)
        {
            if (currentlyPlayingItem != null)
            {
                // Reset the previous item to regular font
                currentlyPlayingItem.Font = new Font(listView1.Font, FontStyle.Regular);
            }

            currentlyPlayingItem = newItem;

            if (currentlyPlayingItem != null)
            {
                // Set the new item to bold font
                currentlyPlayingItem.Font = new Font(listView1.Font, FontStyle.Bold);
            }
        }


        // Event handler for when an item in the ListView is double-clicked
        private void listView1_DoubleClick(object? sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                if (selectedItem.Tag is string filePath)
                {
                    PlaySelectedTrack(filePath);
                }
            }
        }

        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            // Check if any track is selected
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                string? selectedFilePath = selectedItem.Tag as string;

                // Check if the selected track is different from the currently playing track
                if (currentFilePath != selectedFilePath)
                {
                    if (selectedFilePath != null)
                    {
                        PlaySelectedTrack(selectedFilePath);
                    }
                }
                else
                {
                    // Toggle play/pause for the current track
                    TogglePlayback();
                }
            }
            else
            {
                // If no track is selected, just toggle play/pause
                TogglePlayback();
            }
        }

        private void TogglePlayback()
        {
            if (isPlaying && outputDevice != null)
            {
                outputDevice.Pause();
                isPlaying = false;
                button3.Text = "Play";
            }
            else if (!isPlaying && outputDevice != null && audioFile != null)
            {
                outputDevice.Play();
                isPlaying = true;
                button3.Text = "Pause";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (audioFile != null && outputDevice != null)
            {
                var currentTime = audioFile.CurrentTime;
                var remainingTime = audioFile.TotalTime - currentTime;

                if (outputDevice.PlaybackState == PlaybackState.Playing)
                {
                    labelCurrentTime.Text = currentTime.ToString(@"hh\:mm\:ss");
                    labelRemainingTime.Text = "-" + remainingTime.ToString(@"hh\:mm\:ss");
                    trackBar1.Value = (int)Math.Min(currentTime.TotalSeconds, trackBar1.Maximum);
                }
                else if (outputDevice.PlaybackState == PlaybackState.Stopped && isPlaying)
                {
                    // Determine the next action based on shuffle and repeat
                    if (isRepeatMode && listView1.SelectedItems.Count > 0)
                    {
                        // Repeat the current track
                        PlaySelectedTrack(currentFilePath);
                    }
                    else if (isShuffleMode)
                    {
                        // Play a random track
                        PlayRandomTrack();
                    }
                    else
                    {
                        // Play the next track or stop if at the end of the list
                        PlayNextTrackOrStop();
                    }

                    // Reset the trackbar and time labels if playback has really stopped
                    if (!isPlaying)
                    {
                        trackBar1.Value = 0;
                        labelCurrentTime.Text = "00:00:00";
                        labelRemainingTime.Text = "-" + audioFile.TotalTime.ToString(@"hh\:mm\:ss");
                    }
                }
            }
        }

        private void PlayRandomTrack()
        {
            Random random = new Random();
            int nextIndex = random.Next(listView1.Items.Count);
            ListViewItem nextItem = listView1.Items[nextIndex];

            if (nextItem.Tag is string filePath)
            {
                listView1.SelectedItems.Clear();
                nextItem.Selected = true;
                listView1.Select();
                PlaySelectedTrack(filePath);
            }
        }


        private void PlayNextTrackOrStop()
        {
            int currentIndex = listView1.SelectedItems.Count > 0 ? listView1.SelectedItems[0].Index : 0;
            int nextIndex = currentIndex + 1;

            if (nextIndex < listView1.Items.Count)
            {
                ListViewItem nextItem = listView1.Items[nextIndex];

                if (nextItem.Tag is string filePath)
                {
                    PlaySelectedTrack(filePath);
                }
            }
            else
            {
                // Reached the end of the playlist
                isPlaying = false;
                button3.Text = "Play";
                trackBar1.Value = 0;
            }
        }

        private TimeSpan GetAudioFileDuration(string fileName)
        {
            using (var reader = new Mp3FileReader(fileName))
            {
                return reader.TotalTime;
            }
        }

        private void LoadTrack(string filePath)
        {
            var duration = GetAudioFileDuration(filePath);
            trackBar1.Maximum = (int)duration.TotalSeconds;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (audioFile != null && outputDevice != null && outputDevice.PlaybackState != PlaybackState.Stopped)
            {
                audioFile.CurrentTime = TimeSpan.FromSeconds(trackBar1.Value);
                var selectedTime = TimeSpan.FromSeconds(trackBar1.Value);
                var remainingTime = audioFile.TotalTime - selectedTime;

                labelCurrentTime.Text = selectedTime.ToString(@"hh\:mm\:ss");
                labelRemainingTime.Text = "-" + remainingTime.ToString(@"hh\:mm\:ss");
            }
        }

        private void trackBar1_MouseDown(object sender, MouseEventArgs e)
        {
            if (outputDevice != null)
            {
                wasPlayingBeforeDrag = (outputDevice.PlaybackState == PlaybackState.Playing);
                if (wasPlayingBeforeDrag)
                {
                    outputDevice.Pause();
                }
            }
        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            if (audioFile != null && outputDevice != null && wasPlayingBeforeDrag && isPlaying)
            {
                audioFile.CurrentTime = TimeSpan.FromSeconds(trackBar1.Value);
                // Only resume playback if it was playing before dragging and is still in play mode
                outputDevice.Play();
            }
        }

        private void LoadTrackMetadata(string filePath)
        {
            var file = TagLib.File.Create(filePath);
            var title = file.Tag.Title;
            var artists = string.Join(", ", file.Tag.Performers);
            var album = file.Tag.Album;
            var year = file.Tag.Year.ToString();
            var genre = string.Join(", ", file.Tag.Genres);

            // Update your labels here
            label1.Text = "Title: " + (string.IsNullOrEmpty(title) ? "Unknown" : title);
            label2.Text = "Artist: " + (string.IsNullOrEmpty(artists) ? "Unknown" : artists);
            label3.Text = "Album: " + (string.IsNullOrEmpty(album) ? "Unknown" : album);
            label4.Text = "Year: " + (string.IsNullOrEmpty(year) ? "Unknown" : year);
            label5.Text = "Genre: " + (string.IsNullOrEmpty(genre) ? "Unknown" : genre);

            if (file.Tag.Pictures.Length > 0)
            {
                var bin = (byte[])(file.Tag.Pictures[0].Data.Data);
                using (var ms = new MemoryStream(bin))
                {
                    pictureBox1.Image = Image.FromStream(ms);
                }
            }
            else
            {
                var imagePath = FindImageInTrackFolder(filePath);
                if (imagePath != null)
                {
                    pictureBox1.Image = Image.FromFile(imagePath);
                }
                else
                {
                    pictureBox1.Image = Image.FromFile("../../../default.png"); // Default image
                }
            }
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            // Stop the current playback
            if (outputDevice != null)
            {
                outputDevice.Stop();
                outputDevice.Dispose();
                outputDevice = null;
            }

            if (audioFile != null)
            {
                audioFile.Dispose();
                audioFile = null;
            }

            // Reset the trackbar
            trackBar1.Value = 0;

            // Clear the metadata labels
            label1.Text = "Title: ";
            label2.Text = "Artist: ";
            label3.Text = "Album: ";
            label4.Text = "Year: ";
            label5.Text = "Genre: ";

            pictureBox1.Image = Image.FromFile("../../../default.png");

            // Clear the ListView
            listView1.Items.Clear();

            // Reset play/pause button text and isPlaying flag
            button3.Text = "Play";
            isPlaying = false;

            // Stop the timer if it's running
            timer1.Stop();
            UpdateCurrentlyPlayingItem(null);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                int nextIndex;
                if (isShuffleMode)
                {
                    Random random = new Random();
                    nextIndex = random.Next(listView1.Items.Count);
                }
                else
                {
                    int currentIndex = listView1.SelectedItems.Count > 0 ? listView1.SelectedItems[0].Index : 0;
                    nextIndex = currentIndex + 1;
                    if (nextIndex >= listView1.Items.Count)
                    {
                        return; 
                    }
                }

                listView1.SelectedItems.Clear();
                listView1.Items[nextIndex].Selected = true;
                listView1.Select();

                if (listView1.Items[nextIndex].Tag is string filePath)
                {
                    PlaySelectedTrack(filePath);
                }
            }
        }


        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                int currentIndex = listView1.SelectedItems.Count > 0 ? listView1.SelectedItems[0].Index : 0;
                int prevIndex = currentIndex - 1;

                if (prevIndex >= 0)
                {
                    listView1.Items[currentIndex].Selected = false;
                    listView1.Items[prevIndex].Selected = true;
                    listView1.Select();

                    if (listView1.Items[prevIndex].Tag is string filePath)
                    {
                        PlaySelectedTrack(filePath);
                    }
                }
            }
        }

        private void btnShuffle_Click(object sender, EventArgs e)
        {
            isShuffleMode = !isShuffleMode; // Toggle shuffle mode

            if (isShuffleMode)
            {
                button1.BackColor = SystemColors.Highlight; // Change to blue when shuffle is on
                button1.ForeColor = SystemColors.Control; // Change text color to white for better readability
            }
            else
            {
                button1.UseVisualStyleBackColor = true;
                button1.ForeColor = originalButtonForeColor;
            }
        }

        private void btnRepeat_Click(object sender, EventArgs e)
        {
            isRepeatMode = !isRepeatMode; // Toggle repeat mode

            if (isRepeatMode)
            {
                button5.BackColor = SystemColors.Highlight; // Change to blue when repeat is on
                button5.ForeColor = SystemColors.Control; // Change text color for better readability
            }
            else
            {
                button5.UseVisualStyleBackColor = true;
                button5.ForeColor = originalButtonForeColor;
            }
        }

        private string? FindImageInTrackFolder(string trackPath)
        {
            var folderPath = Path.GetDirectoryName(trackPath);
            if (folderPath == null)
            {
                return null;
            }

            var imageExtensions = new List<string> { ".jpg", ".jpeg", ".png" };
            var files = Directory.GetFiles(folderPath);

            foreach (var file in files)
            {
                if (imageExtensions.Any(ext => file.EndsWith(ext, StringComparison.OrdinalIgnoreCase)))
                {
                    return file;
                }
            }

            return null; // No image file found
        }

        private void AdjustListViewColumnWidth()
        {
            int maxWidth = 0;
            using (Graphics g = listView1.CreateGraphics())
            {
                foreach (ListViewItem item in listView1.Items)
                {
                    // Measure the width of each item
                    int itemWidth = (int)g.MeasureString(item.Text, listView1.Font).Width;
                    maxWidth = Math.Max(maxWidth, itemWidth);
                }
            }

            // Add some padding to maxWidth
            maxWidth += 20; // Adjust this value as needed for padding

            if (maxWidth > listView1.ClientRectangle.Width)
            {
                listView1.Columns[0].Width = maxWidth; // Set column width to maxWidth
            }
            else
            {
                listView1.Columns[0].Width = -2; // Set column width to auto-resize
            }
        }


    }
}
