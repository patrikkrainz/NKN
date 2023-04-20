using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static bool dead = false;
    public static bool won = false;

    public GameObject Player;

    private Vector3 spawnPosition;

    void Start()
    {
        spawnPosition = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);
    }

    void Update()
    {
        if (dead)
        {
            print("You Died :(");
            Player.transform.position = spawnPosition;
            dead = false;
        }
        else if (won)
        {
            print("Congrats you won :)");
            UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
            won = false;
        }
    }
}
