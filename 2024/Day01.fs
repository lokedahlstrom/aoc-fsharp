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
    
    match appearances.TryGetValue(rVal) with
    | true, value -> appearances[rVal] <- value + 1
    | false, _ -> appearances[rVal] <- 1
    
let readInput () =
    Client.getInput 2024 1
    |> Seq.iter collect
   
let totalDistance () =
    left.Sort()
    right.Sort()
    
    left
    |> Seq.mapi (fun index value -> abs (value - right[index]))
    |> Seq.sum

let similarityScore () = 
    left
    |> Seq.sumBy (fun value ->
        value *
            match appearances.TryGetValue(value) with
            | true, v -> v
            | false, _ -> 0
        )

let run () =
    readInput()
    printfn $"Day 01, Part one: %d{totalDistance()}"
    printfn $"Day 01, Part two: %d{similarityScore()}"
