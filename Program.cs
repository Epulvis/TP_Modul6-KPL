internal class Program
{
    private static void Main(string[] args)
    {
        SayaTubeVideo video = new SayaTubeVideo("Tutorial Design By Contract - Mochammad Syaifuddin Zuhri");
        video.IncreasePlayCount(50);
        video.PrintVideoDetails();
    }
}

class SayaTubeVideo
{
    private int id, playCount;
    private string title;

    public SayaTubeVideo(string title)
    {
        Random random = new Random();
        this.id = random.Next(10000, 99999);
        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        playCount += count;
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine("Video ID: " + id);
        Console.WriteLine("Title: " + title);
        Console.WriteLine("Play Count: " + playCount);
    }
}
