
using PlantsWatering.Shared.Domain;

public abstract class WateringSchedule
{
    public abstract string Name {get;}

    
}

public class DailyWateringSchedule: WateringSchedule
{
    public override string Name  => "Daily";

    public int WateringHour{ get; private set;}

    public int WateringMinute{ get; private set;}


    public DailyWateringSchedule(int wateringHour, int wateringMinute)
    {
        if (wateringHour < DomainConstants.MinHourValue || wateringHour > DomainConstants.MaxHourValue)
        {
            throw new DomainInitialisationException(
                $"Ctor initialisation error for {nameof(DailyWateringSchedule)}. " +
                $"The argument {nameof(wateringHour)} = {wateringHour}. The value should be in the range from {DomainConstants.MinHourValue} to {DomainConstants.MaxHourValue}");
        }
        if (wateringMinute < DomainConstants.MinMinuteValue || wateringMinute > DomainConstants.MaxMinuteValue)
        {
            throw new DomainInitialisationException(
                $"Ctor initialisation error for {nameof(DailyWateringSchedule)}. " +
                $"The argument {nameof(wateringMinute)} = {wateringMinute}. The value should be in the range from {DomainConstants.MinMinuteValue} to {DomainConstants.MaxMinuteValue}");
        }
        WateringHour = wateringHour;
        WateringMinute = wateringMinute;
    }
}

public class HourlyWateringSchedule: WateringSchedule
{
    public override string Name => "Hourly";

    public int Rate{ get; private set;}

    public HourlyWateringSchedule(int rate)
    {
        if (rate < DomainConstants.HorlyMinRate || rate > DomainConstants.HorlyMaxRate)
        {
            throw new DomainInitialisationException(
                $"Ctor initialisation error for {nameof(HourlyWateringSchedule)}. " +
                $"The argument {nameof(rate)} = {rate}. The value should be in the range from {DomainConstants.HorlyMinRate} to {DomainConstants.HorlyMaxRate}");
        }

        Rate = rate;
    }
}

public class NotSetWateringSchedule : WateringSchedule
{
    public override string Name => "Not Set";
}