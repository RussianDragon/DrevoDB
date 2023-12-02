namespace DrevoDB.DBProfiler.Abstractions;

public interface IProfilerResult
{
    TimeSpan RequestElapsed { get; }
    IReadOnlyDictionary<Phases, TimeSpan> ElapsedPhases { get; }
    TimeSpan Total { get; }
}
