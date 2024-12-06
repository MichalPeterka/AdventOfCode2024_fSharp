#load "utils.fsx"
open Utils
open System
open System.IO

let input =
    __SOURCE_FILE__[..1] + ".input"
    |> File.ReadAllLines
    |> Array.map (String.split " " >> Array.map  int >> List.ofArray)
    |> List.ofArray
    
let examples =
    """7 6 4 2 1
1 2 7 8 9
9 7 6 2 1
1 3 2 4 5
8 6 4 4 1
1 3 6 7 9"""
    |> String.split "\n"
    |> List.ofArray
    |> List.map (String.split " " >> Array.map int >> List.ofArray)

type Relation = Decreasing | Increasing | Undetermined
       
let evaluateRecord (ls: int list) =
    let rec evaluate nums previous relation =
        match nums, previous, relation with
        | [  ], _, _ -> true
        | f::s::t, None, _ when s > f && s - f < 4 -> evaluate t (Some s) Increasing
        | f::s::t, None, _ when s < f && f - s < 4 -> evaluate t (Some s) Decreasing 
        | h::t, Some p, Increasing when h > p && h - p < 4 -> evaluate t (Some h) Increasing
        | _, _, Increasing -> false
        | h::t, Some p, Decreasing when h < p && p - h < 4 -> evaluate t (Some h) Decreasing
        | _, _, _ -> false
    
    evaluate ls None Undetermined
    
List.sumBy (fun x -> if evaluateRecord x then 1 else 0) input