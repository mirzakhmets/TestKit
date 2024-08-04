
namespace TestKit
{
  public class Stream
  {
    public int current;
    public System.IO.Stream stream;

    public Stream(System.IO.Stream stream)
    {
      this.stream = stream;
      this.Read();
    }

    public void Read()
    {
      if (this.current == -1)
        return;
      this.current = this.stream.ReadByte();
    }

    public bool atEnd() {
    	return this.current == -1;
    }
  }
}
