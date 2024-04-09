using ReelPuzzle.Logic;

namespace ReelPuzzle.LogicTest;

public class PuzzleSolverTests
{
    [Theory]
    [InlineData(10, 5)]
    [InlineData(20, 9)]
    [InlineData(100, 73)]
    public void Can_return_proper_int_data(int input, int expectedOutput)
    {
        var nums = new List<int>();
        for (var i = 1; i <= input; i++) nums.Add(i);

        IPuzzleSolver<int> puzzleSolver = new PuzzleSolver<int>();
        puzzleSolver.Solve(nums);

        Assert.Equal(expectedOutput, puzzleSolver.FinalData);
    }

    [Theory]
    [InlineData(10, 5)]
    [InlineData(20, 9)]
    [InlineData(100, 73)]
    public void Can_return_proper_double_data(double input, double expectedOutput)
    {
        var nums = new List<double>();
        for (var i = 1; i <= input; i++) nums.Add(i);

        IPuzzleSolver<double> puzzleSolver = new PuzzleSolver<double>();
        puzzleSolver.Solve(nums);

        Assert.Equal(expectedOutput, puzzleSolver.FinalData);
    }

    [Theory]
    [InlineData("10", "5")]
    [InlineData("20", "9")]
    [InlineData("100", "73")]
    public void Can_return_proper_string_data(string input, string expectedOutput)
    {
        var nums = new List<string>();
        for (var i = 1; i <= int.Parse(input); i++) nums.Add(i.ToString());

        IPuzzleSolver<string> puzzleSolver = new PuzzleSolver<string>();
        puzzleSolver.Solve(nums);

        Assert.Equal(expectedOutput, puzzleSolver.FinalData);
    }

    [Fact]
    public void Can_take_reset_properly()
    {
        IPuzzleSolver<int> puzzleSolver = new PuzzleSolver<int>();
        
        var nums = new List<int>();
        for (var i = 1; i <= 100; i++) nums.Add(i);
        puzzleSolver.Solve(nums);
        Assert.Equal(73, puzzleSolver.FinalData);

        var nums1 = new List<int>();
        for (var i = 1; i <= 100; i++) nums1.Add(i);
        puzzleSolver.Solve(nums1);
        Assert.Equal(73, puzzleSolver.FinalData);
    }
}