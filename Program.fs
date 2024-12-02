open System.Reflection

let run name =
    let typ = 
        Assembly.GetExecutingAssembly().GetTypes()
        |> Seq.find (fun t -> t.FullName = name)
        
    typ.GetMethod("run").Invoke(null, [||]) |> ignore

[<EntryPoint>]
let main argv =
    if argv.Length = 0 then
        printfn "Usage: dotnet run Year<number>.Day<number>"
    else
        run argv[0]
    0
  