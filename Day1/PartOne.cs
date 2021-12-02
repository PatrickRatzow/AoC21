using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Day1;

public static class PartOneSolution
{
    public static int CountDayToDayIncreases(IList<int> data)
    {
        var count = 0;
        var previous = 0;

        for (var i = 1; i < data.Count; i++)
        {
            var day = data[i];
            if (day > previous)
                count++;
            

            previous = day;
        }

        return count;
    }
}

public class PartOne
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
        var expectedCount = 7;

        // Act
        var result = PartOneSolution.CountDayToDayIncreases(data);

        // Assert
        result.Should().Be(expectedCount);
    }
    
    [Test]
    public void TestPuzzleInput()
    {
        // Arrange
        var fileData = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "TestData.txt"));
        var data = fileData.Select(int.Parse).ToList();
        var expectedCount = 1521;

        // Act
        var result = PartOneSolution.CountDayToDayIncreases(data);

        // Assert
        result.Should().Be(expectedCount);
    }
}