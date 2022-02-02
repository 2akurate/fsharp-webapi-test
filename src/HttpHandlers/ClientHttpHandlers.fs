namespace test

open Microsoft.AspNetCore.Http
open Giraffe

module ClientHttpHandlers = 
    let getClients =
        fun (next : HttpFunc) (ctx : HttpContext) -> 
            task {
                return! json ["one", "two"] next ctx
            }

    let createClient = 
        fun (next : HttpFunc) (ctx : HttpContext) -> 
            task {
                //let! c = ctx.BindJsonAsync<Client>()
                return!  json ["one", "two"] next ctx
            } 