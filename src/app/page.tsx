"use client";
import { useState } from "react";
import { Character, recommend } from "@/shared/domain";
import { getCharacterData } from "@/shared/api";

export default function Home() {
  const [apiKey, setApiKey] = useState("");
  const [characters, setCharacters] = useState<Character[]>([]);
  return (
    <main>
      <input
        type="text"
        placeholder="Api Key"
        value={apiKey}
        onChange={(event) => setApiKey(event.target.value)}
      ></input>
      <button
        onClick={() =>
          getCharacterData(apiKey).then((response) => setCharacters(response))
        }
      >
        Synchronize
      </button>
      <div>
        <ul>
          {characters.map((c, i) => {
            return (
              <li key={i}>
                <code>{JSON.stringify(c)}</code>
              </li>
            );
          })}
        </ul>
      </div>
      <div>Recommendation: {recommend(characters)}</div>
    </main>
  );
}
