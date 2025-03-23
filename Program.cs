using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        // Test 1: Valid object creation
        SayaTubeVideo validVideo = new SayaTubeVideo("Tutorial Design By Contract - Mochammad Syaifuddin Zuhri");
        validVideo.PrintVideoDetails();
        
        // Test 2: Invalid Judul (null)
        SayaTubeVideo invalidVideo1 = new SayaTubeVideo("");

        // Test 3: Invalid Judul (lebih dari 100 karakter)
        SayaTubeVideo invalidVideo2 = new SayaTubeVideo(new string('A', 101));

        // Test 4: IncreasePlayCount with valid value
        validVideo.IncreasePlayCount(5000000);

        // Test 5: IncreasePlayCount with invalid value (negative)
        validVideo.IncreasePlayCount(-1);

        // Test 6: IncreasePlayCount with invalid value (exceeding limit)
        validVideo.IncreasePlayCount(20000000);

        // Test 7: Overflow test
        for (int i = 0; i < 100; i++)
        {
            validVideo.IncreasePlayCount(10000000);
        }

    }
}

class SayaTubeVideo
{
    private int id, playCount;
    private string title;

    public SayaTubeVideo(string title)
    {
        Debug.Assert(!string.IsNullOrEmpty(title) && title.Length <= 100, "Judul video tidak boleh null dan lebih dari 100 karakter");
        Random random = new Random();
        this.id = random.Next(10000, 99999);
        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        Debug.Assert(count > 0 && count <= 10000000, "Penambahan play count harus antara 1 Hingga 10.000.000");

        try
        {
            checked
            {
                playCount += count;
            }
        }
        catch (OverflowException)
        {
            Console.WriteLine("Error: Play count melebihi batas!");
        }
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine("Video ID: " + id);
        Console.WriteLine("Title: " + title);
        Console.WriteLine("Play Count: " + playCount);
    }
}
