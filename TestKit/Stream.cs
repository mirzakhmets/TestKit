/*
 * Created by SharpDevelop.
 * User: Mirzakhmet
 * Date: 2/26/2022
 * Time: 9:41 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;

namespace TestKit
{
	/// <summary>
	/// Stream for parsing.
	/// </summary>
	public class Stream
	{
		public int current;
		public System.IO.Stream stream;
		
		public Stream(System.IO.Stream stream)
		{
			this.stream = stream;
			this.Read();
		}
		
		public void Read() {
			if (this.current != -1) {
				this.current = stream.ReadByte();
			}
		}
		
		public bool atEnd() {
			return this.current == -1;
		}
	}
}
