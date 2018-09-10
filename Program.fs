// Learn more about F# at http://fsharp.org

open System
open MF.ConsoleStyle
open System.Drawing
open System.Threading

[<EntryPoint>]
let main argv =
    Console.mainTitle "Console style demo"

    Console.subTitle "Sub Title"
    Console.message "a simple message"
    Console.newLine()

    Console.subTitle "Messages with indention"
    Console.messages Console.indentation ["message 1"; "message 2"]
    Console.newLine()

    Console.subTitle "List of items"
    Console.list ["item 1"; "item 2"]
    Console.newLine()

    Console.options "Options:" [
        ("help", "Shows help")
        ("list", "Lists")
    ]

    Console.section "Tables section"

    Console.table ["ID"; "Title"; "Description"] [
        ["1"; "Foo"; "Foo is just a foo"]
        ["2"; "FooBar"; "FooBar is just the foo bar"]
        ["3"; "BarBarBar"; "Bar is bar"]
    ]

    Console.table [] [
        ["This"; "Is"; "A headerless table"]
        ["2"; "FooBar"; "FooBar is just the foo bar"]
        ["3"; "BarBarBar"; "Bar is bar"]
    ]

    Console.section "Progress bar"
    let progress = Console.progressStart "Starting..." 5
    seq { for i in 1..5 do yield i}
    |> Seq.iter (fun i ->
        Thread.Sleep (1 * 1000)
        progress.Tick (sprintf "item %i" i)
    )
    Console.progressFinish progress

    Console.error "Some error :("

    Console.success "And it is done!"

    Console.title "A simple command app"
    Console.commandList [
        ("help", "Shows help")
        ("verbose", "Enables verbosity")
    ] [
        ("list", "Lists all commands")
        ("exit", "Quits the app")
    ]

    0 // return an integer exit code
