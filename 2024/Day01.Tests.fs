module Tests.Year2024.Day01
open Xunit
open Year2024.Day01

let sample = """3   4
4   3
2   5
1   3
3   9
3   3"""

[<Fact>]
let ``TotalDistance`` () =
    left.Clear()
    right.Clear()
    appearances.Clear()
    
    sample.Split("\n")
    |> Seq.iter collect
    Assert.Equal(11, totalDistance())

[<Fact>]
let ``Similarity Score`` () =
    left.Clear()
    right.Clear()
    appearances.Clear()
    
    sample.Split("\n")
    |> Seq.iter collect
    Assert.Equal(31, similarityScore())