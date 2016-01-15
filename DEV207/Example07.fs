open System

let read_int_line () =
    Console.Write "Enter a integer: "
    let line = Console.ReadLine ()
    let canparse, keyin = Int32.TryParse line
    if canparse then keyin else 0

let check_value (argv : string []) : int =
    if argv.Length > 0 then      
        let couldparse, consolein = Int32.TryParse (argv.[0])
        if couldparse then
            consolein
        else
            read_int_line ()
    else
        read_int_line ()

let fibonacci1 n =
    let mutable first = 0
    let mutable second = 1
    let mutable temp = 0
    for index = 1 to n do
        temp <- first + second
        first <- second
        second <- temp
    first

let rec rfibonacci n fst snd =
    if n > 0 then
        rfibonacci (n - 1) (snd) (fst + snd)
    else
        fst

let fibonacci2 n = rfibonacci n 0 1

let rec fibonacci3 n =
    if n <= 0 then
        0
    else
        (fibonacci3 (n - 1)) + (fibonacci3 (n - 2))

[<EntryPoint>]
let main argv =
    let input = check_value argv
    printfn "[V1] Fib(%A) = %A" input (fibonacci1 input)
    printfn "[V2] Fib(%A) = %A" input (fibonacci2 input)
    printfn "[V3] Fib(%A) = %A" input (fibonacci3 input)
    0
