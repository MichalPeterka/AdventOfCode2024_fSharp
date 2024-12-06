#load "utils.fsx"
open Utils
open System
open System.IO

let input =
    __SOURCE_FILE__[..1]+ ".input"
    |> File.ReadAllLines
    
let result =
    input
    |> Array.map (String.split "   " >> Array.map int)
    |> Array.transpose
    |> Array.map Array.sort
    |> function columns -> Array.map2 (fun x y -> x - y |> abs) columns[0] columns[1]
    |> Array.sum