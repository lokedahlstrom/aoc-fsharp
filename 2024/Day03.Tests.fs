module Tests.Year2024.Day03
open System.Text.RegularExpressions
open Xunit
open Year2024.Day03

let sample = """
xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))
"""

let sample2 = """
xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))
"""

let readSample () =
    sample.Trim().Split("\n")
    
[<Fact>]
let ``Sample-Rows-PartOne`` () =
    let result = partOne (readSample())
    Assert.Equal(161, result)

[<Fact>]
let ``Sample-Rows-PartTwo`` () =
    Assert.Equal(48, partTwo(sample2.Split("\n")))
    