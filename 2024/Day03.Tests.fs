module Tests.Year2024.Day03
open Xunit
open Year2024.Day03

let sample = """

"""

let readSample () =
    sample.Trim().Split("\n")
    
[<Theory>]
[<InlineData("", true)>]
let ``Part One`` (line: string, expected) =
    Assert.Equal(expected, true)
    

[<Fact>]
let ``Sample-Rows-PartOne`` () =
    Assert.Equal(0, partOne(readSample()))

[<Fact>]
let ``Sample-Rows-PartTwo`` () =
    Assert.Equal(0, partTwo(readSample()))