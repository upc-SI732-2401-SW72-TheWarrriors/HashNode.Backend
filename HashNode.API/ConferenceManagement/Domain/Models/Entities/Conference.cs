namespace HashNode.API.ConferenceManagement.Domain.Models.Entities
{
    public class Conference
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Conference()
        {
        }

        public Conference(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public Conference SaveConference(string title, string description)
        {
            Title = title;
            Description = description;
            return this;
        }
    }
}
