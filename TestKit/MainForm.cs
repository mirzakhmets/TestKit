/*
 * Created by SharpDevelop.
 * User: Mirzakhmet
 * Date: 2/26/2022
 * Time: 6:54 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TestKit
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void ButtonPathClick(object sender, EventArgs e)
		{
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK) {
				textBoxPath.Text = folderBrowserDialog.SelectedPath;
			}
		}
		
		void ButtonGenerateClick(object sender, EventArgs e)
		{
			Stream stream = new Stream(new System.IO.MemoryStream(System.Text.Encoding.Default.GetBytes(richTextBoxMain.Text)));
			
			ArrayList questions = new ArrayList();
			
			while (!stream.atEnd()) {
				Question question = new Question(stream);
				
				questions.Add(question);
			}
			
			string path = (textBoxPath.Text.Length > 0 ? (textBoxPath.Text + "\\") : System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\") + "index.html";
			
			System.IO.StreamWriter sw = new System.IO.StreamWriter(path);
			
			sw.Write(@"<!doctype html><html><head><script>function calculate() {var a = [");
			
			int questionIndex = 0;
			int correctAnswerIndex = 0;
			
			foreach (Question q in questions) {
				++questionIndex;
				
				int answerIndex = 0;
				
				foreach (Answer a in q.answers) {
					++answerIndex;
					
					if (a.isCorrect) {
						if (correctAnswerIndex > 0) {
							sw.Write(", ");
						}
						
						++correctAnswerIndex;
						
						sw.Write("\"q" + questionIndex + answerIndex + "\"");
					}
				}
			}
			
			sw.Write(@"];var c = 0, total = 0;for (var i in a) {var b = document.getElementById(a[i]);if (b.checked) {++c;}++total;}");
			
			sw.Write("document.getElementById(\"result\").innerText = \"You scored \" + c + \" out of \" + total + \"\\n\" + \"Percentage: \" + (c / total).toFixed(2);}");
			
			sw.Write("</script>");
			
			sw.Write("</head>");
			
			sw.Write("<body>");
			
			questionIndex = 0;
			
			foreach (Question q in questions) {
				++questionIndex;
				
				int answerIndex = 0;
				
				sw.Write("<p>" + q.text + "</p>");
				
				sw.Write("<div>");
				
				foreach (Answer a in q.answers) {
					++answerIndex;
					
					sw.Write("<input type=\"radio\" name=\"q" + questionIndex + "\" id=\"q" + questionIndex + "" + answerIndex + "\">" + a.text + "<br>");
				}
				
				sw.Write("</div>");
			}
			
			sw.Write("<h3><input type=\"button\" value=\"End\" onclick=\"calculate();\"><hr><div id=\"result\"></div></h3></body></html>");
			
			sw.Close();
			
			webBrowser.Url = new Uri("file://" + path);
		}
	}
}
