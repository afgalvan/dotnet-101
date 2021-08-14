printfn "Print elements in list"
let rec displayList = function
  | []       -> ()
  | head :: tail ->
      printfn "%A" head;
      displayList tail

let list = [1 .. 5]
displayList list

printfn "\nFibonacci"
let rec fibo = function
    | 0 | 1 -> 1
    | n -> fibo (n - 1) + fibo (n - 2)

printfn "fibo(8) = %i" (fibo 8)

