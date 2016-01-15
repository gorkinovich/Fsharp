open System

let read_string (msg : string) =
    Console.Write msg
    Console.ReadLine ()

let read_integer (msg : string) =
    Console.Write msg
    let line = Console.ReadLine ()
    let canparse, keyin = Int32.TryParse line
    if canparse then keyin else Int32.MinValue

let get_validated_integer msg minValue errMsg =
    let mutable value = Int32.MinValue
    while value < minValue do
        value <- read_integer msg
        if value < minValue then
            printfn errMsg
    value

let get_number_of_people () =
    get_validated_integer "Number of people: " 1
        "INPUT ERROR: Please enter an integer greater than zero."

let get_age_of_person () =
    get_validated_integer "Age: " 0
        "INPUT ERROR: Please enter an integer greater or equal than zero."

let evaluate_person (name : string) (age : int) =
    if age >= 20 then
        printfn "%s is no longer a teenager." name
    elif age >= 13 then
        printfn "%s is a teenager." name
    else
        printfn "%s is a child." name

let get_and_evaluate_person () =
    let name = read_string "Name: "
    let age = get_age_of_person ()
    evaluate_person name age

let pause () =
    Console.Write "Press any key to continue..."
    Console.ReadKey () |> ignore

[<EntryPoint>]
let main argv =
    let numberOfPeople = get_number_of_people ()
    for i = 1 to numberOfPeople do
        printfn "\n[Person number %d]" i
        get_and_evaluate_person ()
    Console.WriteLine ()
#if DEBUG
    pause ()
#endif
    0
