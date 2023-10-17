open System.Text.Json
open System.Linq

let races = ["Human"; "Charr"; "Norn"; "Asura"; "Sylvari";]

let professions = ["Warrior"; "Guardian"; "Revenant"; "Ranger"; "Thief"; "Engineer"; "Elementalist"; "Necromancer"; "Mesmer";]

let genders = ["Male"; "Female";]

type Character = {
    name: string option
    race: string
    profession: string
    gender: string
}

let url =  "https://api.guildwars2.com/v2/characters?ids=all"
let token = "<gw2 api key>"

let httpClient = new System.Net.Http.HttpClient();
httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}")

let getCharacterData (client: System.Net.Http.HttpClient) = 
    async {
        let! response = client.GetAsync(url) |> Async.AwaitTask
        let! body = response.Content.ReadAsStringAsync() |> Async.AwaitTask
        return body
    }

let createCharacter race profession gender =
    { race = race; profession = profession; gender = gender; name = None }

let buildAvailableOptions()  =
    [ for profession in professions do 
        for race in races do
            for gender in genders do
                createCharacter race profession gender ]


let characterData = (getCharacterData(httpClient) |> Async.RunSynchronously)
                    |> JsonSerializer.Deserialize<Character list>

let usedProfessions = characterData |> List.map (fun character -> character.profession) |> List.distinct

let usedRaces = characterData |> List.map (fun character -> character.race) |> List.distinct

let getMissingProfessions() =
    professions |> List.filter (fun p -> usedProfessions.Contains(p) <> true)
let getMissingRaces() =
    races |> List.filter (fun r -> usedRaces.Contains(r) <> true)
let missingProfs = getMissingProfessions()
let missingRaces = getMissingRaces()

let buildRecommendations profs races =
    [for prof in profs do
        for race in races do
            createCharacter race prof "male"]

let rnd = new System.Random();

let recommendations = buildRecommendations missingProfs missingRaces

let index = rnd.Next(0, recommendations.Length - 1)

let suggestion = recommendations[index]