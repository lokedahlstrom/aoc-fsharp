module Year2023.Day02

let input = Client.getInput 2023 2

// Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
let print u = printfn "%s" u

let parseInput (line: string) =
    line.Split(':')
    
let solve = 
    input
    |> Seq.map parseInput
    |> ignore

let run () = solve
