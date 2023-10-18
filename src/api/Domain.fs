namespace GW2Reroll.Api

module Domain =
    type Profession = 
        | Warrior
        | Guardian
        | Revenant
        | Ranger
        | Engineer
        | Thief
        | Elementalist
        | Necromancer
        | Mesmer
    
    type Race =
        | Human
        | Charr
        | Norn
        | Asura
        | Sylvari

    type Gender =
        | Male
        | Female
    
    type Character = Race * Profession * Gender
    
    let mapToProfession profession =
        match profession with
        | "Warrior" -> Some Warrior
        | "Guardian" -> Some Guardian
        | "Revenant" -> Some Revenant
        | "Ranger" -> Some Ranger
        | "Engineer" -> Some Engineer
        | "Thief" -> Some Thief
        | "Elementalist" -> Some Elementalist
        | "Necromancer" -> Some Necromancer
        | "Mesmer" -> Some Mesmer
        | _ -> None
    
    let mapToRace race =
        match race with
        | "Human" -> Some Human
        | "Charr" -> Some Charr
        | "Norn" -> Some Norn
        | "Asura" -> Some Asura
        | "Sylvari" -> Some Sylvari
        | _ -> None
    
    let mapToGender gender =
        match gender with
        | "Male" -> Some Male
        | "Female" -> Some Female
        | _ -> None
    

    let createCharacter (race, profession, gender): Character =
        (race, profession, gender)
