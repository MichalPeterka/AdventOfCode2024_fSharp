#load "utils.fsx"
open System
open System.IO

let input =
    __SOURCE_FILE__[3..4]+ ".input"
    |> File.ReadAllLines
    
let result =
    input
    |> Array.map (fun row -> row.Split "   " |> Array.map int)
    |> Array.transpose
    |> Array.map Array.sort
    |> function columns -> Array.map2 (fun x y -> x - y |> abs) columns[0] columns[1]
    |> Array.sum