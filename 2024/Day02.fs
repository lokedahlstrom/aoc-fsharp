module Year2024.Day02

open System
open System.Security.AccessControl

let input () = Client.getInput 2024 2

let stringToInt s = int s
    
let stringToInts (line: string) =
    line.Split(" ")
    |> Array.map stringToInt
    
let safeDifference (l: int, r: int) =
    let delta = abs (l - r)
    delta = 1 || delta <= 3
    
let reportIsSafe (report: int[]) =
    let pairs = report |> Seq.pairwise
    
    if pairs |> Seq.forall (fun (prev, cur) -> (cur > prev) && (safeDifference (cur, prev))) then
        true
    else
        pairs |> Seq.forall (fun (prev, cur) -> (cur < prev) && (safeDifference (cur, prev)))

let partOne data =
    data
    |> Seq.map stringToInts
    |> Seq.fold (fun acc cur ->
        if reportIsSafe cur then
            acc + 1
        else
            acc
    ) 0
    
let reportIsSafe2 (report: int[]) =
    if not (reportIsSafe report) then
        report
        |> Seq.mapi (fun index _ -> index)
        |> Seq.exists (fun i ->
            let newReport = Array.append (report[..i-1]) (report[i+1..])
            reportIsSafe newReport
            )
    else
        true
        
let partTwo data =
    data
    |> Seq.map stringToInts
    |> Seq.fold (fun acc cur ->
        if reportIsSafe2 cur then
            acc + 1
        else
            acc
    ) 0
    
let run () =
    printfn $"Day 01, Part one: %d{partOne (input())}"
    printfn $"Day 01, Part two: %d{partTwo (input())}"
