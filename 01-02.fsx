#load "utils.fsx"
open System
open System.IO

let input =
    __SOURCE_FILE__[..1]+ ".input"
    |> File.ReadAllLines


let column1, column2Counted =
    input
    |> Array.map (fun row -> row.Split "   " |> Array.map int)
    |> Array.transpose
    |> function x -> x[0], x[1] |> Array.countBy id |> Map.ofArray

let result =
    column1
    |> Array.sumBy (fun i -> column2Counted
                             |> Map.tryFind i
                             |> function
                                 | Some x -> x * i
                                 | None -> 0)