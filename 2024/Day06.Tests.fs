module Tests.Year2024.Day06
open Xunit
open Year2024.Day06
open Helpers

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
