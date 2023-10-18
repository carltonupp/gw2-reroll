namespace GW2Reroll.Api

open FSharp.Data
open System.Net.Http

module API =
    let url =  "https://api.guildwars2.com/v2/characters?ids=all"
    let token = "<gw2 api key>"

    let httpClient = new HttpClient();
    httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}")

    type ApiResponse = JsonProvider<"./Schemas/Character.json">

    let getCharacterData () = 
        async {            
            let! response = httpClient.GetAsync(url) |> Async.AwaitTask
            let! body = response.Content.ReadAsStringAsync() |> Async.AwaitTask
            return ApiResponse.Load body
        } |> Async.RunSynchronously

    

    