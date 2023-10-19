import { Character } from "@/shared/domain";

export async function GET(req: Request) {
  const apiKey = req.headers.get("ApiKey");

  const response = await fetch(
    "https://api.guildwars2.com/v2/characters?ids=all",
    {
      headers: { Authorization: `Bearer ${apiKey}` },
    }
  );

  if (!response.ok) {
    Response.error();
  }

  const body = await response.json();

  return Response.json(
    body.map(({ name, race, gender, profession, level }: Character) => {
      return { name, race, gender, profession, level };
    })
  );
}
