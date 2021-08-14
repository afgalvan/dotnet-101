module Lists =
    let list = [1 .. 5]

    // Using pipes
    printfn "\nMixed pipes: "
    List.map (printfn "%A") <| (list |> List.sortDescending)

    printfn "\nOne direction pipe:"
    list
        |> List.sortDescending
        |> List.map (printfn "%A")
