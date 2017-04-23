namespace SetlistSpotifyPlaylistCreator
{
    partial class PlaylistDisplayForm
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
            this.concertListView = new System.Windows.Forms.ListView();
            this.concertListBox = new System.Windows.Forms.CheckedListBox();
            this.urlTextbox = new System.Windows.Forms.TextBox();
            this.URL = new System.Windows.Forms.Label();
            this.populateSetlistButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // concertListView
            // 
            this.concertListView.AllowColumnReorder = true;
            this.concertListView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.concertListView.FullRowSelect = true;
            this.concertListView.GridLines = true;
            this.concertListView.Location = new System.Drawing.Point(0, 45);
            this.concertListView.Name = "concertListView";
            this.concertListView.Size = new System.Drawing.Size(524, 499);
            this.concertListView.TabIndex = 3;
            this.concertListView.UseCompatibleStateImageBehavior = false;
            this.concertListView.View = System.Windows.Forms.View.Details;
            // 
            // concertListBox
            // 
            this.concertListBox.FormattingEnabled = true;
            this.concertListBox.Location = new System.Drawing.Point(25, 79);
            this.concertListBox.Name = "concertListBox";
            this.concertListBox.Size = new System.Drawing.Size(474, 379);
            this.concertListBox.TabIndex = 0;
            // 
            // urlTextbox
            // 
            this.urlTextbox.Location = new System.Drawing.Point(98, 16);
            this.urlTextbox.Name = "urlTextbox";
            this.urlTextbox.Size = new System.Drawing.Size(252, 20);
            this.urlTextbox.TabIndex = 4;
            // 
            // URL
            // 
            this.URL.AutoSize = true;
            this.URL.Location = new System.Drawing.Point(60, 19);
            this.URL.Name = "URL";
            this.URL.Size = new System.Drawing.Size(32, 13);
            this.URL.TabIndex = 5;
            this.URL.Text = "URL:";
            this.URL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // populateSetlistButton
            // 
            this.populateSetlistButton.Location = new System.Drawing.Point(377, 16);
            this.populateSetlistButton.Name = "populateSetlistButton";
            this.populateSetlistButton.Size = new System.Drawing.Size(107, 23);
            this.populateSetlistButton.TabIndex = 6;
            this.populateSetlistButton.Text = "Populate Setlists";
            this.populateSetlistButton.UseVisualStyleBackColor = true;
            this.populateSetlistButton.Click += new System.EventHandler(this.populateSetlistButton_Click);
            // 
            // PlaylistDisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 544);
            this.Controls.Add(this.populateSetlistButton);
            this.Controls.Add(this.URL);
            this.Controls.Add(this.urlTextbox);
            this.Controls.Add(this.concertListView);
            this.Controls.Add(this.concertListBox);
            this.Name = "PlaylistDisplayForm";
            this.Text = "Playlists";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView concertListView;
        private System.Windows.Forms.CheckedListBox concertListBox;
        private System.Windows.Forms.TextBox urlTextbox;
        private System.Windows.Forms.Label URL;
        private System.Windows.Forms.Button populateSetlistButton;
    }
}

