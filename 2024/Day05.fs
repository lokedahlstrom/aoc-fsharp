module Year2024.Day05
open System.Collections.Generic
open System.Text.RegularExpressions

let input () = Client.getInputAsString 2024 5

let inputRegex = Regex(@"(?<rules>.*\n)+^$\n(?<updates>.*\n?)+", RegexOptions.Multiline)
    
let parseRules (m: Match) =
    m.Groups["rules"].Captures
    |> Seq.map (fun o -> o.Value.Trim().Split("|") |> Seq.map int |> Seq.toArray)
    |> Seq.toArray
    
let parseUpdates (m: Match) =
    m.Groups["updates"].Captures
    |> Seq.filter (fun x -> x.Length > 1)
    |> Seq.map (fun o -> o.Value.Trim().Split(",") |> Seq.map int |> Seq.toArray)
    |> Seq.toArray

let correctOrder (update: int[], rules: int[][]) =
    update
    |> Seq.mapi (fun index number -> (index, number))
    |> Seq.forall (fun (index, number) ->
        rules
        |> Seq.filter (fun r -> r[0] = number)
        |> Seq.forall (fun r ->
            let leftPart = update[..index-1]
            not (Array.contains r[1] leftPart)
            )
    )
    
let partOne data =
    let m = inputRegex.Match(data)
    
    let rules = parseRules m 
    let updates = parseUpdates m
            
    updates
    |> Seq.filter (fun u -> correctOrder(u, rules))
    |> Seq.sumBy (fun update -> update[update.Length / 2])
    
let partTwo data =
    let m = inputRegex.Match(data)
    
    let rules = parseRules m 
    let updates = parseUpdates m
    
    let fixOrder (update: int[]) =
        let pre = Dictionary()
        
        rules
        // only relevant rules
        |> Seq.filter (fun r -> (Array.contains r[0] update) && (Array.contains r[1] update))
        // build precedence map
        |> Seq.iter (fun r ->
            let l, r = r[0], r[1]
            pre.TryAdd(l, HashSet()) |> ignore
            pre.TryAdd(r, HashSet()) |> ignore
            pre[r].Add(l) |> ignore
            )
        
        let comparer l r =
            if pre.ContainsKey l && pre[l].Contains r then
                1 
            elif pre.ContainsKey r && pre[r].Contains l then
                -1
            else
                0

        update |> Seq.sortWith comparer |> Seq.toArray
    
    updates
    |> Seq.filter (fun u -> not (correctOrder(u, rules)))
    |> Seq.map fixOrder
    |> Seq.sumBy (fun update ->
        update[update.Length / 2])
    
let run () =
    printfn $"Day 05, Part one: %d{partOne (input())}"
    printfn $"Day 05, Part two: %d{partTwo (input())}"
