import { Character } from "./domain";

export function getCharacterData(apiKey: string): Promise<Character[]> {
  return fetch("/api", {
    headers: { ApiKey: apiKey },
  }).then((response) => response.json());
}
