using UnityEngine;
using System.Collections;

public class Application : MonoBehaviour
{
    private static Character currentPlayer;

    void Start ()
    {
        GameObject playerGameObject = (GameObject) Instantiate(Resources.Load("Character"), new IntVector3(1f, 1f, 1f).vector3, Quaternion.Euler(Vector3.zero));
        Instantiate(Resources.Load("Character"), new IntVector3(4f, 1f, 4f).vector3, Quaternion.Euler(Vector3.zero));

        setPlayer(playerGameObject.GetComponent<Character>());

        Server.Start ();
    }

    public static void setPlayer(Character character) {
        Application.currentPlayer = character;
        Camera.main.GetComponent<SmoothFollow>().target = character.transform;
    }

    public static Character player() {
        return currentPlayer;
    }
}
