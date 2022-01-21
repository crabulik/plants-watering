public class Plant
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Location { get; set; }

    public WateringSchedule WateringSchedule { get; set; }

    public CommunicationChannel CommunicationChannel { get; set; }

    public Plant(int id, string name, string location, 
        WateringSchedule wateringSchedule,
        CommunicationChannel communicationChannel)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new DomainInitialisationException(
                $"Ctor initialisation error for {nameof(Plant)}. The argument {nameof(name)} is null or empty.");
        }
        if (string.IsNullOrEmpty(location))
        {
            throw new DomainInitialisationException(
                $"Ctor initialisation error for {nameof(Plant)}. The argument {nameof(location)} is null or empty.");
        }
        if (wateringSchedule == null)
        {
            throw new DomainInitialisationException(
                $"Ctor initialisation error for {nameof(Plant)}. The argument {nameof(wateringSchedule)} is null.");
        }
        if (communicationChannel == null)
        {
            throw new DomainInitialisationException(
                $"Ctor initialisation error for {nameof(Plant)}. The argument {nameof(communicationChannel)} is null.");
        }

        Id = id;
        Name = name;
        Location = location;
        WateringSchedule = wateringSchedule;
        CommunicationChannel = communicationChannel;
    }
}