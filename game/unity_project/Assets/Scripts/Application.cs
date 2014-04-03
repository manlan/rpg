using UnityEngine;
using System.Collections;

public class Application : MonoBehaviour
{
    private static Character player;
    private static Hashtable characters = new Hashtable();

    void Start ()
    {
        Character player = InstantiateCharacter(Random.Range(1,10000));
        setPlayer(player);

        Server.Start ();
        InvokeRepeating("Bla", 0, 0.01f); //FIXME: thats poor.
    }

    //FIXME: Remove.
    void Bla() {
        Server.ProcessNext();
    }

    public static Character InstantiateCharacter(int id) {
        if (characters.Contains(id)) return character(id);

        GameObject characterGameObject = (GameObject) Instantiate(Resources.Load("Character"), new IntVector3(1f, 1f, 1f).vector3, Quaternion.Euler(Vector3.zero));
        Character newCharacter = characterGameObject.GetComponent<Character>();
        newCharacter.id = id;
        characters.Add(newCharacter.id, newCharacter);
        return newCharacter;
    }

    public static void setPlayer(Character character) {
        Application.player = character;
        Camera.main.GetComponent<SmoothFollow>().target = character.transform;
    }

    public static Character currentPlayer() {
        return player;
    }

    private static Character character(int id) {
        return (Character) characters[id];
    }
}
