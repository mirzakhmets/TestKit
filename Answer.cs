
namespace TestKit
{
  public class Answer
  {
    public string text;
    public bool isFinal;
    public bool isCorrect;

    public static void parseBlanks(Stream stream)
    {
      while (" \r\n\t\v".IndexOf((char) stream.current) >= 0 && !stream.atEnd())
        stream.Read();
    }

    public Answer(Stream stream)
    {
      Answer.parseBlanks(stream);
      if (stream.current == 43)
      {
        this.isCorrect = true;
        stream.Read();
      }
      this.text = "";
      while (!stream.atEnd() && stream.current != 59)
      {
        if (stream.current == 46)
        {
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
