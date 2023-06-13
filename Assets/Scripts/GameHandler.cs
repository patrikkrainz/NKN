using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static bool dead = false;
    public static bool won = false;
    public bool paused = false;

    public GameObject Player;
    public GameObject MainM;
    public GameObject PauseM;
    public GameObject LS;
    public GameObject DeathScreen;
    public GameObject WinScreen;

    private KeyCode PauseGame = KeyCode.P;

    private Vector3 spawnPosition;

    private float Level = 0;
    private float Deathcount = 0;

    void Start()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name.ToString() == "MainMenu")
        {
            MainM.SetActive(true);
        }
        else
        {
            spawnPosition = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);
        }
    }

    void Update()
    {
        if (dead)
        {
            print("You Died :(");
            DeathScreen.SetActive(true);
            Deathcount += 1;
            Player.transform.position = spawnPosition;
            dead = false;
        }
        else if (won)
        {
            print("Congrats you won :)");
            WinScreen.SetActive(true);
            Level += 1;
            Deathcount = 0;
            UnityEngine.SceneManagement.SceneManager.LoadScene("Level" + Level.ToString());
            won = false;
        }

        if (Input.GetKeyDown(PauseGame))
        {
            if (!paused)
            {
                paused = true;
                Time.timeScale = 0;
                PauseM.SetActive(true);
                Cursor.visible = true;
            }
            else
            {
                paused = false;
                Time.timeScale = 1;
                PauseM.SetActive(false);
                Cursor.visible = false;
            }
        }
    }

    public void pressStart()
    {
        Cursor.visible = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
    }

    public void pressLS()
    {
        LS.SetActive(true);

        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name.ToString() == "MainMenu")
        {
            MainM.SetActive(false);
        }
        else
        {
            PauseM.SetActive(false);
        }
    }

    public void pressLevel1()
    {
        Cursor.visible = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
    }

    public void pressLevel2()
    {
        Cursor.visible = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level2");
    }

    public void pressLevel3()
    {
        Cursor.visible = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level3");
    }

    public void pressQuit()
    {
        Application.Quit();
    }

    public void pressBack()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name.ToString() == "MainMenu")
        {
            MainM.SetActive(true);
        }
        else
        {
            PauseM.SetActive(true);
        }
    }

    public void pressContinue()
    {
        PauseM.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
    }

    public void pressBTMM()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
