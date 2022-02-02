
namespace test

open Microsoft.AspNetCore.Http
open Giraffe
open ClientHttpHandlers

module MyRoutes =


    let apiClientRoutes : HttpHandler = 
        subRoute "/client"
            (choose [
                GET >=> route "" >=> getClients
                PUT >=> route "" >=> createClient
            ])
