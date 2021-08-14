//#region Integral Types
// sbyte: 1 byte | -128 to 127
let sbyte1 = -100y
let sbyte2 = 0b00000101y
// byte: 1 byte | 0 to 255
let byte1 = 200uy
let byte2 = 0b00000101uy
let byte3 = 'a'B
// int16: 2 bytes | -32,768 to 32,767
let int16 = -200s
// uint16: 2 bytes | 0 to 65,535
let uint16 = 200us
// int/int32: 4 bytes | -2,147,483,648 to 2,147,483,647
let int = -200
// uint32: 4bytes | 0 to 4,294,967,295
let uint32 = 200u
// int64: 8 bytes | 9,223,372,036,854,775,808 to 9,223,372,036,854,775,807
let long = -200L
// uint64: 8 bytes | 0 to 18,446,744,073,709,551,615
let ulong = 200L
// bigint: >= 4 bytes | any integer
let bigint = 14999999999999999999999999999999I
//#endregion

//#region Floating Point Types
// float32: 4 bytes | ±1.5e-45 to ±3.4e38
let float32 = 200.0F
// float: 8 bytes | ±5.0e-324 to ±1.7e308
let float = 200.0
// decimal: 16 bytes
let decimal = 200.0M
//#endregion

// Type Inference
let averageImplicit (a: int) (b: int) = (a + b) / 2
let average a b = (a + b) / 2

