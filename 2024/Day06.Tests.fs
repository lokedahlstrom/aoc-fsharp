module Tests.Year2024.Day06
open Xunit
open Year2024.Day06
open Helpers

let sample = """
....#.....
.........#
..........
..#.......
.......#..
..........
.#..^.....
........#.
#.........
......#...
"""

let readSample () =
    sample.Trim().Split("\n")
    
[<Fact>]
let ``Is Obstacle`` () =
    let map = parseGrid(readSample())
    Assert.True(map[0][4] = Obstacle)
    
[<Fact>]
let ``Find Guard`` () =
    let map = parseGrid(readSample())
    match findStartPos (map, Guard) with
    | Some(y, x) -> Assert.Equal((6, 4), (y, x))
    | None -> Assert.Fail()
    
[<Fact>]
let ``Sample-Rows-PartOne`` () =
    let _, count = partOne(readSample())
    Assert.Equal(41, count)

[<Fact>]
let ``Rotation of Delta`` () =
    let north = (-1, 0)
    
    let east = rotate90CW north
    let south = rotate90CW east
    let west = rotate90CW south
    let north = rotate90CW west
    
    Assert.Equal((0, 1), east)
    Assert.Equal((1, 0), south)
    Assert.Equal((0, -1), west)
    Assert.Equal((-1, 0), north)


[<Fact>]
let ``Sample-Rows-PartTwo`` () =
    let visited, _ = partOne(readSample())
    Assert.Equal(6, partTwo(readSample(), visited))
