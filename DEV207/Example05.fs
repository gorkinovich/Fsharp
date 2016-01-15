open System

let rad2deg (r : float) = (r * 180.0) / Math.PI
let deg2rad (d : float) = (d * Math.PI) / 180.0

[<EntryPoint>]
let main argv =
    // Our hexagonal area function:
    let hexarea (t : float) =
        (3.0 * Math.Sqrt(3.0) / 2.0) * Math.Pow(t, 2.0)
    // Read the size of the hexagon:
    Console.Write("Size: ")
    let value = Console.ReadLine() |> float
    // Calculate the area of the hexagon:
    let calc = hexarea value
    printfn "Area = %f" calc
    0
