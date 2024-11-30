module Day01

open System
open System.Text.RegularExpressions

let dic = 
    dict [
        ("one", 1)
        ("two", 2)
        ("three", 3)
        ("four", 4)
        ("five", 5)
        ("six", 6)
        ("seven", 7)
        ("eight", 8)
        ("nine", 9)
    ]

let toInt (s: Match) =
    if (Char.IsDigit(s.Value[0])) then
        Int32.Parse(s.Value)
    else
        dic.[s.Value]

let extractDigits pattern line =
    let regexFirst = new Regex(pattern)
    let regexLast = new Regex(pattern, RegexOptions.RightToLeft)
    // regex can't solve "oneight" so we need to do it from each direction

    regexFirst.Match(line) :: regexLast.Match(line) :: []
    |> Seq.map toInt
    |> Seq.toArray

let getCalibrationValue pattern line =
    let digits = extractDigits pattern line
    digits.[0] * 10 + digits.[digits.Length-1]

let input = Client.getInput 2023 1

let solve getCalibrationValue = 
    input
    |> Seq.map getCalibrationValue
    |> Seq.sum

module Day1 =
    let run () = 
        printfn "Day 01, Part one: %d" (solve (getCalibrationValue(@"\d")))
        printfn "Day 01, Part two: %d" (solve (getCalibrationValue(@"\d|one|two|three|four|five|six|seven|eight|nine")))
