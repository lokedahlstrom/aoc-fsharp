module Year2024.Day03
open System.Text.RegularExpressions

let input () = Client.getInput 2024 3

let mulRegex = Regex(@"mul\(\d+\,\d+\)", RegexOptions.Compiled)
let digitsRegex = Regex(@"\d+", RegexOptions.Compiled)
let opRegex = Regex(@"don\'t\(\)|do\(\)|mul\(\d+\,\d+\)", RegexOptions.Compiled)

let multiply (s: string) =
    digitsRegex.Matches(s)
    |> Seq.map (fun (m: Match) -> Helpers.stringToInt(m.Value))    
    |> Seq.pairwise
    |> Seq.fold (fun acc (x, y) -> (x * y)) 0
    
let findOperations s =
    mulRegex.Matches(s)
    |> Seq.map (_.Value)

let findOperationsPartTwo s =
    opRegex.Matches(s)
    |> Seq.map (_.Value)
    
let processOperations (s: string) =
    findOperations s
    |> Seq.sumBy multiply

let partOne data =
    data
    |> Seq.sumBy processOperations

let partTwo data =
    let mutable isOn = true
    let mutable result = 0
    
    data
    |> Seq.map findOperationsPartTwo
    |> Seq.iter (fun operations ->
        operations
        |> Seq.iter (fun op ->            
            if op.Contains("don't") then
                isOn <- false
            else if op.Contains("do") then
                isOn <- true
            else if isOn then
                let dms = digitsRegex.Matches(op)
                let left = int dms[0].Value
                let right = int dms[1].Value
                
                result <- result + (left * right)
            )
        )
    result
    
let run () =
    printfn $"Day 03, Part one: %d{partOne (input())}"
    printfn $"Day 03, Part two: %d{partTwo (input())}"
