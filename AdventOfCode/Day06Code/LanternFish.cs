namespace AdventOfCode.Day06Code;

public class LanternFish
{
    private int _daysToNewFish;

    public LanternFish(int daysToNewFish)
    {
        _daysToNewFish = daysToNewFish;
    }

    public LanternFish ElapseDay()
    {
        if (_daysToNewFish == 0)
        {
            _daysToNewFish = 6;
            return new LanternFish(8);
        }

        _daysToNewFish--;
        return null;
    }
}