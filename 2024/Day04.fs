module Year2024.Day04

let input () = Client.getInput 2024 4

let partOne (data: string[]) =
    let WIDTH = data[0].Length
    let HEIGHT = data.Length
    let M = 'M'
    let A = 'A'
    let S = 'S'
    
    let forward (y, x) =    
        if (x+3) >= WIDTH then false
        else
            M = data[y][x+1] && A = data[y][x+2] && S = data[y][x+3]
         
    let backward (y, x) =    
        if (x-3) < 0 then false
        else
            M = data[y][x-1] && A = data[y][x-2] && S = data[y][x-3]

    let up (y, x) =    
        if (y-3) < 0 then false
        else
            M = data[y-1][x] && A = data[y-2][x] && S = data[y-3][x]
            
    let down (y, x) =    
        if (y+3) >= HEIGHT then false
        else
            M = data[y+1][x] && A = data[y+2][x] && S = data[y+3][x]
            
    let diagUL (y, x) =    
        if (y-3) < 0 || (x-3) < 0 then false
        else
            M = data[y-1][x-1] && A = data[y-2][x-2] && S = data[y-3][x-3]
            
    let diagUR (y, x) =    
        if (y-3) < 0 || (x+3) >= WIDTH then false
        else
            M = data[y-1][x+1] && A = data[y-2][x+2] && S = data[y-3][x+3]
            
    let diagDL (y, x) =    
        if (y+3) >= HEIGHT || (x-3) < 0 then false
        else
            M = data[y+1][x-1] && A = data[y+2][x-2] && S = data[y+3][x-3]

    let diagDR (y, x) =    
        if (y+3) >= HEIGHT || (x+3) >= WIDTH then false
        else
            M = data[y+1][x+1] && A = data[y+2][x+2] && S = data[y+3][x+3]
            
    let isXmas (y, line: string) =
        let countMatches (y, x) =
            let directions = [ forward; backward; up; down; diagUL; diagUR; diagDL; diagDR ]
            directions
            |> List.sumBy (fun direction -> if direction (y, x) then 1 else 0)
        
        line
        |> Seq.mapi (fun x c -> if c = 'X' then countMatches (y, x) else 0)
        |> Seq.sum
        
    data
        |> Seq.mapi (fun y line -> (y, line))
        |> Seq.sumBy isXmas

let partTwo (data: string[]) =
    let WIDTH = data[0].Length
    let HEIGHT = data.Length
    
    let diagUL (y, x, c) =    
        if (y-1) < 0 || (x-1) < 0 then false
        else
            c = data[y-1][x-1]
            
    let diagUR (y, x, c) =    
        if (y-1) < 0 || (x+1) > WIDTH then false
        else
            c = data[y-1][x+1]
            
    let diagDL (y, x, c) =    
        if (y+1) >= HEIGHT || (x-1) < 0 then false
        else
            c = data[y+1][x-1]

    let diagDR (y, x, c) =    
        if (y+1) >= HEIGHT || (x+1) >= WIDTH then false
        else
            c = data[y+1][x+1]
    
    let isXmas (y, line:string) =
        line
        |> Seq.mapi (fun x c ->
            if not (c = 'A') then
                0
            else
                if (diagUL(y,x, 'M') && diagDR(y,x, 'S') && diagUR(y,x, 'M') && diagDL(y,x, 'S')) ||
                   (diagUL(y,x, 'S') && diagDR(y,x, 'M') && diagUR(y,x, 'S') && diagDL(y,x, 'M')) ||
                   (diagUL(y,x, 'M') && diagDR(y,x, 'S') && diagUR(y,x, 'S') && diagDL(y,x, 'M')) ||
                   (diagUL(y,x, 'S') && diagDR(y,x, 'M') && diagUR(y,x, 'M') && diagDL(y,x, 'S')) then
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
