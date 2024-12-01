module Tests.Year2024.Day01
open Xunit
open Year2024.Day01

let sample = """3   4
4   3
2   5
1   3
3   9
3   3"""

let initTest () =
    left.Clear()
    right.Clear()
    appearances.Clear()
    sample.Split("\n")

[<Theory>]
[<InlineData(1, 3, 2)>]
[<InlineData(2, 3, 1)>]
[<InlineData(3, 3, 0)>]
[<InlineData(3, 4, 1)>]
[<InlineData(3, 5, 2)>]
[<InlineData(4, 9, 5)>]
let ``Distance`` l r expected =
    Assert.Equal(expected, calcDistance (l, r))

[<Fact>]
let ``TotalDistance`` () =
    initTest()
    |> Seq.iter collect
    Assert.Equal(11, totalDistance())
    
[<Theory>]
[<InlineData(3, 9)>]
[<InlineData(4, 4)>]
[<InlineData(2, 0)>]
[<InlineData(1, 0)>]
let ``Similarity`` value expected =
    initTest()
    |> Seq.iter collect
    Assert.Equal(expected, calcSimilarity value)

[<Fact>]
let ``Similarity Score`` () =
    initTest()
    |> Seq.iter collect
    Assert.Equal(31, similarityScore())