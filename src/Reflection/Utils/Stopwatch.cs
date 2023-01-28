namespace Reflection.Utils;

public static class Stopwatch
{
    public static TimeSpan Duration { get; private set; }
    private static DateTime _startTime;
    private static DateTime _endTime;

    public static void Start()
    {
        if (_startTime > _endTime)
            throw new Exception("""Yoy need to launch the "Stop" method""");

        _startTime = DateTime.Now;
    }

    public static void Stop()
    {
        _endTime = DateTime.Now;

        Duration = _endTime - _startTime;

        if (Duration < TimeSpan.Zero)
        {
            throw new ArgumentException("""You need to launch the "Start" method""");
        }
    }
}
