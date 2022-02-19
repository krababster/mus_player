using System;
using System.IO;
using NAudio.Wave;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using NAudio.Wave.SampleProviders;

namespace Mus_Player
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 800);
            this.Text = "Form1";

            this.CD.Image = Image.FromFile("CD.jpg");
            this.CD.Location = new Point(250, 0);
            this.CD.Size = new Size(300, 290);
            this.Controls.Add(CD);

            this.PrevTrack_button.Location = new Point(150, 300);
            this.PrevTrack_button.Size = new Size(50, 50);
            this.PrevTrack_button.Image = Image.FromFile("Prev.png");
            this.PrevTrack_button.Click += PrevTrack_button_Click;
            this.Controls.Add(PrevTrack_button);
           
            this.Play_button.Location = new Point(this.PrevTrack_button.Location.X + 125, this.PrevTrack_button.Location.Y);
            this.Play_button.Size = new Size(50, 50);
            this.Play_button.Image = Image.FromFile("Play.png");
            this.Play_button.Click += Play_button_Click;
            this.Controls.Add(Play_button);

            this.Stop_button.Location = new Point(this.Play_button.Location.X + 125, this.Play_button.Location.Y);
            this.Stop_button.Size = new Size(50, 50);
            this.Stop_button.Image = Image.FromFile("Stop.png");
            this.Stop_button.Click += Stop_button_Click;
            this.Controls.Add(Stop_button);

            this.NextTrack_button.Location = new Point(this.Stop_button.Location.X + 125, this.Stop_button.Location.Y);
            this.NextTrack_button.Size = new Size(50, 50);
            this.NextTrack_button.Image = Image.FromFile("Next.png");
            this.NextTrack_button.Click += NextTrack_button_Click;
            this.Controls.Add(NextTrack_button);

            this.listbox.Location = new Point(100, 400);
            this.listbox.Size = new Size(600, 300);
            this.listbox.Font = new Font("Lucida Console", 10);
            this.Controls.Add(listbox);

            this.add_track_button.Location = new Point(720, this.listbox.Location.Y + 25);
            this.add_track_button.Size = new Size(50, 50);
            this.add_track_button.Text = "+";
            this.add_track_button.Font = new Font("Times New Roman", 15);
            this.add_track_button.Click += Add_track_button_Click;
            this.Controls.Add(add_track_button);

            this.remove_track_button.Location = new Point(720, this.add_track_button.Location.Y + 150);
            this.remove_track_button.Size = new Size(50, 50);
            this.remove_track_button.Text = "-";
            this.remove_track_button.Font = new Font("Times New Roman", 15);
            this.Controls.Add(remove_track_button);

            var flowPanel = new FlowLayoutPanel();
            flowPanel.FlowDirection = FlowDirection.LeftToRight;
            flowPanel.Margin = new Padding(10);

            this.Controls.Add(flowPanel);

        }
        void SetTrack(int index = 0)
        {
            audioFile = new AudioFileReader(my_list[num]);

        }
        private void PrevTrack_button_Click(object sender, System.EventArgs e)
        {
            num--;
            SetTrack(num);
            PrevTrack_button.Enabled = true;
        }


        private void NextTrack_button_Click(object sender, EventArgs e)
        {
            num++;
            SetTrack(num);
            PrevTrack_button.Enabled = true;
        }

        private void Add_track_button_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog add_track = new OpenFileDialog();
            add_track.Filter = "Audio files (*.mp3)|*.mp3|(*.waw)|*.waw";
            if (add_track.ShowDialog() == DialogResult.OK)
            {
                listbox.Items.Add(Path.GetFileName(add_track.FileName));
                my_list.Add(add_track.FileName);
                File.WriteAllLines("List.txt", my_list);
            }
        }

        private void Play_button_Click(object sender, System.EventArgs args)
        {
                if (outputDevice == null)
                {
                    outputDevice = new WaveOutEvent();
                    outputDevice.PlaybackStopped += OnPlaybackStopped;
                }
                if (audioFile == null)
                {
                    audioFile = new AudioFileReader(File.ReadAllText("List.txt"));
                    outputDevice.Init(audioFile);
                }
                outputDevice.Play();
            
        }

        private void Stop_button_Click(object sender, System.EventArgs e)
        {
            outputDevice.Stop();
        }
        private void OnPlaybackStopped(object sender, StoppedEventArgs args)
        {
            outputDevice.Dispose();
            outputDevice = null;
            audioFile.Dispose();
            audioFile = null;
        }

        PictureBox CD = new PictureBox();

        Button PrevTrack_button = new Button();
        Button NextTrack_button = new Button();
        Button Play_button = new Button();
        Button add_track_button = new Button();
        Button remove_track_button = new Button();
        Button Stop_button = new Button();

        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;

        ListBox listbox = new ListBox();

        List<string> my_list = new List<string>();

        int num = 0;
        #endregion
    }
}

