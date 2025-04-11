using System;
// Every video on here is Minecraft, because that's something I enjoy. 
// Also yes each of these are real videos
class Program
{
    static void Main(string[] args)
    {
        YouTube youtube = new YouTube();

        // Adds video titles, authors, lengths, and comments
        Video video1 = new Video("The STRANGEST Minecraft ARG Ever Uncovered", "Remedy", "1:58:58");
        video1.AddComment("me saying 'minecraft' randomly so the ai kicks in at the weirdest moments (im keeping mojang on their toes)");
        video1.AddComment("As a swedish person, hearing messed up audios in your own native language makes it so much more haunting");
        video1.AddComment("I feel the vibe of 'every copy of minecraft is personalized'");

        Video video2 = new Video("Minecraft Speedrunner VS 0 Hunters", "Dream", "39:42");
        video2.AddComment("Dude, the part where                      chased him and he got to half a heart was so intense!");
        video2.AddComment("Sap was taking a nap And George was not found");
        video2.AddComment("Dream vs the voices in his head");

        Video video3 = new Video("Skyblock: Potato War 3 (FINALE)", "Technoblade", "20:09");
        video3.AddComment("EZ CLAP");
        video3.AddComment("potato war trilogy has been a better experience than most movie trilogies");
        video3.AddComment("It’s sad to think that, that island will never be touched again");

        Video video4 = new Video("I Solved Your Terrible Minecraft Problems", "Knarfy", "22:27");
        video4.AddComment("3:52 the creeper is just reverted back to its original form");
        video4.AddComment("What we want: Gracefully weathered,wax-sealed weatherd copper door of the lasting castle What majang gave us: chiseled copper");
        video4.AddComment("Bro turns the merch ad into a full movie");

        // Adds the videos to YouTube
        youtube.AddVideo(video1);
        youtube.AddVideo(video2);
        youtube.AddVideo(video3);
        youtube.AddVideo(video4);

        // Prints video info
        foreach (var video in youtube.GetVideos())
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length}");
            Console.WriteLine($"Number of Comments: {video.CommentCount}");
            foreach (var comment in video.Comments)
            {
                Console.WriteLine($" - {comment}");
            }
            Console.WriteLine();
        }
    }
}