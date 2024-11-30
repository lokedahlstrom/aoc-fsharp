open System.Reflection

let run name = 
    let typ = 
        Assembly.GetExecutingAssembly().GetTypes()
        |> Seq.find (fun t -> t.Name = name)
    typ.GetMethod("run").Invoke(null, [||]) |> ignore

[<EntryPoint>]
let main argv =
    run argv[0]
    0
  