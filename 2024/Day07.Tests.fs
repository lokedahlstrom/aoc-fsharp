module Tests.Year2024.Day07
open Xunit
open Year2024.Day07

let sample = """
"""

let readSample () =
    sample.Trim().Split("\n")

[<Fact>]
let ``Sample-Rows-PartOne`` () =
    Assert.Equal(0, partOne(readSample()))

[<Fact>]
let ``Sample-Rows-PartTwo`` () =
    Assert.Equal(0, partTwo(readSample()))