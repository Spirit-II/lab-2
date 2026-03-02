// For more information see https://aka.ms/fsharp-console-apps
open System

// список сумм цифр натуральных чисел
let T1 x = 
    let rec loop x num =
        if x = 0 then num
        else
            let d = x % 10
            let num = num + d
            loop (x / 10) num
    loop x 0

// проверка начинается ли число с заданной цифры
let sr d n =
    let sd = (string n).[0] |> string |> int
    sd = d

// сумма элементов, начинающихся на заданную цифру
let sumd d n =
    List.fold (fun acc x ->
        if sr d x then acc + x
        else acc) 0 n


[<EntryPoint>]
let main _ =
    printfn "Задание 1.  List.map
-> Получить список из сумм цифр натуральных чисел, содержащихся в исходном
списке: "
    printfn "Количество чисел: "
    let n = int(Console.ReadLine())
    let rec inputList n acc =
        if n <= 0 then acc
        else
            let num = int (Console.ReadLine())
            inputList (n - 1) (num :: acc)
    let numbers = List.rev (inputList n [])

    let result = List.map T1 numbers
    printfn "%A" result


    printfn "Задание 2.  List.fold
-> Найти сумму тех элементов списка, которые начинаются на заданную цифру.: "
    printfn "Заданое число для отбора чисел: "
    let d = int(Console.ReadLine())
    let result = sumd d numbers
    printfn "Сумма чисел, начинающихся на %d: %d" d result
    0