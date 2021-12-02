using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Day1;

public static class PartTwoSolution
{
    public static int CountIncreasesEveryThreeDays(IList<int> data)
    {
        var count = 0;
        var previous = 0;
        
        var numbers = new int[3];
        for (var i = 0; i < data.Count; i++)
        {
            if (i < 2) continue;

            numbers[0] = data[i - 2];
            numbers[1] = data[i - 1];
            numbers[2] = data[i];
            
            var sum = numbers.Sum();
            if (sum > previous && previous is not 0)
                count++;

            previous = sum;
        }

        return count;
    }
}

public class PartTwo
{
    [Test]
    public void TestExample()
    {
        // Arrange
        var data = new List<int>
        {
            199,
            200,
            208,
            210,
            200,
            207,
            240,
            269,
            260,
            263
        };
        var expectedCount = 5;

        // Act
        var result = PartTwoSolution.CountIncreasesEveryThreeDays(data);

        // Assert
        result.Should().Be(expectedCount);
    }
    
    [Test]
    public void TestPuzzleInput()
    {
        // Arrange
        var fileData = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "TestData.txt"));
        var data = fileData.Select(int.Parse).ToList();
        var expectedCount = 1543;

        // Act
        var result = PartTwoSolution.CountIncreasesEveryThreeDays(data);

        // Assert
        result.Should().Be(expectedCount);
    }
}