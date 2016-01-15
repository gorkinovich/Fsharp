open System

let rect_area w h = w * h
let cube_area w h b = (rect_area w h) * b

[<EntryPoint>]
let main argv =
    Console.Write("Width:  ")
    let w = Console.ReadLine() |> int
    Console.Write("Height: ")
    let h = Console.ReadLine() |> int
    Console.Write("Base:   ")
    let b = Console.ReadLine() |> int
    let a = cube_area w h b
    printfn "Cube Area = %A" a
    0
