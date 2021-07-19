
namespace SimpleClassicTheme.ControlPanel.InputLanguages.Forms
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.settingsTab = new System.Windows.Forms.TabPage();
            this.defaultInputLanguageGroupBox = new System.Windows.Forms.GroupBox();
            this.defaultInputLanguageComboBox = new System.Windows.Forms.ComboBox();
            this.defaultInputLanguageLabel = new System.Windows.Forms.Label();
            this.installedServicesGroupBox = new System.Windows.Forms.GroupBox();
            this.propertiesButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.treeView = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.preferencesGroupBox = new System.Windows.Forms.GroupBox();
            this.keySettingsButton = new System.Windows.Forms.Button();
            this.languageBarButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.settingsTab.SuspendLayout();
            this.defaultInputLanguageGroupBox.SuspendLayout();
            this.installedServicesGroupBox.SuspendLayout();
            this.preferencesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.settingsTab);
            this.tabControl1.Location = new System.Drawing.Point(6, 7);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(386, 410);
            this.tabControl1.TabIndex = 0;
            // 
            // settingsTab
            // 
            this.settingsTab.Controls.Add(this.defaultInputLanguageGroupBox);
            this.settingsTab.Controls.Add(this.installedServicesGroupBox);
            this.settingsTab.Controls.Add(this.preferencesGroupBox);
            this.settingsTab.Location = new System.Drawing.Point(4, 22);
            this.settingsTab.Name = "settingsTab";
            this.settingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.settingsTab.Size = new System.Drawing.Size(378, 384);
            this.settingsTab.TabIndex = 0;
            this.settingsTab.Text = "Settings";
            this.settingsTab.UseVisualStyleBackColor = true;
            // 
            // defaultInputLanguageGroupBox
            // 
            this.defaultInputLanguageGroupBox.Controls.Add(this.defaultInputLanguageComboBox);
            this.defaultInputLanguageGroupBox.Controls.Add(this.defaultInputLanguageLabel);
            this.defaultInputLanguageGroupBox.Location = new System.Drawing.Point(11, 12);
            this.defaultInputLanguageGroupBox.Name = "defaultInputLanguageGroupBox";
            this.defaultInputLanguageGroupBox.Size = new System.Drawing.Size(357, 85);
            this.defaultInputLanguageGroupBox.TabIndex = 2;
            this.defaultInputLanguageGroupBox.TabStop = false;
            this.defaultInputLanguageGroupBox.Text = "Default input language";
            // 
            // defaultInputLanguageComboBox
            // 
            this.defaultInputLanguageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.defaultInputLanguageComboBox.Enabled = false;
            this.defaultInputLanguageComboBox.FormattingEnabled = true;
            this.defaultInputLanguageComboBox.Location = new System.Drawing.Point(10, 53);
            this.defaultInputLanguageComboBox.Name = "defaultInputLanguageComboBox";
            this.defaultInputLanguageComboBox.Size = new System.Drawing.Size(336, 21);
            this.defaultInputLanguageComboBox.TabIndex = 1;
            // 
            // defaultInputLanguageLabel
            // 
            this.defaultInputLanguageLabel.Location = new System.Drawing.Point(7, 16);
            this.defaultInputLanguageLabel.Name = "defaultInputLanguageLabel";
            this.defaultInputLanguageLabel.Size = new System.Drawing.Size(339, 37);
            this.defaultInputLanguageLabel.TabIndex = 0;
            this.defaultInputLanguageLabel.Text = "Select one of the installed input languages to use when you start your computer.";
            // 
            // installedServicesGroupBox
            // 
            this.installedServicesGroupBox.Controls.Add(this.propertiesButton);
            this.installedServicesGroupBox.Controls.Add(this.removeButton);
            this.installedServicesGroupBox.Controls.Add(this.addButton);
            this.installedServicesGroupBox.Controls.Add(this.treeView);
            this.installedServicesGroupBox.Controls.Add(this.label2);
            this.installedServicesGroupBox.Location = new System.Drawing.Point(11, 107);
            this.installedServicesGroupBox.Name = "installedServicesGroupBox";
            this.installedServicesGroupBox.Size = new System.Drawing.Size(357, 202);
            this.installedServicesGroupBox.TabIndex = 1;
            this.installedServicesGroupBox.TabStop = false;
            this.installedServicesGroupBox.Text = "Installed services";
            // 
            // propertiesButton
            // 
            this.propertiesButton.Location = new System.Drawing.Point(274, 168);
            this.propertiesButton.Name = "propertiesButton";
            this.propertiesButton.Size = new System.Drawing.Size(75, 23);
            this.propertiesButton.TabIndex = 4;
            this.propertiesButton.Text = "Properties...";
            this.propertiesButton.UseVisualStyleBackColor = true;
            // 
            // removeButton
            // 
            this.removeButton.Enabled = false;
            this.removeButton.Location = new System.Drawing.Point(274, 138);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 23);
            this.removeButton.TabIndex = 3;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(274, 109);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Add...";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // treeView
            // 
            this.treeView.HideSelection = false;
            this.treeView.Location = new System.Drawing.Point(10, 52);
            this.treeView.Name = "treeView";
            this.treeView.ShowLines = false;
            this.treeView.ShowPlusMinus = false;
            this.treeView.ShowRootLines = false;
            this.treeView.Size = new System.Drawing.Size(255, 138);
            this.treeView.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(7, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(345, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "Select the services that you want for each input language shown in the list. Use " +
    "the Add and Remove buttons to modify this list.";
            // 
            // preferencesGroupBox
            // 
            this.preferencesGroupBox.Controls.Add(this.keySettingsButton);
            this.preferencesGroupBox.Controls.Add(this.languageBarButton);
            this.preferencesGroupBox.Location = new System.Drawing.Point(11, 318);
            this.preferencesGroupBox.Name = "preferencesGroupBox";
            this.preferencesGroupBox.Size = new System.Drawing.Size(357, 54);
            this.preferencesGroupBox.TabIndex = 0;
            this.preferencesGroupBox.TabStop = false;
            this.preferencesGroupBox.Text = "Preferences";
            // 
            // keySettingsButton
            // 
            this.keySettingsButton.Enabled = false;
            this.keySettingsButton.Location = new System.Drawing.Point(127, 20);
            this.keySettingsButton.Name = "keySettingsButton";
            this.keySettingsButton.Size = new System.Drawing.Size(104, 23);
            this.keySettingsButton.TabIndex = 1;
            this.keySettingsButton.Text = "Key Settings...";
            this.keySettingsButton.UseVisualStyleBackColor = true;
            // 
            // languageBarButton
            // 
            this.languageBarButton.Enabled = false;
            this.languageBarButton.Location = new System.Drawing.Point(10, 20);
            this.languageBarButton.Name = "languageBarButton";
            this.languageBarButton.Size = new System.Drawing.Size(104, 23);
            this.languageBarButton.TabIndex = 0;
            this.languageBarButton.Text = "Language Bar...";
            this.languageBarButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(155, 423);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(236, 423);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(317, 423);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Apply";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 453);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Text Services and Input Languages";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.settingsTab.ResumeLayout(false);
            this.defaultInputLanguageGroupBox.ResumeLayout(false);
            this.installedServicesGroupBox.ResumeLayout(false);
            this.preferencesGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage settingsTab;
        private System.Windows.Forms.GroupBox defaultInputLanguageGroupBox;
        private System.Windows.Forms.ComboBox defaultInputLanguageComboBox;
        private System.Windows.Forms.Label defaultInputLanguageLabel;
        private System.Windows.Forms.GroupBox installedServicesGroupBox;
        private System.Windows.Forms.Button propertiesButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox preferencesGroupBox;
        private System.Windows.Forms.Button keySettingsButton;
        private System.Windows.Forms.Button languageBarButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button button3;
    }
}

