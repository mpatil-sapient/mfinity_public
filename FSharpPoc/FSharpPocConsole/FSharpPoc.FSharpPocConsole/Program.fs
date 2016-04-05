// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.



let square x:int64 = int64 x*x

let squarexplussquarexminusone x:int64 =
    if (x = 1) then square(int64 x) 
    else square(int64 x) + square(int64 (x-1))

[<EntryPoint>]
let main argv = 
    let stopWatch = System.Diagnostics.Stopwatch.StartNew()
    for counter = 1 to 1000 do
        //printfn "%A * %A = %A" counter (counter-1) (squarexplussquarexminusone counter)
        squarexplussquarexminusone counter
    stopWatch.Stop()

    printfn "time taken %f" stopWatch.Elapsed.TotalMilliseconds
    let x = System.Console.ReadLine(); 
    0 // return an integer exit code
