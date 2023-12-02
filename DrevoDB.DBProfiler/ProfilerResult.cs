using DrevoDB.DBProfiler.Abstractions;

namespace DrevoDB.DBProfiler;

internal record ProfilerResult : IProfilerResult
{
    public TimeSpan RequestElapsed { get; init; }
    public required IReadOnlyDictionary<Phases, TimeSpan> ElapsedPhases { get; init; }
    public required TimeSpan Total { get; init; }
}
