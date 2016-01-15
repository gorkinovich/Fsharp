open System

[<EntryPoint>]
let main argv =
    Console.Write("Please enter how far you traveled: ")
    let distance = (float (Console.ReadLine()))
    Console.Write("Please enter how much fuel you used: ")
    let fuel = (float (Console.ReadLine()))
    let consumption = distance / fuel
    Console.WriteLine("Your car does a distance of " + (string consumption) + "  per single unit of fuel ")
    Console.ReadKey()
    0
