namespace test

open System
open System.IO
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.DependencyInjection
open Microsoft.AspNetCore.Http
open Giraffe
open FSharp.Control.Tasks
open MyRoutes

type PingModel = {
    Response: string
}

module Host = 
    let webApp = 
        choose [
            GET >=> route "/" >=> json { Response = "index" }
            subRoute "/api"
                (choose [
                    GET >=> route "" >=> json { Response = "api"}
                    apiClientRoutes
                ])
        ]

    let configureApp (app : IApplicationBuilder) = 
        app.UseGiraffe webApp

    let configureServices (services : IServiceCollection) =
        services.AddGiraffe() |> ignore

    [<EntryPoint>]
    let main(args) =
        Host.CreateDefaultBuilder()
            .ConfigureWebHostDefaults(fun webHost -> 
                webHost 
                    .Configure(configureApp)
                    .ConfigureServices(configureServices) 
                    |> ignore)
            .Build()
            .Run()
        0



      //   PUT http://localhost:5000/api/client