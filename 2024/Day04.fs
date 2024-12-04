module Year2024.Day04

let input () = Client.getInput 2024 4

let partOne (data: string[]) =
    let WIDTH = data[0].Length
    let HEIGHT = data.Length
    
    let forward (x, y) =    
        if (x+3) >= WIDTH then false
        else
            let a = data[y][x+1]
            let b = data[y][x+2]
            let c = data[y][x+3]
            a = 'M' && b = 'A' && c = 'S'
         
    let backward (x, y) =    
        if (x-3) < 0 then false
        else
            let a = data[y][x-1]
            let b = data[y][x-2]
            let c = data[y][x-3]
            a = 'M' && b = 'A' && c = 'S'

    let up (x, y) =    
        if (y-3) < 0 then false
        else
            let a = data[y-1][x]
            let b = data[y-2][x]
            let c = data[y-3][x]
            a = 'M' && b = 'A' && c = 'S'
            
    let down (x, y) =    
        if (y+3) >= HEIGHT then false
        else
            let a = data[y+1][x]
            let b = data[y+2][x]
            let c = data[y+3][x]
            a = 'M' && b = 'A' && c = 'S'
            
    let diagUL (x, y) =    
        if (y-3) < 0 || (x-3) < 0 then false
        else
            let a = data[y-1][x-1]
            let b = data[y-2][x-2]
            let c = data[y-3][x-3]
            a = 'M' && b = 'A' && c = 'S'
            
    let diagUR (x, y) =    
        if (y-3) < 0 || (x+3) >= WIDTH then false
        else
            let a = data[y-1][x+1]
            let b = data[y-2][x+2]
            let c = data[y-3][x+3]
            a = 'M' && b = 'A' && c = 'S'
            
    let diagDL (x, y) =    
        if (y+3) >= HEIGHT || (x-3) < 0 then false
        else
            let a = data[y+1][x-1]
            let b = data[y+2][x-2]
            let c = data[y+3][x-3]
            a = 'M' && b = 'A' && c = 'S'

    let diagDR (x, y) =    
        if (y+3) >= HEIGHT || (x+3) >= WIDTH then false
        else
            let a = data[y+1][x+1]
            let b = data[y+2][x+2]
            let c = data[y+3][x+3]
            a = 'M' && b = 'A' && c = 'S'
            
    let isXmas (y, line: string) =
        let countMatches (x, y) =
            let directions = [ forward; backward; up; down; diagUL; diagUR; diagDL; diagDR ]
            directions
            |> List.sumBy (fun direction -> if direction (x, y) then 1 else 0)
        
        line
        |> Seq.mapi (fun x c -> if c = 'X' then countMatches (x, y) else 0)
        |> Seq.sum
        
    data
        |> Seq.mapi (fun y line -> (y, line))
        |> Seq.sumBy isXmas

let partTwo (data: string[]) =
    let WIDTH = data[0].Length
    let HEIGHT = data.Length
    
    let diagUL (x, y, c) =    
        if (y-1) < 0 || (x-1) < 0 then false
        else
            c = data[y-1][x-1]
            
    let diagUR (x, y, c) =    
        if (y-1) < 0 || (x+1) > WIDTH then false
        else
            c = data[y-1][x+1]
            
    let diagDL (x, y, c) =    
        if (y+1) >= HEIGHT || (x-1) < 0 then false
        else
            c = data[y+1][x-1]

    let diagDR (x, y, c) =    
        if (y+1) >= HEIGHT || (x+1) >= WIDTH then false
        else
            c = data[y+1][x+1]
    
    let isXmas (y, line:string) =
        line
        |> Seq.mapi (fun x c ->
            if not (c = 'A') then
                0
            else
                if (diagUL(x,y, 'M') && diagDR(x,y, 'S') && diagUR(x,y, 'M') && diagDL(x,y, 'S')) ||
                   (diagUL(x,y, 'S') && diagDR(x,y, 'M') && diagUR(x,y, 'S') && diagDL(x,y, 'M')) ||
                   (diagUL(x,y, 'M') && diagDR(x,y, 'S') && diagUR(x,y, 'S') && diagDL(x,y, 'M')) ||
                   (diagUL(x,y, 'S') && diagDR(x,y, 'M') && diagUR(x,y, 'M') && diagDL(x,y, 'S')) then
                    1
                else
                    0
            )
        |> Seq.sum

    data
    |> Seq.mapi (fun y line -> (y, line))
    |> Seq.sumBy isXmas
    
let run () =
    printfn $"Day 04, Part one: %d{partOne (input())}"
    printfn $"Day 04, Part two: %d{partTwo (input())}"
