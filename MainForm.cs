
#define TRIAL

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

#if TRIAL
using Microsoft.Win32;
#endif

namespace TestKit
{
  public class MainForm : Form
  {
    private IContainer components;
    private Button buttonGenerate;
    private Label labelPath;
    private TextBox textBoxPath;
    private Button buttonPath;
    private RichTextBox richTextBoxMain;
    private WebBrowser webBrowser;
    private TabPage tabPageTest;
    private TabPage tabPageMain;
    private TabControl tabControl;
    private FolderBrowserDialog folderBrowserDialog;

    #if TRIAL
    public void CheckRuns() {
		try {
			RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\OVG-Developers", true);
			
			int runs = -1;
			
			if (key != null && key.GetValue("Runs") != null) {
				runs = (int) key.GetValue("Runs");
			} else {
				key = Registry.CurrentUser.CreateSubKey("Software\\OVG-Developers");
			}
			
			runs = runs + 1;
			
			key.SetValue("Runs", runs);
			
			if (runs > 30) {
				System.Windows.Forms.MessageBox.Show("Number of runs expired.\n"
							+ "Please register the application (visit https://ovg-developers.mystrikingly.com/ for purchase).");
				
				Environment.Exit(0);
			}
		} catch (Exception e) {
			Console.WriteLine(e.Message);
		}
	}
	
	public bool IsRegistered() {
		try {
			RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\OVG-Developers");
			
			if (key != null && key.GetValue("Registered") != null) {
				return true;
			}
		} catch (Exception e) {
			Console.WriteLine(e.Message);
		}
		
		return false;
	}
    #endif
    
    public MainForm() {
    	this.InitializeComponent();
    }

    private void ButtonPathClick(object sender, EventArgs e)
    {
      if (this.folderBrowserDialog.ShowDialog() != DialogResult.OK)
        return;
      this.textBoxPath.Text = this.folderBrowserDialog.SelectedPath;
    }

