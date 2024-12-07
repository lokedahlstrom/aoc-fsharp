module Year2024.Day07

let input () = Client.getInput 2024 7

let parseLine (line: string) =
    line.Split([| ':'; ' ' |])
    |> Array.filter (fun t -> t.Length > 0)
    |> Array.map bigint.Parse
    
let parseData (data: string[]) = data |> Array.map parseLine

let mul (l, r) = l * r
let add (l, r) = l + r
let cct (l, r) = bigint.Parse(string l + string r)

let rec solvable (ops, expected: bigint, numbers: bigint[], total: bigint, i) =
    if i >= numbers.Length then
        expected = total
    else
        ops |> Array.exists (fun op -> solvable (ops, expected, numbers, op(total, numbers[i]), i+1))

let solve operations data =
    parseData data
    |> Array.filter (fun line ->
        let expected = line[0]
        let numbers = line[1..]
        let total = numbers[0]
        
        solvable(operations, expected, numbers, total, 1))
    |> Array.sumBy (fun eq -> eq[0])
    
let partOne data =
    let ops = [| mul; add |]
    solve ops data

let partTwo data =
    let ops = [| mul; add; cct |]
    solve ops data
    
let run () =
    printfn $"Day 07, Part one: %A{partOne (input())}"
    printfn $"Day 07, Part two: %A{partTwo (input())}"
