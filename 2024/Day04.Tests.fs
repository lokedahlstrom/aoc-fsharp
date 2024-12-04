module Tests.Year2024.Day04
open Xunit
open Year2024.Day04

let sample = """
MMMSXXMASM
MSAMXMSMSA
AMXSXMAAMM
MSAMASMSMX
XMASAMXAMM
XXAMMXXAMA
SMSMSASXSS
SAXAMASAAA
MAMMMXMMMM
MXMXAXMASX
"""

let readSample () =
    sample.Trim().Split("\n")

[<Fact>]
let ``Sample-Rows-PartOne`` () =
    Assert.Equal(18, partOne(readSample()))

[<Fact>]
let ``Sample-Rows-PartTwo`` () =
    Assert.Equal(9, partTwo(readSample()))
    