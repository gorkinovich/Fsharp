open System

let VolumeCylinder (r : float) h =
    Math.PI * r * r * h

let ReadFloat (msg : string) =
    Console.Write(msg)
    Console.ReadLine() |> float

[<EntryPoint>]
let main argv =
    let r = ReadFloat "Radius: "
    let h = ReadFloat "Height: "
    printfn "Volume = %f" (VolumeCylinder r h)
    0
