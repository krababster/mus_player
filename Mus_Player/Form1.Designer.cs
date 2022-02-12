using System.Drawing;
using System.Windows.Forms;

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

            this.CD.Image = Image.FromFile("disk-dvdr-4-7gb-16h-vulk-(50)-d-54099-085-mix.jpg");
            this.CD.Location = new Point(250, 0);
            this.CD.Size = new Size(300, 290);
            this.Controls.Add(CD);

            this.PrevTrack_button.Location = new Point(250, 300);
            this.PrevTrack_button.Size = new Size(50, 50);
            this.PrevTrack_button.Image = Image.FromFile("Prev.png");
            this.Controls.Add(PrevTrack_button);

            this.PlayStop_button.Location = new Point(this.PrevTrack_button.Location.X + 125, this.PrevTrack_button.Location.Y);
            this.PlayStop_button.Size = new Size(50, 50);
            this.PlayStop_button.Image = Image.FromFile("Play.png");
            this.Controls.Add(PlayStop_button);

            this.NextTrack_button.Location = new Point(this.PlayStop_button.Location.X + 125, this.PlayStop_button.Location.Y);
            this.NextTrack_button.Size = new Size(50, 50);
            this.NextTrack_button.Image = Image.FromFile("Next.png");
            this.Controls.Add(NextTrack_button);

            this.listbox.Location = new Point(100, 400);
            this.listbox.Size = new Size(600, 300);
            this.Controls.Add(listbox);

            this.add_track_button.Location = new Point(720, this.listbox.Location.Y + 25);
            this.add_track_button.Size = new Size(50, 50);
            this.add_track_button.Text = "+";
            this.add_track_button.Font = new Font("Times New Roman",15);
            this.Controls.Add(add_track_button);

            this.remove_track_button.Location = new Point(720, this.add_track_button.Location.Y + 150);
            this.remove_track_button.Size = new Size(50, 50);
            this.remove_track_button.Text = "-";
            this.remove_track_button.Font = new Font("Times New Roman", 15);
            this.Controls.Add(remove_track_button);

        }
        PictureBox CD = new PictureBox();

        Button PrevTrack_button = new Button();
        Button NextTrack_button = new Button();
        Button PlayStop_button = new Button();
        Button add_track_button = new Button();
        Button remove_track_button = new Button();

        //OpenFileDialog add = new OpenFileDialog();
        ListBox listbox = new ListBox();
        #endregion
    }
}

