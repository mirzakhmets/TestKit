/*
 * Created by SharpDevelop.
 * User: Mirzakhmet
 * Date: 2/26/2022
 * Time: 6:54 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace TestKit
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageMain = new System.Windows.Forms.TabPage();
			this.buttonGenerate = new System.Windows.Forms.Button();
			this.buttonPath = new System.Windows.Forms.Button();
			this.textBoxPath = new System.Windows.Forms.TextBox();
			this.labelPath = new System.Windows.Forms.Label();
			this.richTextBoxMain = new System.Windows.Forms.RichTextBox();
			this.tabPageTest = new System.Windows.Forms.TabPage();
			this.webBrowser = new System.Windows.Forms.WebBrowser();
			this.tabControl.SuspendLayout();
			this.tabPageMain.SuspendLayout();
			this.tabPageTest.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPageMain);
			this.tabControl.Controls.Add(this.tabPageTest);
			this.tabControl.Location = new System.Drawing.Point(1, 3);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(548, 324);
			this.tabControl.TabIndex = 0;
			// 
			// tabPageMain
			// 
			this.tabPageMain.Controls.Add(this.buttonGenerate);
			this.tabPageMain.Controls.Add(this.buttonPath);
			this.tabPageMain.Controls.Add(this.textBoxPath);
			this.tabPageMain.Controls.Add(this.labelPath);
			this.tabPageMain.Controls.Add(this.richTextBoxMain);
			this.tabPageMain.Location = new System.Drawing.Point(4, 22);
			this.tabPageMain.Name = "tabPageMain";
			this.tabPageMain.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageMain.Size = new System.Drawing.Size(540, 298);
			this.tabPageMain.TabIndex = 0;
			this.tabPageMain.Text = "Main";
			this.tabPageMain.UseVisualStyleBackColor = true;
			// 
			// buttonGenerate
			// 
			this.buttonGenerate.Location = new System.Drawing.Point(227, 269);
			this.buttonGenerate.Name = "buttonGenerate";
			this.buttonGenerate.Size = new System.Drawing.Size(75, 23);
			this.buttonGenerate.TabIndex = 4;
			this.buttonGenerate.Text = "Generate";
			this.buttonGenerate.UseVisualStyleBackColor = true;
			this.buttonGenerate.Click += new System.EventHandler(this.ButtonGenerateClick);
			// 
			// buttonPath
			// 
			this.buttonPath.Location = new System.Drawing.Point(493, 24);
			this.buttonPath.Name = "buttonPath";
			this.buttonPath.Size = new System.Drawing.Size(39, 20);
			this.buttonPath.TabIndex = 3;
			this.buttonPath.Text = "...";
			this.buttonPath.UseVisualStyleBackColor = true;
			this.buttonPath.Click += new System.EventHandler(this.ButtonPathClick);
			// 
			// textBoxPath
			// 
			this.textBoxPath.Location = new System.Drawing.Point(6, 24);
			this.textBoxPath.Name = "textBoxPath";
			this.textBoxPath.Size = new System.Drawing.Size(481, 20);
			this.textBoxPath.TabIndex = 2;
			// 
			// labelPath
			// 
			this.labelPath.Location = new System.Drawing.Point(6, 3);
			this.labelPath.Name = "labelPath";
			this.labelPath.Size = new System.Drawing.Size(113, 16);
			this.labelPath.TabIndex = 1;
			this.labelPath.Text = "Path:";
			// 
			// richTextBoxMain
			// 
			this.richTextBoxMain.Location = new System.Drawing.Point(7, 48);
			this.richTextBoxMain.Name = "richTextBoxMain";
			this.richTextBoxMain.Size = new System.Drawing.Size(525, 220);
			this.richTextBoxMain.TabIndex = 0;
			this.richTextBoxMain.Text = "1+2 = ?:\n1;\n2;\n+3;\n4.\n\n1+3=?:\n1;\n2;\n3;\n+4.";
			// 
			// tabPageTest
			// 
			this.tabPageTest.Controls.Add(this.webBrowser);
			this.tabPageTest.Location = new System.Drawing.Point(4, 22);
			this.tabPageTest.Name = "tabPageTest";
			this.tabPageTest.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageTest.Size = new System.Drawing.Size(540, 298);
			this.tabPageTest.TabIndex = 1;
			this.tabPageTest.Text = "Test";
			this.tabPageTest.UseVisualStyleBackColor = true;
			// 
			// webBrowser
			// 
			this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.webBrowser.Location = new System.Drawing.Point(3, 3);
			this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser.Name = "webBrowser";
			this.webBrowser.Size = new System.Drawing.Size(534, 292);
			this.webBrowser.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(549, 326);
			this.Controls.Add(this.tabControl);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.Text = "TestKit";
			this.tabControl.ResumeLayout(false);
			this.tabPageMain.ResumeLayout(false);
			this.tabPageMain.PerformLayout();
			this.tabPageTest.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button buttonGenerate;
		private System.Windows.Forms.Label labelPath;
		private System.Windows.Forms.TextBox textBoxPath;
		private System.Windows.Forms.Button buttonPath;
		private System.Windows.Forms.RichTextBox richTextBoxMain;
		private System.Windows.Forms.WebBrowser webBrowser;
		private System.Windows.Forms.TabPage tabPageTest;
		private System.Windows.Forms.TabPage tabPageMain;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
	}
}
