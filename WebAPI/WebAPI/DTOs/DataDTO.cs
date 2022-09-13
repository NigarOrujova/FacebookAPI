namespace WebAPI.DTOs;

public class Cursors
{
    public string before { get; set; }
    public string after { get; set; }
}

public class Datum
{
    public DateTime created_time { get; set; }
    public int post_views { get; set; }
    public string id { get; set; }
    public string title { get; set; }
}

public class Paging
{
    public Cursors cursors { get; set; }
    public string next { get; set; }
}

public class Root
{
    public List<Datum> data { get; set; }
    public Paging paging { get; set; }
}