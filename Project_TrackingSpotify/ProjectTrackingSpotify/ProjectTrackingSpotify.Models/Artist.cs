﻿
public class Artist
{
    public External_Urls external_urls { get; set; }
    public Followers followers { get; set; }
    public string[] genres { get; set; }
    public string href { get; set; }
    public string id { get; set; }
    public Image[] images { get; set; }
    public string name { get; set; }
    public int popularity { get; set; }
    public string type { get; set; }
    public string uri { get; set; }
}


public class ImageArtist
{
    public string url { get; set; }
    public int height { get; set; }
    public int width { get; set; }
}
