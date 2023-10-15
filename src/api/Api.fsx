let races = ["Human"; "Charr"; "Norn"; "Asura"; "Sylvari";]

let professions = ["Warrior"; "Guardian"; "Revenant"; "Ranger"; "Thief"; "Engineer"; "Elementalist"; "Necromancer"; "Mesmer";]

let genders = ["Male"; "Female";]

type Character = {
    Race: string
    Profession: string
    Gender: string
}

let createCharacter race profession gender =
    { Race = race; Profession = profession; Gender = gender }

let buildAvailableOptions()  =
    [ for profession in professions do 
        for race in races do
            for gender in genders do
                createCharacter race profession gender ]


let getReroll() =
    let options = buildAvailableOptions()
    let rnd = new System.Random()
    let idx = rnd.Next(options.Length - 1)
    options[idx]

let char = getReroll()