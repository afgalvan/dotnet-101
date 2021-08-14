module PatternMatching =
    let matchNumber (x: int) =
        match x % 2 with
        | 0 -> printfn "%A is even" x
        | _ -> printfn "%A is odd" x

    matchNumber(5)
