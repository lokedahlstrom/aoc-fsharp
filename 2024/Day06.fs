module Year2024.Day06

open System.Collections.Generic
open Helpers

let input () = Client.getInput 2024 6

let Guard = '^'
let Obstacle = '#'

let ternary (predicate: bool, whenTrue: Option<'T>, whenFalse: Option<'T>) =
    if predicate then whenTrue else whenFalse

let ifthenelse (predicate: bool, whenTrue, whenFalse) =
    if predicate then whenTrue else whenFalse

let parseGrid (data: string[]) =
    data
    |> Seq.map (fun line -> line.ToCharArray())
    |> Seq.toArray
    
let findStartPos (map: char[][], target: char) =
    map
    |> Array.mapi (fun y row ->
        row
        |> Array.mapi (fun x c -> ternary(c = target, Some(y, x), None))
        |> Array.choose id
    )
    |> Array.collect id 
    |> Array.tryHead

let rotate90CW (y, x) = (x, -y)

let createKey (y, x, (a, b)) =
    $"{y},{x},{a},{b}"

let partOne data =
    let map = parseGrid data
    let visited = Dictionary()
      
    let move (y: int, x:int, d) =
        let mutable newD = d
        let mutable ny = y
        let mutable nx = x
        
        while ny >= 0 && nx >= 0 && ny < map.Length && nx < map[0].Length do
            let key = createKey(ny, nx, d)
            
            visited.TryAdd (key, true) |> ignore 
            
            let testY = ny+fst newD
            let testX = nx+snd newD
            if testY >= 0 && testX >= 0 && testY < map.Length && testX < map[0].Length && map[ny+fst newD][nx+snd newD] = Obstacle then
                newD <- rotate90CW(newD)
            
            ny <- ny + fst newD
            nx <- nx + snd newD
        visited, visited.Count

    match findStartPos (map, Guard) with
    | Some(y, x) ->
        let res = move (y, x, (-1, 0))
        res
    | None -> Dictionary(), 0
        
let partTwo (data, visited: Dictionary<string, bool>) =
    let map = parseGrid data
    
    let W = map[0].Length
    let H = map.Length
    
    let move (y: int, x:int, d) =
        let mutable newD = d
        let mutable ny = y
        let mutable nx = x
        let visited = Dictionary()
        let mutable cycle = false
        
        while not cycle && ny >= 0 && nx >= 0 && ny < map.Length && nx < map[0].Length do
            let key = createKey(ny,nx,newD)
            if visited.ContainsKey key then
                cycle <- true
            visited.TryAdd (key, true) |> ignore 
            
            let testY = ny+fst newD
            let testX = nx+snd newD
            
            if testY >= 0 && testX >= 0 && testY < map.Length && testX < map[0].Length && map[ny+fst newD][nx+snd newD] = Obstacle then
                newD <- rotate90CW(newD)

            ny <- ny + fst newD
            nx <- nx + snd newD
                
        cycle

    match findStartPos (map, Guard) with
    | Some(y, x) ->
        let key = createKey(y,x,(-1,0))
        visited.Remove(key) |> ignore
        let mutable cycles = 0
        visited.Keys
        |> Seq.iter (fun k ->
            let pos = k.Split(",") |> Seq.take(2) |> Seq.map (fun s -> int s) |> Seq.toArray
            if map[pos[0]][pos[1]] = '.' then 
                map[pos[0]][pos[1]] <- Obstacle
                let res = move (y, x, (-1, 0))
                if res then cycles <- cycles + 1
                map[pos[0]][pos[1]] <- '.'
            )
        cycles
    | None -> 0
    
let run () =
    let visited, count = partOne (input())
    printfn $"Day 06, Part one: %d{count}"
    printfn $"Day 06, Part two: %d{partTwo (input(), visited)}"
