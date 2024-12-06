module Utils

module String =
    let inline split (delimiters: ^T) (str: string) =
        match box delimiters with
        | :? char as singleChar -> str.Split singleChar
        | :? array<char> as charArray -> str.Split charArray
        | :? string as singleString -> str.Split singleString 
        | _ -> invalidArg "delimiters" "Delimiters must be of type char, char[], string, or string[]."