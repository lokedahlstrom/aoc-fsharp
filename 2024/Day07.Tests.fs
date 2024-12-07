module Tests.Year2024.Day07
open Xunit
open Year2024.Day07

let sample = """
190: 10 19
3267: 81 40 27
83: 17 5
156: 15 6
7290: 6 8 6 15
161011: 16 10 13
192: 17 8 14
21037: 9 7 18 13
292: 11 6 16 20
"""

let readSample () =
    sample.Trim().Split("\n")
    
[<Fact>]
let ``Sample-Rows-PartOne`` () =
    Assert.Equal(3749I, partOne(readSample()))

[<Fact>]
let ``Sample-Rows-PartTwo`` () =
    Assert.Equal(11387I, partTwo(readSample()))
