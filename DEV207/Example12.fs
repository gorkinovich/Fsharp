open System
open System.IO

type Entity = {
    TargetX : float
    TargetY : float
    Speed : float
    ExpectedDistance : float
    Name : string
}

let GRAVITY = 9.81
let AngleOfReach (distance, speed) =
    0.5 * Math.Asin(GRAVITY * distance / Math.Pow(speed, 2.0))
let DistanceTravelled (speed, angle) =
    Math.Pow(speed, 2.0) * Math.Sin(2.0 * angle) / GRAVITY
let CalculateAngle (x, y) = Math.Atan(y / x)

let DistanceReached (x, y, speed, distance) =
    let angle = CalculateAngle(x, y)
    let realDistance = DistanceTravelled(speed, angle)
    Math.Abs(distance - realDistance) < 0.0001

let (|ShotHit|ShotMiss|) input =
    match input with
    | { TargetX = x; TargetY = y; Speed = s; ExpectedDistance = d; Name = _}
        when DistanceReached(x, y, s, d) -> ShotHit
    | _ -> ShotMiss

let GetInputPath (args:string[]) =
    match args.Length with
    | 0 -> Console.Write("Enter the input file path: ")
           Console.ReadLine()
    | _ -> args.[0]

let Pause (exitCode:int) =
    Console.Write("Press any key to continue...")
    Console.ReadKey() |> ignore
    Console.WriteLine()
    exitCode

let ShowError (msg:string) =
    Console.WriteLine(msg)
    Pause(-1)

[<EntryPoint>]
let Main args =
    try
        let path = GetInputPath(args)
        let entities = seq {
            for item in File.ReadLines(path) do
                let values = item.Split(',')
                yield {
                    TargetX = float values.[0]
                    TargetY = float values.[1]
                    Speed = float values.[2]
                    ExpectedDistance = float values.[3]
                    Name = values.[4]
                }
        }
        for item in entities do
            match item with
            | ShotHit ->
                Console.WriteLine(item.Name + " hits the target.")
            | _ ->
                let angle = AngleOfReach(item.ExpectedDistance, item.Speed)
                Console.WriteLine(item.Name + " missed the target.")
                if Double.IsNaN(angle) then
                    Console.WriteLine("=> The speed and the angle must be changed.")
                else
                    let angleString = angle.ToString()
                    Console.WriteLine("=> The angle must be changed to: " + angleString)
        Pause(0)
    with
    | :? System.IO.FileNotFoundException ->
        ShowError("File Not Found. Press a key to exit.")
    | _ ->
        ShowError("Something else happened.")
