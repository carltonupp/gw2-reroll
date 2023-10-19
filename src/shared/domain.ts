type Gender = "Male" | "Female";
type Race = "Human" | "Charr" | "Norn" | "Asura" | "Sylvari";
type Profession =
  | "Warrior"
  | "Guardian"
  | "Revenant"
  | "Ranger"
  | "Engineer"
  | "Thief"
  | "Elementalist"
  | "Necromancer"
  | "Mesmer";

export type Character = {
  name: string;
  gender: Gender;
  race: Race;
  profession: Profession;
  level: number;
};

export function recommend(characterData: Character[]): string {
  const profs = new Array<Profession>(
    "Warrior",
    "Guardian",
    "Revenant",
    "Ranger",
    "Thief",
    "Engineer",
    "Elementalist",
    "Necromancer",
    "Mesmer"
  );

  if (characterData.length === 0) {
    return "EMPTY";
  }

  let diff = profs.filter(
    (p) => !characterData.map((c) => c.profession).includes(p)
  );

  if (diff.length > 0) {
    return JSON.stringify(diff);
  }

  return "NAY";
}
