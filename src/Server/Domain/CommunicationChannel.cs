public class CommunicationChannel
{
    public string Id { get; private set; }

    public string Name { get; private set; }

    public CommunicationChannel(string id, string name)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new DomainInitialisationException(
                $"Ctor initialisation error for {nameof(CommunicationChannel)}. The argument {nameof(id)} is null or empty.");
        }

        if (string.IsNullOrEmpty(name))
        {
            throw new DomainInitialisationException(
                $"Ctor initialisation error for {nameof(CommunicationChannel)}. The argument {nameof(name)} is null or empty.");
        }

        Id = id;
        Name = name;
    }
}