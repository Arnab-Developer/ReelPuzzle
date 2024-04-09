namespace ReelPuzzle.Logic;

public interface IPuzzleSolver<T>
{
    public T? FinalData { get; }

    public void Solve(List<T> nums);
}