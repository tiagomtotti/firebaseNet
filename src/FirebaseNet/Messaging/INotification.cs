namespace FirebaseNet.Messaging
{
    public interface INotification
    {
        string Title { get; set; } 
        string Body { get; set; }
        string Sound { get; set; }

        string ClickAction { get; set; }

        string BodyLocKey { get; set; }
        string BodyLocArgs { get; set; }

        string TitleLocKey { get; set; }
        string TitleLocArgs { get; set; }
        
    }
}