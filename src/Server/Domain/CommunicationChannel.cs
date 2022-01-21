public class CommunicationChannel
{
    public int Id { get; private set; }

    public string Name { get; private set; }

    public CommunicationChannel(int id, string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new DomainInitialisationException(
                $"Ctor initialisation error for {nameof(CommunicationChannel)}. The argument {nameof(name)} is null or empty.");
        }

        Id = id;
        Name = name;
    }
}