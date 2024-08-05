
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class TopItems
{
    [Key]
    public int TopItemsId { get; set; }
    public string href { get; set; }
    public int limit { get; set; }
    public string next { get; set; }
    public int offset { get; set; }
    public string previous { get; set; } = string.Empty;
    public int total { get; set; }
    [NotMapped]
    public Item[] items { get; set; }
    public IEnumerable<Item> itemsList { get; set; }  = new List<Item>();
}

public class Item
{
    [Key]
    public int ItemId { get; set; }
    public string href { get; set; }
    public IEnumerable<Image> images { get; set; } = new List<Image>();
    public string name { get; set; }
    public int popularity { get; set; }
    public string type { get; set; } = string.Empty;
    public string uri { get; set; } = string.Empty;
}




public class Image
{
    [Key]
    public int ImageId { get; set; }
    public string url { get; set; }
    public int height { get; set; }
    public int width { get; set; }
}
