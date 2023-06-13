using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static bool dead = false;
    public static bool won = false;
    public static bool paused = false;

    public GameObject Player;
    public GameObject MainM;
    public GameObject PauseM;
    public GameObject LS;
    public GameObject DT;
    public GameObject Background;
    public GameObject Title;
    public GameObject DeathScreen;
    public GameObject WinScreen;

    private KeyCode PauseGame = KeyCode.Escape;

    private Vector3 spawnPosition;

    private float Level = 0;
    private float DeathCount = 0;
    private float Timer = 0;

    public TextMeshProUGUI DeathCountT;
    public TextMeshProUGUI TimerT;

    void Start()
    {
        WinScreen.SetActive(false);

        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name.ToString() == "MainMenu")
        {
            Title.SetActive(true);
            Background.SetActive(true);
            MainM.SetActive(true);
            Level = 0;
        }
        else
        {
            spawnPosition = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);
            DT.SetActive(true);
            Title.SetActive(false);
            Background.SetActive(false);
        }

        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name.ToString() == "Level1")
        {
            Level = 1;
        }
        else if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name.ToString() == "Level2")
        {
            Level = 2;
        }
        else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name.ToString() == "Level3")
        {
            Level = 3;
        }
    }

    void Update()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name.ToString() != "MainMenu")
        {
            if (dead)
            {
                Time.timeScale = 0;
                DT.SetActive(false);
                DeathScreen.SetActive(true);
                DeathCount += 1;
            }
            else if (won)
            {
                Time.timeScale = 0;
                WinScreen.SetActive(true);
                Background.SetActive(true);
            }

            if(Input.GetKeyDown(KeyCode.Space))
            {
                if (WinScreen.activeSelf)
                {
                    Time.timeScale = 1;
                    DeathCount = 0;
                    Timer = 0;
                    won = false;
                    Level += 1;

                    if(Level > 0 && Level < 4)
                    {
                        UnityEngine.SceneManagement.SceneManager.LoadScene("Level" + Level.ToString());
                    }
                }
                else if (DeathScreen.activeSelf)
                {
                    DeathScreen.SetActive(false);
                    Time.timeScale = 1;
                    Player.transform.position = spawnPosition;
                    dead = false;
                }
            }

            if (!WinScreen && !DeathScreen && Input.GetKeyDown(PauseGame))
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

            DeathCountT.text = DeathCount.ToString();
            Timer += Time.deltaTime;
            TimerT.text = Timer.ToString("F1");

            if(Level == 4)
            {
                pressBTMM();
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
        paused = false;
        DeathCount = 0;
        Timer = 0;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
    }

    public void pressLevel2()
    {
        Cursor.visible = false;
        paused = false;
        DeathCount = 0;
        Timer = 0;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level2");
    }

    public void pressLevel3()
    {
        Cursor.visible = false;
        paused = false;
        DeathCount = 0;
        Timer = 0;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level3");
    }

    public void pressQuit()
    {
        Application.Quit();
    }

    public void pressBack()
    {
        LS.SetActive(false);

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
        Title.SetActive(false);
        Background.SetActive(false);
        PauseM.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        paused = false;
    }

    public void pressBTMM()
    {
        Time.timeScale = 1;
        paused = false;
        DT.SetActive(false);
        DeathCount = 0;
        Timer = 0;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
