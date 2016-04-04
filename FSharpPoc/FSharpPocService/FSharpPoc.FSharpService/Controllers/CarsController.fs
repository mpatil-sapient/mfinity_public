namespace FSharpPoc.FSharpService.Controllers

open System.Net
open System.Net.Http
open System.Web.Http
open FSharpPoc.FSharpService.Models
open Cassandra
open System

/// Retrieves values.
[<RoutePrefix("api")>]
type CarsController() =
    inherit ApiController()

    let cluster = Cassandra.Cluster.Builder().AddContactPoint("debian").Build();
    let session = cluster.Connect("Test Cluster");
//
    let values = [| { Make = "Ford"; Model = "Mustang" }; { Make = "Nissan"; Model = "Titan" } ; { Make = "Honda"; Model = "Accord" } |]

    /// Gets all values.
    [<Route("cars")>]
    member x.Get() = values

    /// Gets a single value at the specified index.
    [<Route("cars/{id}")>]
    member x.Get(request: HttpRequestMessage, id: int) =
        if id >= 0 && values.Length > id then
            request.CreateResponse(values.[id])
        else 
            request.CreateResponse(HttpStatusCode.NotFound)


    /// Gets a single value at the specified index.
//    [<Route("inventory")>]
//    member x.Put() =
//        session.Execute("select * from products") 

//        let printOut(row: Row) = 
//            Console.WriteLine(row.GetValue<string>("title"))
//            ()
//
//        results |> Seq.iter printOut
//
//
//        let boundQuery = session.Prepare("select * from products where product_id=?")
//        let boundStatement = boundQuery.Bind("1")
//        session.Execute(boundStatement) |> Seq.iter printOut

