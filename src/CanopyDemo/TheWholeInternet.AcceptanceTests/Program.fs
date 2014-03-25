module Program

open canopy
open runner
open System

let runTests browserStrategy =
    browserStrategy()
    ensure_wikipedia_is_awesome.all()
    ensure_amazon_carries_fp_books.all()
    run()

let runLocal () =
    //start an instance of the firefox browser
    runTests (fun () -> start firefox)

//run all tests
runLocal()

System.Console.WriteLine("press [enter] to exit")
System.Console.ReadLine() |> ignore

quit()
    