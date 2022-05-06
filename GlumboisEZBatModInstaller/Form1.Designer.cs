namespace GlumboisEZBatModInstaller
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button_install = new MaterialSkin.Controls.MaterialButton();
            this.textBox_path = new MaterialSkin.Controls.MaterialTextBox();
            this.Install_unitypatcher_Button = new MaterialSkin.Controls.MaterialButton();
            this.button_selectPCBS = new MaterialSkin.Controls.MaterialButton();
            this.Restore_Save_Files = new MaterialSkin.Controls.MaterialButton();
            this.timer_updatepath = new System.Timers.Timer();
            this.Debug_install_CB = new MaterialSkin.Controls.MaterialCheckbox();
            this.Fix_Corrupted_Saves_Button = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize) (this.timer_updatepath)).BeginInit();
            this.SuspendLayout();
            // 
            // button_install
            // 
            this.button_install.AutoSize = false;
            this.button_install.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button_install.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button_install.Depth = 0;
            this.button_install.HighEmphasis = true;
            this.button_install.Icon = null;
            this.button_install.Location = new System.Drawing.Point(173, 129);
            this.button_install.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button_install.MouseState = MaterialSkin.MouseState.HOVER;
            this.button_install.Name = "button_install";
            this.button_install.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button_install.Size = new System.Drawing.Size(158, 50);
            this.button_install.TabIndex = 4;
            this.button_install.Text = "Install mods";
            this.button_install.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.button_install.UseAccentColor = false;
            this.button_install.UseVisualStyleBackColor = true;
            this.button_install.Click += new System.EventHandler(this.button_install_Click);
            // 
            // textBox_path
            // 
            this.textBox_path.AnimateReadOnly = false;
            this.textBox_path.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_path.Depth = 0;
            this.textBox_path.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_path.LeadingIcon = null;
            this.textBox_path.Location = new System.Drawing.Point(7, 70);
            this.textBox_path.MaxLength = 50;
            this.textBox_path.MouseState = MaterialSkin.MouseState.OUT;
            this.textBox_path.Multiline = false;
            this.textBox_path.Name = "textBox_path";
            this.textBox_path.Size = new System.Drawing.Size(490, 50);
            this.textBox_path.TabIndex = 5;
            this.textBox_path.Text = "";
            this.textBox_path.TrailingIcon = null;
            // 
            // Install_unitypatcher_Button
            // 
            this.Install_unitypatcher_Button.AutoSize = false;
            this.Install_unitypatcher_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Install_unitypatcher_Button.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.Install_unitypatcher_Button.Depth = 0;
            this.Install_unitypatcher_Button.HighEmphasis = true;
            this.Install_unitypatcher_Button.Icon = null;
            this.Install_unitypatcher_Button.Location = new System.Drawing.Point(7, 129);
            this.Install_unitypatcher_Button.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Install_unitypatcher_Button.MouseState = MaterialSkin.MouseState.HOVER;
            this.Install_unitypatcher_Button.Name = "Install_unitypatcher_Button";
            this.Install_unitypatcher_Button.NoAccentTextColor = System.Drawing.Color.Empty;
            this.Install_unitypatcher_Button.Size = new System.Drawing.Size(158, 50);
            this.Install_unitypatcher_Button.TabIndex = 6;
            this.Install_unitypatcher_Button.Text = "Install unitypatcher";
            this.Install_unitypatcher_Button.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.Install_unitypatcher_Button.UseAccentColor = false;
            this.Install_unitypatcher_Button.UseVisualStyleBackColor = true;
            this.Install_unitypatcher_Button.Click += new System.EventHandler(this.Install_unitypatcher_Button_Click);
            // 
            // button_selectPCBS
            // 
            this.button_selectPCBS.AutoSize = false;
            this.button_selectPCBS.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button_selectPCBS.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button_selectPCBS.Depth = 0;
            this.button_selectPCBS.HighEmphasis = true;
            this.button_selectPCBS.Icon = null;
            this.button_selectPCBS.Location = new System.Drawing.Point(339, 129);
            this.button_selectPCBS.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button_selectPCBS.MouseState = MaterialSkin.MouseState.HOVER;
            this.button_selectPCBS.Name = "button_selectPCBS";
            this.button_selectPCBS.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button_selectPCBS.Size = new System.Drawing.Size(158, 50);
            this.button_selectPCBS.TabIndex = 8;
            this.button_selectPCBS.Text = "Select pcbs";
            this.button_selectPCBS.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.button_selectPCBS.UseAccentColor = false;
            this.button_selectPCBS.UseVisualStyleBackColor = true;
            this.button_selectPCBS.Click += new System.EventHandler(this.button_selectPCBS_Click);
            // 
            // Restore_Save_Files
            // 
            this.Restore_Save_Files.AutoSize = false;
            this.Restore_Save_Files.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Restore_Save_Files.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.Restore_Save_Files.Depth = 0;
            this.Restore_Save_Files.HighEmphasis = true;
            this.Restore_Save_Files.Icon = null;
            this.Restore_Save_Files.Location = new System.Drawing.Point(7, 227);
            this.Restore_Save_Files.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Restore_Save_Files.MouseState = MaterialSkin.MouseState.HOVER;
            this.Restore_Save_Files.Name = "Restore_Save_Files";
            this.Restore_Save_Files.NoAccentTextColor = System.Drawing.Color.Empty;
            this.Restore_Save_Files.Size = new System.Drawing.Size(490, 36);
            this.Restore_Save_Files.TabIndex = 9;
            this.Restore_Save_Files.Text = "Restore save files";
            this.Restore_Save_Files.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.Restore_Save_Files.UseAccentColor = false;
            this.Restore_Save_Files.UseVisualStyleBackColor = true;
            this.Restore_Save_Files.Click += new System.EventHandler(this.Restore_Save_Files_Click);
            // 
            // timer_updatepath
            // 
            this.timer_updatepath.Enabled = true;
            this.timer_updatepath.Interval = 400D;
            this.timer_updatepath.SynchronizingObject = this;
            this.timer_updatepath.Elapsed += new System.Timers.ElapsedEventHandler(this.timer_updatepath_Elapsed);
            // 
            // Debug_install_CB
            // 
            this.Debug_install_CB.Depth = 0;
            this.Debug_install_CB.Location = new System.Drawing.Point(7, 185);
            this.Debug_install_CB.Margin = new System.Windows.Forms.Padding(0);
            this.Debug_install_CB.MouseLocation = new System.Drawing.Point(-1, -1);
            this.Debug_install_CB.MouseState = MaterialSkin.MouseState.HOVER;
            this.Debug_install_CB.Name = "Debug_install_CB";
            this.Debug_install_CB.ReadOnly = false;
            this.Debug_install_CB.Ripple = true;
            this.Debug_install_CB.Size = new System.Drawing.Size(158, 37);
            this.Debug_install_CB.TabIndex = 10;
            this.Debug_install_CB.Text = "Debug install";
            this.Debug_install_CB.UseVisualStyleBackColor = true;
            this.Debug_install_CB.CheckedChanged += new System.EventHandler(this.Debug_install_CB_CheckedChanged);
            // 
            // Fix_Corrupted_Saves_Button
            // 
            this.Fix_Corrupted_Saves_Button.AutoSize = false;
            this.Fix_Corrupted_Saves_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Fix_Corrupted_Saves_Button.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.Fix_Corrupted_Saves_Button.Depth = 0;
            this.Fix_Corrupted_Saves_Button.HighEmphasis = true;
            this.Fix_Corrupted_Saves_Button.Icon = null;
            this.Fix_Corrupted_Saves_Button.Location = new System.Drawing.Point(7, 275);
            this.Fix_Corrupted_Saves_Button.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Fix_Corrupted_Saves_Button.MouseState = MaterialSkin.MouseState.HOVER;
            this.Fix_Corrupted_Saves_Button.Name = "Fix_Corrupted_Saves_Button";
            this.Fix_Corrupted_Saves_Button.NoAccentTextColor = System.Drawing.Color.Empty;
            this.Fix_Corrupted_Saves_Button.Size = new System.Drawing.Size(490, 36);
            this.Fix_Corrupted_Saves_Button.TabIndex = 11;
            this.Fix_Corrupted_Saves_Button.Text = "Fix unable to load save";
            this.Fix_Corrupted_Saves_Button.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.Fix_Corrupted_Saves_Button.UseAccentColor = false;
            this.Fix_Corrupted_Saves_Button.UseVisualStyleBackColor = true;
            this.Fix_Corrupted_Saves_Button.Click += new System.EventHandler(this.Fix_Corrupted_Saves_Button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 320);
            this.Controls.Add(this.Fix_Corrupted_Saves_Button);
            this.Controls.Add(this.Debug_install_CB);
            this.Controls.Add(this.Restore_Save_Files);
            this.Controls.Add(this.button_selectPCBS);
            this.Controls.Add(this.Install_unitypatcher_Button);
            this.Controls.Add(this.textBox_path);
            this.Controls.Add(this.button_install);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "EZModInstaller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize) (this.timer_updatepath)).EndInit();
            this.ResumeLayout(false);
        }

        private MaterialSkin.Controls.MaterialButton Fix_Corrupted_Saves_Button;

        private MaterialSkin.Controls.MaterialCheckbox Debug_install_CB;

        private System.Timers.Timer timer_updatepath;

        private MaterialSkin.Controls.MaterialButton Restore_Save_Files;

        private MaterialSkin.Controls.MaterialButton button_selectPCBS;

        private MaterialSkin.Controls.MaterialButton Install_unitypatcher_Button;

        private MaterialSkin.Controls.MaterialTextBox textBox_path;
        
        private MaterialSkin.Controls.MaterialButton button_install;

        #endregion
    }
}