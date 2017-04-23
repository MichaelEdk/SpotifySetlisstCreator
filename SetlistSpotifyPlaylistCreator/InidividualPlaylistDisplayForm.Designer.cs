using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SetlistSpotifyPlaylistCreator
{
    partial class InidividualPlaylistDisplayForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.individualPlaylistListView = new ListView();
            this.generatePlaylistButton = new Button();
            this.SuspendLayout();
            // 
            // individualPlaylistListView
            // 
            this.individualPlaylistListView.Dock = DockStyle.Top;
            this.individualPlaylistListView.FullRowSelect = true;
            this.individualPlaylistListView.GridLines = true;
            this.individualPlaylistListView.Location = new Point(0, 0);
            this.individualPlaylistListView.Name = "individualPlaylistListView";
            this.individualPlaylistListView.Size = new Size(448, 490);
            this.individualPlaylistListView.TabIndex = 0;
            this.individualPlaylistListView.UseCompatibleStateImageBehavior = false;
            this.individualPlaylistListView.View = View.Details;
            // 
            // generatePlaylistButton
            // 
            this.generatePlaylistButton.Location = new Point(163, 496);
            this.generatePlaylistButton.Name = "generatePlaylistButton";
            this.generatePlaylistButton.Size = new Size(125, 23);
            this.generatePlaylistButton.TabIndex = 1;
            this.generatePlaylistButton.Text = "Generate Playlist";
            this.generatePlaylistButton.UseVisualStyleBackColor = true;
            this.generatePlaylistButton.Click += new EventHandler(this.generatePlaylistButton_Click);
            // 
            // InidividualPlaylistDisplayForm
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(448, 525);
            this.Controls.Add(this.generatePlaylistButton);
            this.Controls.Add(this.individualPlaylistListView);
            this.Name = "InidividualPlaylistDisplayForm";
            this.Text = "InidividualPlaylistDisplayForm";
            this.ResumeLayout(false);

        }

        #endregion

        private ListView individualPlaylistListView;
        private Button generatePlaylistButton;
    }
}