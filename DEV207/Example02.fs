open System

[<EntryPoint>]
let main argv =
    printfn "argv = %A" argv
    let val1 = 2 + 3
    printfn "val1 = %d" val1
    let mutable val2 = 10
    printfn "val2 = %d" val2
    val2 <- 11
    printfn "val2 = %d" val2
    0
