
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

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
      ComponentResourceManager resources = new ComponentResourceManager(typeof (MainForm));
      this.folderBrowserDialog = new FolderBrowserDialog();
      this.tabControl = new TabControl();
      this.tabPageMain = new TabPage();
      this.buttonGenerate = new Button();
      this.buttonPath = new Button();
      this.textBoxPath = new TextBox();
      this.labelPath = new Label();
      this.richTextBoxMain = new RichTextBox();
      this.tabPageTest = new TabPage();
      this.webBrowser = new WebBrowser();
      this.tabControl.SuspendLayout();
      this.tabPageMain.SuspendLayout();
      this.tabPageTest.SuspendLayout();
      this.SuspendLayout();
      this.tabControl.Controls.Add((Control) this.tabPageMain);
      this.tabControl.Controls.Add((Control) this.tabPageTest);
      this.tabControl.Location = new Point(1, 3);
      this.tabControl.Name = "tabControl";
      this.tabControl.SelectedIndex = 0;
      this.tabControl.Size = new Size(548, 324);
      this.tabControl.TabIndex = 0;
      this.tabPageMain.Controls.Add((Control) this.buttonGenerate);
      this.tabPageMain.Controls.Add((Control) this.buttonPath);
      this.tabPageMain.Controls.Add((Control) this.textBoxPath);
      this.tabPageMain.Controls.Add((Control) this.labelPath);
      this.tabPageMain.Controls.Add((Control) this.richTextBoxMain);
      this.tabPageMain.Location = new Point(4, 22);
      this.tabPageMain.Name = "tabPageMain";
      this.tabPageMain.Padding = new Padding(3);
      this.tabPageMain.Size = new Size(540, 298);
      this.tabPageMain.TabIndex = 0;
      this.tabPageMain.Text = "Main";
      this.tabPageMain.UseVisualStyleBackColor = true;
      this.buttonGenerate.Location = new Point(227, 269);
      this.buttonGenerate.Name = "buttonGenerate";
      this.buttonGenerate.Size = new Size(75, 23);
      this.buttonGenerate.TabIndex = 4;
      this.buttonGenerate.Text = "Generate";
      this.buttonGenerate.UseVisualStyleBackColor = true;
      this.buttonGenerate.Click += new EventHandler(this.ButtonGenerateClick);
      this.buttonPath.Location = new Point(493, 24);
      this.buttonPath.Name = "buttonPath";
      this.buttonPath.Size = new Size(39, 20);
      this.buttonPath.TabIndex = 3;
      this.buttonPath.Text = "...";
      this.buttonPath.UseVisualStyleBackColor = true;
      this.buttonPath.Click += new EventHandler(this.ButtonPathClick);
      this.textBoxPath.Location = new Point(6, 24);
      this.textBoxPath.Name = "textBoxPath";
      this.textBoxPath.Size = new Size(481, 20);
      this.textBoxPath.TabIndex = 2;
      this.labelPath.Location = new Point(6, 3);
      this.labelPath.Name = "labelPath";
      this.labelPath.Size = new Size(113, 16);
      this.labelPath.TabIndex = 1;
      this.labelPath.Text = "Path:";
      this.richTextBoxMain.Location = new Point(7, 48);
      this.richTextBoxMain.Name = "richTextBoxMain";
      this.richTextBoxMain.Size = new Size(525, 220);
      this.richTextBoxMain.TabIndex = 0;
      this.richTextBoxMain.Text = "1+2 = ?:\n1;\n2;\n+3;\n4.\n\n1+3=?:\n1;\n2;\n3;\n+4.";
      this.tabPageTest.Controls.Add((Control) this.webBrowser);
      this.tabPageTest.Location = new Point(4, 22);
      this.tabPageTest.Name = "tabPageTest";
      this.tabPageTest.Padding = new Padding(3);
      this.tabPageTest.Size = new Size(540, 298);
      this.tabPageTest.TabIndex = 1;
      this.tabPageTest.Text = "Test";
      this.tabPageTest.UseVisualStyleBackColor = true;
      this.webBrowser.Dock = DockStyle.Fill;
      this.webBrowser.Location = new Point(3, 3);
      this.webBrowser.MinimumSize = new Size(20, 20);
      this.webBrowser.Name = "webBrowser";
      this.webBrowser.Size = new Size(534, 292);
      this.webBrowser.TabIndex = 0;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(549, 326);
      this.Controls.Add((Control) this.tabControl);
      this.Icon = (Icon) resources.GetObject("$this.Icon");
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
  }
}
