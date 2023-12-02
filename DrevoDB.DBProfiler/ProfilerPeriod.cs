namespace DrevoDB.DBProfiler;

internal class ProfilerPeriod
{
    public DateTime? Start { get; set; } = null;
    public DateTime? End { get; set; } = null;

    public bool IsValid => this.Start.HasValue && this.End.HasValue;
    public TimeSpan Elapsed => this.IsValid 
        ? this.End!.Value - this.Start!.Value 
        : TimeSpan.Zero;
}