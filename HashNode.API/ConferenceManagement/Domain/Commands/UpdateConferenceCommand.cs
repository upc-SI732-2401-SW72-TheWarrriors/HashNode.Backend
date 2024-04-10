namespace HashNode.API.ConferenceManagement.Domain.Commands
{
    public record UpdateConferenceCommand
    (
        string Title, 
        string Description
    )
    { }
}
