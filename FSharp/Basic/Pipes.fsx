module PipelinesAndComposition =

    let square x = x * x

    let addOne x = x + 1

    let isOdd x = x % 2 <> 0

    let numbers = [ 1; 2; 3; 4; 5 ]

    let squareOddValuesAndAddOne (values: int list) : int list =
        let odds = List.filter isOdd values
        let squares = List.map square odds
        let result = List.map addOne squares
        result

    squareOddValuesAndAddOne numbers
    |> printfn "processing %A through 'squareOddValuesAndAddOne' produces: %A" numbers

    let squareOddValuesAndAddOneNested (values: int list): int list =
        List.map addOne (List.map square (List.filter isOdd values))

    squareOddValuesAndAddOneNested numbers
    |> printfn "processing %A through 'squareOddValuesAndAddOneNested' produces: %A" numbers

    let squareOddValuesAndAddOnePipeline (values: int list): int list  =
        values
        |> List.filter isOdd
        |> List.map square
        |> List.map addOne

    squareOddValuesAndAddOnePipeline numbers
    |> printfn "processing %A through 'squareOddValuesAndAddOnePipeline' produces: %A" numbers

    let squareOddValuesAndAddOneShorterPipeline (values: int list): int list  =
        values
        |> List.filter isOdd
        |> List.map (fun x -> x |> square |> addOne)

    squareOddValuesAndAddOneShorterPipeline numbers
    |> printfn "processing %A through 'squareOddValuesAndAddOneShorterPipeline' produces: %A" numbers

    let squareOddValuesAndAddOneComposition : int list -> int list  =
        List.filter isOdd >> List.map (square >> addOne)

    squareOddValuesAndAddOneComposition numbers
    |> printfn "processing %A through 'squareOddValuesAndAddOneComposition' produces: %A" numbers
