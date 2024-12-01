module Year2024.Day01

open System.Collections.Generic
open System.Text.RegularExpressions

let left = ResizeArray([])
let right = ResizeArray([])
let appearances = Dictionary<int, int>()
let regex = Regex(@"\d+", RegexOptions.Compiled)
    
let collect (s: string) =
    let matches = regex.Matches(s)
    let lVal = int matches[0].Value
    let rVal = int matches[1].Value
    left.Add(lVal)
    right.Add(rVal)
    
    appearances[rVal] <- appearances.GetValueOrDefault(rVal, 0) + 1
    
let readInput () =
    Client.getInput 2024 1
    |> Seq.iter collect

let calcDistance (l, r) = abs (l - r)

let totalDistance () =
    left.Sort()
    right.Sort()
    
    Seq.zip left right
    |> Seq.map calcDistance
    |> Seq.sum
    
let calcSimilarity value =
    value * appearances.GetValueOrDefault(value, 0)

let similarityScore () = 
    left
    |> Seq.sumBy calcSimilarity

let run () =
    readInput ()
    printfn $"Day 01, Part one: %d{totalDistance()}"
    printfn $"Day 01, Part two: %d{similarityScore()}"
