module AOC._2024.Day01_Tests
open Xunit

[<Theory>]
[<InlineData("1abc2", 12)>]
[<InlineData("pqr3stu8vwx", 38)>]
[<InlineData("a1b2c3d4e5f", 15)>]
[<InlineData("treb7uchet", 77)>]
let ``Sample-Rows-PartOne`` (line: string, expected: int) =
    let x = Year2023.Day01.partOne line
    Assert.Equal(expected, x)
    
[<Theory>]
[<InlineData("two1nine", 29)>]
[<InlineData("eightwothree", 83)>]
[<InlineData("abcone2threexyz", 13)>]
[<InlineData("xtwone3four", 24)>]
[<InlineData("4nineeightseven2", 42)>]
[<InlineData("zoneight234", 14)>]
[<InlineData("7pqrstsixteen", 76)>]
let ``Sample-Rows-PartTwo`` (line: string, expected: int) =
    let x = Year2023.Day01.partTwo line
    Assert.Equal(expected, x)
    
[<Theory>]
[<InlineData("oneight", 18)>]
[<InlineData("threeight", 38)>]
let ``Combined-Numbers`` (line: string, expected: int) =
    let x = Year2023.Day01.partTwo line
    Assert.Equal(expected, x)
