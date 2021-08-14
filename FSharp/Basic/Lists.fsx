let list = [1 .. 5]

let rec displayList = function
  | []       -> ()
  | head :: tail ->
      printfn "%A" head;
      displayList tail

displayList list

// Using pipes
printfn "\nWith pipes: "
List.map (printfn "%A") <| (list |> List.sortDescending) // Not necesary at all
