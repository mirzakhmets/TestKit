/*
 * Created by SharpDevelop.
 * User: Mirzakhmet
 * Date: 2/26/2022
 * Time: 8:32 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;

namespace TestKit
{
	/// <summary>
	/// Question class.
	/// </summary>
	public class Question
	{
		public string text;
		public ArrayList answers = new ArrayList();
		
		public Question(Stream stream)
		{
			this.text = "";
			
			while (!stream.atEnd() && stream.current != ':') {
				this.text += (char) stream.current;
				
				stream.Read();
			}
			
			stream.Read();
			
			this.text = this.text.Trim();
			
			while (!stream.atEnd()) {
				Answer answer = new Answer(stream);
				
				this.answers.Add(answer);
				
				if (answer.isFinal) break;
			}
		}
	}
}
