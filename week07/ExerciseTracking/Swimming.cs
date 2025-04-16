class Swimming : Activity
{
    private int _laps;
    private const double LapLengthMiles = 50 / 1000.0 * 0.62;

    public Swimming(string date, int durationMinutes, int laps)
        : base(date, durationMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * LapLengthMiles;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / GetDurationMinutes()) * 60;
    }

    public override double GetPace()
    {
        return GetDurationMinutes() / GetDistance();
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()}, Laps: {_laps}";
    }
}