module Year2024.Day02
open Helpers

let input () = Client.getInput 2024 2
    
let safeDifference (l: int, r: int) =
    let delta = abs (l - r)
    delta = 1 || delta <= 3
    
let reportIsSafe (report: int[]) =
    let pairs = report |> Seq.pairwise
    
    if pairs |> Seq.forall (fun (prev, cur) -> (cur > prev) && (safeDifference (cur, prev))) then
        true
    else
        pairs |> Seq.forall (fun (prev, cur) -> (cur < prev) && (safeDifference (cur, prev)))
        
let reportIsSafe2 (report: int[]) =
    if reportIsSafe report then true
    else
        report
        |> Seq.mapi (fun index _ -> index)
        |> Seq.exists (fun i -> reportIsSafe (Array.removeAt i report))
        
let partOne data =  
    data
    |> Seq.map stringToInts
    |> Seq.filter reportIsSafe
    |> Seq.length
        
let partTwo data =
    data
    |> Seq.map stringToInts
    |> Seq.filter reportIsSafe2
    |> Seq.length
    
let run () =
    printfn $"Day 02, Part one: %d{partOne (input())}"
    printfn $"Day 02, Part two: %d{partTwo (input())}"
