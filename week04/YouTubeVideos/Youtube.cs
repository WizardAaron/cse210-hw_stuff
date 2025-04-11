using System;
using System.Collections.Generic;

class YouTube
{
    private List<Video> _videos;

    public YouTube()
    {
        _videos = new List<Video>();
    }

    public void AddVideo(Video video)
    {
        _videos.Add(video);
    }

    public List<Video> GetVideos()
    {
        return _videos;
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Length { get; set; }
    public List<string> Comments { get; set; }

    public Video(string title, string author, string length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<string>();
    }

    public void AddComment(string comment)
    {
        Comments.Add(comment);
    }

    public int CommentCount => Comments.Count;
}