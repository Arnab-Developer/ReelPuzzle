namespace ReelPuzzle.Logic;

public class PuzzleSolver<T> : IPuzzleSolver<T>
{
    private bool _canTake = true;

    public T? FinalData { get; private set; }

    public void Solve(List<T> nums)
    {
        if (nums.Count == 1)
        {
            FinalData = nums[0];
            return;
        }

        var tempNums = new List<T>();

        for (var i = 0; i < nums.Count; i++)
        {
            if (_canTake) tempNums.Add(nums[i]);
            _canTake = !_canTake;
        }

        nums = new List<T>(tempNums);
        Solve(nums);
    }
}