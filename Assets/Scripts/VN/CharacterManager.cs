using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterManager : MonoBehaviour {
    
    public static CharacterManager instance;

    /// <summary>
    /// semua karakter harus berada di panel karakter
    /// </summary>
    public RectTransform characterPanel;

    /// <summary>
    /// List Semua karakter yang berada di Scene
    /// </summary>
    public List<Character> characters = new List<Character>();

    // untuk mencari karakter
    public Dictionary<string, int> characterDictionary = new Dictionary<string, int>();

    void Awake()
    {
        instance = this;
    }

    // untuk memanggil karakter berdasarkan nama yang ada di list karakter
    public Character GetCharacter(string characterName, bool createCharacterIfItDoesNotExist = true, bool enableCreatedCharacterOnStart = true)
    {
        // mencari di list untuk menemukan karakter dengan cepat bila sudah ada di scene
        int index = -1;
        if (characterDictionary.TryGetValue (characterName, out index))
        {
            return characters [index];
        }
        else if (createCharacterIfItDoesNotExist)
        {
            return CreateCharacter (characterName, enableCreatedCharacterOnStart);
        }
        return null;
    }

    public Character CreateCharacter (string characterName, bool enabledOnStart = true)
    {
        Character newCharacter = new Character (characterName, enabledOnStart);
        characterDictionary.Add (characterName, characters.Count);
        characters.Add (newCharacter);

        return newCharacter;
    }

    public class CharacterPositions
    {
        public Vector2 bottomLeft = new Vector2(0f,0f);
        public Vector2 bottomRight = new Vector2(1f,0f);
        public Vector2 center = new Vector2(0.5f,0.5f);
        public Vector2 topLeft = new Vector2(0f,1f);
        public Vector2 topRight = new Vector2(1f,1f);
    }

    public static CharacterPositions characterPositions;

}