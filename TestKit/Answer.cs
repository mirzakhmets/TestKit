/*
 * Created by SharpDevelop.
 * User: Mirzakhmet
 * Date: 2/26/2022
 * Time: 8:33 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TestKit
{
	/// <summary>
	/// Answer class.
	/// </summary>
	public class Answer
	{
		public string text;
		public bool isFinal = false;
		public bool isCorrect = false;
		
		public static void parseBlanks(Stream stream) {
			while (" \r\n\t\v".IndexOf((char) stream.current) >= 0 && !stream.atEnd()) {
				stream.Read();
			}
		}
		
		public Answer(Stream stream)
		{
			parseBlanks(stream);
			
			if (stream.current == '+') {
				this.isCorrect = true;
				stream.Read();
			}
			
			this.text = "";
			
			while (!stream.atEnd() && stream.current != ';') {
				if (stream.current == '.') {
					this.isFinal = true;
					break;
				}
				
				this.text += (char) stream.current;
				
				stream.Read();
			}
			
			stream.Read();
			
			this.text = this.text.Trim();
		}
	}
}
