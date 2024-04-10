namespace HashNode.API.ConferenceManagement.Domain.Commands
{
    public record CreateConferenceCommand
    (
        string Id,
        string Title,
        string Description
    )
    { }
}
