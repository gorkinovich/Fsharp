open System

let golden_ratio = (1.0 + (Math.Sqrt 5.0)) / 2.0

let read_generic_number (msg : string) fconv ftest defval =
    let mutable value = defval
    while ftest value do
        try
            Console.Write msg
            value <- Console.ReadLine() |> fconv
        with
            | _ -> printfn "INPUT ERROR: Please try again."
                   value <- defval
    value

let read_float msg =
    let ftest = fun x -> Double.IsNaN x
    read_generic_number msg float ftest nan

let read_integer msg =
    let ftest = fun x -> x = Int32.MinValue
    read_generic_number msg int ftest Int32.MinValue

let get_victim (i : int) =
    let number = read_float ("#" + i.ToString() + "? ")
    (number, number * golden_ratio)

[<EntryPoint>]
let main argv =
    let size = read_integer "Enter the number of inputs: "
    let list = seq { for i = 1 to size do yield (get_victim i) }
    printfn "%A" list
#if DEBUG
    Console.Write "Press any key to continue..."
    Console.ReadKey() |> ignore
#endif
    0
