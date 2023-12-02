using DrevoDB.DBProfiler.Abstractions;

namespace DrevoDB.DBProfiler;

public class Profiler : IProfiler
{
    private bool ProfilerIsActive { get; set; }
    private ProfilerPeriod RequestPeriod { get; }
    private Dictionary<Phases, Stack<ProfilerPeriod>> Phases { get; }

    IProfilerResult IProfiler.Result
    {
        get
        {
            var elapsedPhases = this.Phases.ToDictionary(phase => phase.Key,
                                                         phase => phase.Value.Aggregate(TimeSpan.Zero, (acum, item) => acum + item.Elapsed));
            return new ProfilerResult()
            {
                RequestElapsed = this.RequestPeriod.Elapsed,
                ElapsedPhases = elapsedPhases,
                Total = elapsedPhases.Aggregate(TimeSpan.Zero, (acum, phase) => acum + phase.Value)
            };
        }
    }

    public Profiler()
    {
        this.RequestPeriod = new ProfilerPeriod();
        this.Phases = Enum.GetValues<Phases>().ToDictionary(phase => phase, _ => new Stack<ProfilerPeriod>());
    }

    public void RequestStart(bool profilerIsActive)
    {
        this.ProfilerIsActive = profilerIsActive;
        this.RequestPeriod.Start = DateTime.UtcNow;
    }

    public void RequestEnd()
    {
        this.RequestPeriod.End = DateTime.UtcNow;
    }

    public void Start(Phases phase)
    {
        if (this.ProfilerIsActive)
        {
            this.Phases[phase].Push(new ProfilerPeriod()
            {
                Start = DateTime.UtcNow
            });
        }
    }

    public void End(Phases phase)
    {
        if (this.ProfilerIsActive)
        {
            this.Phases[phase].Peek().End = DateTime.UtcNow;
        }
    }
}
