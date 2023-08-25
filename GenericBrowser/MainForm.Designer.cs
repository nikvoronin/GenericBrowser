namespace GenericBrowser
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( MainForm ) );
            mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            mainStatusStrip = new System.Windows.Forms.StatusStrip();
            logToolStripDropDown = new System.Windows.Forms.ToolStripDropDownButton();
            urlStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            browserPanel = new System.Windows.Forms.Panel();
            navigationLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            backwardButton = new System.Windows.Forms.Button();
            forwardButton = new System.Windows.Forms.Button();
            homeButton = new System.Windows.Forms.Button();
            updateButton = new System.Windows.Forms.Button();
            flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            devtoolsButton = new System.Windows.Forms.Button();
            screenshotButton = new System.Windows.Forms.Button();
            addressTextBox = new System.Windows.Forms.TextBox();
            mainTableLayoutPanel.SuspendLayout();
            mainStatusStrip.SuspendLayout();
            navigationLayoutPanel.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // mainTableLayoutPanel
            // 
            mainTableLayoutPanel.ColumnCount = 1;
            mainTableLayoutPanel.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle() );
            mainTableLayoutPanel.Controls.Add( mainStatusStrip, 0, 2 );
            mainTableLayoutPanel.Controls.Add( browserPanel, 0, 1 );
            mainTableLayoutPanel.Controls.Add( navigationLayoutPanel, 0, 0 );
            mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            mainTableLayoutPanel.Location = new System.Drawing.Point( 0, 0 );
            mainTableLayoutPanel.Margin = new System.Windows.Forms.Padding( 0 );
            mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            mainTableLayoutPanel.RowCount = 3;
            mainTableLayoutPanel.RowStyles.Add( new System.Windows.Forms.RowStyle() );
            mainTableLayoutPanel.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
            mainTableLayoutPanel.RowStyles.Add( new System.Windows.Forms.RowStyle() );
            mainTableLayoutPanel.Size = new System.Drawing.Size( 982, 753 );
            mainTableLayoutPanel.TabIndex = 0;
            // 
            // mainStatusStrip
            // 
            mainStatusStrip.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            mainTableLayoutPanel.SetColumnSpan( mainStatusStrip, 3 );
            mainStatusStrip.Dock = System.Windows.Forms.DockStyle.None;
            mainStatusStrip.ImageScalingSize = new System.Drawing.Size( 20, 20 );
            mainStatusStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] { logToolStripDropDown, urlStatusLabel } );
            mainStatusStrip.Location = new System.Drawing.Point( 0, 727 );
            mainStatusStrip.Name = "mainStatusStrip";
            mainStatusStrip.Size = new System.Drawing.Size( 982, 26 );
            mainStatusStrip.TabIndex = 0;
            mainStatusStrip.Text = "statusStrip1";
            // 
            // logToolStripDropDown
            // 
            logToolStripDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            logToolStripDropDown.Image = (System.Drawing.Image)resources.GetObject( "logToolStripDropDown.Image" );
            logToolStripDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            logToolStripDropDown.Margin = new System.Windows.Forms.Padding( 0, 2, 15, 0 );
            logToolStripDropDown.Name = "logToolStripDropDown";
            logToolStripDropDown.Size = new System.Drawing.Size( 48, 24 );
            logToolStripDropDown.Text = "Log";
            logToolStripDropDown.Visible = false;
            // 
            // urlStatusLabel
            // 
            urlStatusLabel.Name = "urlStatusLabel";
            urlStatusLabel.Size = new System.Drawing.Size( 50, 20 );
            urlStatusLabel.Text = "Ready";
            // 
            // browserPanel
            // 
            browserPanel.AutoSize = true;
            mainTableLayoutPanel.SetColumnSpan( browserPanel, 3 );
            browserPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            browserPanel.Location = new System.Drawing.Point( 0, 46 );
            browserPanel.Margin = new System.Windows.Forms.Padding( 0 );
            browserPanel.Name = "browserPanel";
            browserPanel.Size = new System.Drawing.Size( 982, 681 );
            browserPanel.TabIndex = 7;
            // 
            // navigationLayoutPanel
            // 
            navigationLayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            navigationLayoutPanel.ColumnCount = 3;
            navigationLayoutPanel.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 17F ) );
            navigationLayoutPanel.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 73F ) );
            navigationLayoutPanel.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 10F ) );
            navigationLayoutPanel.Controls.Add( flowLayoutPanel1, 0, 0 );
            navigationLayoutPanel.Controls.Add( flowLayoutPanel2, 2, 0 );
            navigationLayoutPanel.Controls.Add( addressTextBox, 1, 0 );
            navigationLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            navigationLayoutPanel.Location = new System.Drawing.Point( 0, 0 );
            navigationLayoutPanel.Margin = new System.Windows.Forms.Padding( 0 );
            navigationLayoutPanel.Name = "navigationLayoutPanel";
            navigationLayoutPanel.RowCount = 1;
            navigationLayoutPanel.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
            navigationLayoutPanel.Size = new System.Drawing.Size( 982, 46 );
            navigationLayoutPanel.TabIndex = 8;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            flowLayoutPanel1.Controls.Add( backwardButton );
            flowLayoutPanel1.Controls.Add( forwardButton );
            flowLayoutPanel1.Controls.Add( homeButton );
            flowLayoutPanel1.Controls.Add( updateButton );
            flowLayoutPanel1.Location = new System.Drawing.Point( 0, 5 );
            flowLayoutPanel1.Margin = new System.Windows.Forms.Padding( 0 );
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new System.Windows.Forms.Padding( 5, 0, 0, 0 );
            flowLayoutPanel1.Size = new System.Drawing.Size( 145, 35 );
            flowLayoutPanel1.TabIndex = 0;
            // 
            // backwardButton
            // 
            backwardButton.Location = new System.Drawing.Point( 8, 3 );
            backwardButton.Name = "backwardButton";
            backwardButton.Size = new System.Drawing.Size( 29, 29 );
            backwardButton.TabIndex = 0;
            backwardButton.Text = "◀";
            backwardButton.UseVisualStyleBackColor = true;
            backwardButton.Click += BackwardButton_Click;
            // 
            // forwardButton
            // 
            forwardButton.Location = new System.Drawing.Point( 43, 3 );
            forwardButton.Name = "forwardButton";
            forwardButton.Size = new System.Drawing.Size( 29, 29 );
            forwardButton.TabIndex = 1;
            forwardButton.Text = "▶";
            forwardButton.UseVisualStyleBackColor = true;
            forwardButton.Click += ForwardButton_Click;
            // 
            // homeButton
            // 
            homeButton.Location = new System.Drawing.Point( 78, 3 );
            homeButton.Name = "homeButton";
            homeButton.Size = new System.Drawing.Size( 29, 29 );
            homeButton.TabIndex = 2;
            homeButton.Text = "🏠";
            homeButton.UseVisualStyleBackColor = true;
            homeButton.Click += HomeButton_Click;
            // 
            // updateButton
            // 
            updateButton.Location = new System.Drawing.Point( 113, 3 );
            updateButton.Name = "updateButton";
            updateButton.Size = new System.Drawing.Size( 29, 29 );
            updateButton.TabIndex = 3;
            updateButton.Text = "↻";
            updateButton.UseVisualStyleBackColor = true;
            updateButton.Click += UpdateButton_Click;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.BackColor = System.Drawing.SystemColors.Control;
            flowLayoutPanel2.Controls.Add( devtoolsButton );
            flowLayoutPanel2.Controls.Add( screenshotButton );
            flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel2.Location = new System.Drawing.Point( 907, 5 );
            flowLayoutPanel2.Margin = new System.Windows.Forms.Padding( 0 );
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Padding = new System.Windows.Forms.Padding( 0, 0, 5, 0 );
            flowLayoutPanel2.Size = new System.Drawing.Size( 75, 35 );
            flowLayoutPanel2.TabIndex = 1;
            // 
            // devtoolsButton
            // 
            devtoolsButton.Location = new System.Drawing.Point( 38, 3 );
            devtoolsButton.Name = "devtoolsButton";
            devtoolsButton.Size = new System.Drawing.Size( 29, 29 );
            devtoolsButton.TabIndex = 4;
            devtoolsButton.Text = "⚡";
            devtoolsButton.UseVisualStyleBackColor = true;
            devtoolsButton.Click += DevtoolsButton_Click;
            // 
            // screenshotButton
            // 
            screenshotButton.Location = new System.Drawing.Point( 3, 3 );
            screenshotButton.Name = "screenshotButton";
            screenshotButton.Size = new System.Drawing.Size( 29, 29 );
            screenshotButton.TabIndex = 5;
            screenshotButton.Text = "📸";
            screenshotButton.UseVisualStyleBackColor = true;
            screenshotButton.Click += ScreenshotButton_Click;
            // 
            // addressTextBox
            // 
            addressTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            addressTextBox.Font = new System.Drawing.Font( "Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point );
            addressTextBox.Location = new System.Drawing.Point( 169, 9 );
            addressTextBox.Name = "addressTextBox";
            addressTextBox.Size = new System.Drawing.Size( 710, 27 );
            addressTextBox.TabIndex = 2;
            addressTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            addressTextBox.KeyUp += AddressTextBox_KeyUp;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF( 8F, 20F );
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size( 982, 753 );
            Controls.Add( mainTableLayoutPanel );
            Name = "MainForm";
            Text = "Form1";
            mainTableLayoutPanel.ResumeLayout( false );
            mainTableLayoutPanel.PerformLayout();
            mainStatusStrip.ResumeLayout( false );
            mainStatusStrip.PerformLayout();
            navigationLayoutPanel.ResumeLayout( false );
            navigationLayoutPanel.PerformLayout();
            flowLayoutPanel1.ResumeLayout( false );
            flowLayoutPanel2.ResumeLayout( false );
            ResumeLayout( false );
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel urlStatusLabel;
        private System.Windows.Forms.Panel browserPanel;
        private System.Windows.Forms.TableLayoutPanel navigationLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button backwardButton;
        private System.Windows.Forms.Button forwardButton;
        private System.Windows.Forms.Button homeButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button devtoolsButton;
        private System.Windows.Forms.Button screenshotButton;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.ToolStripDropDownButton logToolStripDropDown;
    }
}