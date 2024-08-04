
using System.Collections;

namespace TestKit
{
  public class Question
  {
    public string text;
    public ArrayList answers = new ArrayList();

    public Question(Stream stream)
    {
      this.text = "";
      while (!stream.atEnd() && stream.current != 58)
      {
        this.text += (char) stream.current;
        stream.Read();
      }
      stream.Read();
      this.text = this.text.Trim();
      while (!stream.atEnd())
      {
        Answer answer = new Answer(stream);
        this.answers.Add((object) answer);
        if (answer.isFinal)
          break;
      }
    }
  }
}
