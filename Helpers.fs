module Helpers

let stringToInt s = int s
    
let stringToInts (line: string) =
    line.Split(" ")
    |> Array.map stringToInt


