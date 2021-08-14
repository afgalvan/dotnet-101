module Immutability =
    /// Binding a value to a name via 'let' makes it immutable.
    ///
    /// The second line of code compiles, but 'number' from that point onward will shadow the previous definition.
    /// There is no way to access the previous definition of 'number' due to shadowing.
    let number = 2
    // let number = 3

    /// A mutable binding.  This is required to be able to mutate the value of 'otherNumber'.
    let mutable otherNumber = 2

    printfn $"'otherNumber' is {otherNumber}"

    // When mutating a value, use '<-' to assign a new value.
    //
    // Note that '=' is not the same as this.  Outside binding values via 'let', '=' is used to test equality.
    otherNumber <- otherNumber + 1

    printfn $"'otherNumber' changed to be {otherNumber}"

