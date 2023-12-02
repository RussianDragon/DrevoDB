
namespace DrevoDB.DBProfiler.Abstractions;

public interface IProfiler
{
    IProfilerResult Result { get; }

    void RequestStart(bool profilerIsActive);
    void RequestEnd();

    void Start(Phases phase);
    void End(Phases phase);
}
