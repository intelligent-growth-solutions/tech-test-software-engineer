namespace IgsSoftwareTechTest;

internal record Recipe(
    string Name )
{
    public List<LightingPhase> LightingPhases { get; } = new List<LightingPhase>();
    public List<WateringPhase> WateringPhases { get; } = new List<WateringPhase>();
}

internal abstract record Phase(string Name, short Order, short Hours, short Minutes, short Repetitions);

internal record LightingPhaseOperation(short OffsetHours, short OffsetMinutes, LightIntensity LightIntensity);

internal enum LightIntensity
{
    Off = 0,
    Low = 1,
    Medium = 2,
    High = 3
}

internal record WateringPhase(string Name, short Order, short Hours, short Minutes, short Repetitions, short Amount)
    : Phase(Name, Order, Hours, Minutes, Repetitions);

internal record LightingPhase(string Name, short Order, short Hours, short Minutes, short Repetitions)
    : Phase(Name, Order, Hours, Minutes, Repetitions)
{
    public IEnumerable<LightingPhaseOperation>? Operations { get; init; }
};
    
