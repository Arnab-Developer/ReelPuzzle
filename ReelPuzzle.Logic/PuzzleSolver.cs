using System.Diagnostics.CodeAnalysis;

namespace ReelPuzzle.Logic;

public class PuzzleSolver<T> : IPuzzleSolver<T>
{
    private bool _canTake;
    private T? _finalData;

    [DisallowNull]
    public T? FinalData
    {
        get
        {
            return _finalData;
        }
        private set
        {
            _finalData = value;
        }
    }

    public PuzzleSolver()
    {
        ResetCanTake();
    }

    public void Solve(List<T> nums)
    {
        if (nums is null || nums.Count == 0)
        {
            throw new ArgumentNullException(nameof(nums));
        }

        if (nums.Count == 1)
        {
            FinalData = nums[0] ?? throw new ArgumentNullException(nameof(nums));
            ResetCanTake();
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

    private void ResetCanTake()
    {
        _canTake = true;
    }
}