    private void ButtonGenerateClick(object sender, EventArgs e)
    {
      Stream stream = new Stream((System.IO.Stream) new MemoryStream(Encoding.Default.GetBytes(this.richTextBoxMain.Text)));
      ArrayList arrayList = new ArrayList();
      while (!stream.atEnd())
      {
        Question question = new Question(stream);
        arrayList.Add((object) question);
      }
      string path = (this.textBoxPath.Text.Length > 0 ? this.textBoxPath.Text + "\\" : Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\") + "index.html";
      StreamWriter streamWriter = new StreamWriter(path);
      streamWriter.Write("<!doctype html><html><head><script>function calculate() {var a = [");
      int num1 = 0;
      int num2 = 0;
      foreach (Question question in arrayList)
      {
        ++num1;
        int num3 = 0;
        foreach (Answer answer in question.answers)
        {
          ++num3;
          if (answer.isCorrect)
          {
            if (num2 > 0)
              streamWriter.Write(", ");
            ++num2;
            streamWriter.Write("\"q" + (object) num1 + (object) num3 + "\"");
          }
        }
      }
      streamWriter.Write("];var c = 0, total = 0;for (var i in a) {var b = document.getElementById(a[i]);if (b.checked) {++c;}++total;}");
      streamWriter.Write("document.getElementById(\"result\").innerText = \"You scored \" + c + \" out of \" + total + \"\\n\" + \"Percentage: \" + (c / total).toFixed(2);}");
      streamWriter.Write("</script>");
      streamWriter.Write("</head>");
      streamWriter.Write("<body>");
      int num4 = 0;
      foreach (Question question in arrayList)
      {
        ++num4;
        int num5 = 0;
        streamWriter.Write("<p>" + question.text + "</p>");
        streamWriter.Write("<div>");
        foreach (Answer answer in question.answers)
        {
          ++num5;
          streamWriter.Write("<input type=\"radio\" name=\"q" + (object) num4 + "\" id=\"q" + (object) num4 + (object) num5 + "\">" + answer.text + "<br>");
        }
        streamWriter.Write("</div>");
      }
      streamWriter.Write("<h3><input type=\"button\" value=\"End\" onclick=\"calculate();\"><hr><div id=\"result\"></div></h3></body></html>");
      streamWriter.Close();
      this.webBrowser.Url = new Uri("file://" + path);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

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
    	this.tabControl.Location = new System.Drawing.Point(1, 4);
    	this.tabControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
    	this.tabControl.Name = "tabControl";
    	this.tabControl.SelectedIndex = 0;
    	this.tabControl.Size = new System.Drawing.Size(731, 399);
    	this.tabControl.TabIndex = 0;
    	// 
    	// tabPageMain
    	// 
    	this.tabPageMain.Controls.Add(this.buttonGenerate);
    	this.tabPageMain.Controls.Add(this.buttonPath);
    	this.tabPageMain.Controls.Add(this.textBoxPath);
    	this.tabPageMain.Controls.Add(this.labelPath);
    	this.tabPageMain.Controls.Add(this.richTextBoxMain);
    	this.tabPageMain.Location = new System.Drawing.Point(4, 25);
    	this.tabPageMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
    	this.tabPageMain.Name = "tabPageMain";
    	this.tabPageMain.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
    	this.tabPageMain.Size = new System.Drawing.Size(723, 370);
    	this.tabPageMain.TabIndex = 0;
    	this.tabPageMain.Text = "Main";
    	this.tabPageMain.UseVisualStyleBackColor = true;
    	// 
    	// buttonGenerate
    	// 
    	this.buttonGenerate.Location = new System.Drawing.Point(303, 331);
    	this.buttonGenerate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
    	this.buttonGenerate.Name = "buttonGenerate";
    	this.buttonGenerate.Size = new System.Drawing.Size(100, 28);
    	this.buttonGenerate.TabIndex = 4;
    	this.buttonGenerate.Text = "Generate";
    	this.buttonGenerate.UseVisualStyleBackColor = true;
    	this.buttonGenerate.Click += new System.EventHandler(this.ButtonGenerateClick);
    	// 
    	// buttonPath
    	// 
    	this.buttonPath.Location = new System.Drawing.Point(657, 30);
    	this.buttonPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
    	this.buttonPath.Name = "buttonPath";
    	this.buttonPath.Size = new System.Drawing.Size(52, 25);
    	this.buttonPath.TabIndex = 3;
    	this.buttonPath.Text = "...";
    	this.buttonPath.UseVisualStyleBackColor = true;
    	this.buttonPath.Click += new System.EventHandler(this.ButtonPathClick);
    	// 
    	// textBoxPath
    	// 
    	this.textBoxPath.Location = new System.Drawing.Point(8, 30);
    	this.textBoxPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
    	this.textBoxPath.Name = "textBoxPath";
    	this.textBoxPath.Size = new System.Drawing.Size(640, 22);
    	this.textBoxPath.TabIndex = 2;
    	// 
    	// labelPath
    	// 
    	this.labelPath.Location = new System.Drawing.Point(8, 4);
    	this.labelPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
    	this.labelPath.Name = "labelPath";
    	this.labelPath.Size = new System.Drawing.Size(151, 20);
    	this.labelPath.TabIndex = 1;
    	this.labelPath.Text = "Path:";
    	// 
    	// richTextBoxMain
    	// 
    	this.richTextBoxMain.Location = new System.Drawing.Point(9, 59);
    	this.richTextBoxMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
    	this.richTextBoxMain.Name = "richTextBoxMain";
    	this.richTextBoxMain.Size = new System.Drawing.Size(699, 270);
    	this.richTextBoxMain.TabIndex = 0;
    	this.richTextBoxMain.Text = "1+2 = ?:\n1;\n2;\n+3;\n4.\n\n1+3=?:\n1;\n2;\n3;\n+4.";
    	// 
    	// tabPageTest
    	// 
    	this.tabPageTest.Controls.Add(this.webBrowser);
    	this.tabPageTest.Location = new System.Drawing.Point(4, 25);
    	this.tabPageTest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
    	this.tabPageTest.Name = "tabPageTest";
    	this.tabPageTest.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
    	this.tabPageTest.Size = new System.Drawing.Size(723, 370);
    	this.tabPageTest.TabIndex = 1;
    	this.tabPageTest.Text = "Test";
    	this.tabPageTest.UseVisualStyleBackColor = true;
    	// 
    	// webBrowser
    	// 
    	this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
    	this.webBrowser.Location = new System.Drawing.Point(4, 4);
    	this.webBrowser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
    	this.webBrowser.MinimumSize = new System.Drawing.Size(27, 25);
    	this.webBrowser.Name = "webBrowser";
    	this.webBrowser.Size = new System.Drawing.Size(715, 362);
    	this.webBrowser.TabIndex = 0;
    	// 
    	// MainForm
    	// 
    	this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
    	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    	this.ClientSize = new System.Drawing.Size(732, 401);
    	this.Controls.Add(this.tabControl);
    	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
    	this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
    	this.MaximizeBox = false;
    	this.MinimizeBox = false;
    	this.Name = "MainForm";
    	this.Text = "TestKit";
    	this.Shown += new System.EventHandler(this.MainFormShown);
    	this.tabControl.ResumeLayout(false);
    	this.tabPageMain.ResumeLayout(false);
    	this.tabPageMain.PerformLayout();
    	this.tabPageTest.ResumeLayout(false);
    	this.ResumeLayout(false);

    }
		void MainFormShown(object sender, EventArgs e)
		{
			#if TRIAL
	      	if (!IsRegistered()) {
	    		CheckRuns();
	    	}
	    	#endif
		}
  }
}
