public class Notifications
{
    public bool Success { get; set; }
    public List<string> Details { get; set; }
    public Notifications()
    {
        Details = new List<string>();
        Success = true;
    }
    public void Add(string detail)
    {
       if(Details != null)
         Details.Add(detail);
    }
    public int Count {
        get {
          return Details.Count;
        }
    }
}