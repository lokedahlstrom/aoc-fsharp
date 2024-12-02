module Tests.Year2024.Day02
open Xunit
open Year2024.Day02
open Helpers

let sample = """
7 6 4 2 1
1 2 7 8 9
9 7 6 2 1
1 3 2 4 5
8 6 4 4 1
1 3 6 7 9
"""

let readSample () =
    sample.Trim().Split("\n")
    
[<Theory>]
[<InlineData("7 6 4 2 1", true)>]
[<InlineData("1 2 7 8 9", false)>]
[<InlineData("9 7 6 2 1", false)>]
[<InlineData("1 3 2 4 5", false)>]
[<InlineData("8 6 4 4 1", false)>]
[<InlineData("1 3 6 7 9", true)>]
let ``Safety Part One`` (line: string, expected) =
    let ints = stringToInts line
    Assert.Equal(expected, reportIsSafe ints)
    
[<Theory>]
[<InlineData("7 6 4 2 1", true)>]
[<InlineData("1 2 7 8 9", false)>]
[<InlineData("9 7 6 2 1", false)>]
[<InlineData("1 3 2 4 5", true)>]
[<InlineData("8 6 4 4 1", true)>]
[<InlineData("1 3 6 7 9", true)>]
[<InlineData("5 0 1 2 3", true)>]
[<InlineData("1 9 8 7 6", true)>]
[<InlineData("1 1 8 7 6", false)>]
[<InlineData("61 63 64 67 69 72 74 81", true)>]
[<InlineData("84 85 88 89 90 85", true)>]
let ``Safety Part Two`` (line: string, expected) =
    let ints = stringToInts line
    Assert.Equal(expected, reportIsSafe2 ints)
    
[<Fact>]
let ``Sample-Rows-PartOne`` () =
    Assert.Equal(2, partOne(readSample()))

[<Fact>]
let ``Sample-Rows-PartTwo`` () =
    Assert.Equal(4, partTwo(readSample()))