module Client

open System
open System.IO
open System.Net.Http
open System.Text.RegularExpressions

let cookie = 
    let path = "cookie"
    match File.Exists(path) with
        | true -> File.ReadAllText(path)
        | _ -> 
            Console.WriteLine($"Missing session cookie file in '{path}'")
            ""

let private getInputFromAOC year day = async {
    let url = $"https://adventofcode.com/{year}/day/{day}/input"
    Console.WriteLine("Downloading input from aoc...")

    use client = new HttpClient()
    client.DefaultRequestHeaders.Add("Cookie", $"session={cookie}")
    let! response = client.GetStringAsync(url) |> Async.AwaitTask
    return response
}

let private cache year day path =
    let input = getInputFromAOC year day |> Async.RunSynchronously
    File.WriteAllText(path, input.TrimEnd())

let getInput year day =
    let path = $"input-{year}-{day:D2}.txt"

    match File.Exists(path) with
        | true -> Console.WriteLine("Reading input from cache...")
        | _ -> cache year day path
    File.ReadAllLines(path)