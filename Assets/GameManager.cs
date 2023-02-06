using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool racing = false;
    private bool paused = false;

    public static GameManager instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RaceToggle()
    {
        racing = !racing;
    }

    public void ReplayCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        ResetRace();
    }

    private static void ResetRace()
    {
        GateManager.timer = 0;
        Gates.gatesLeft = GateManager.gateBrains.Length;
        Gates.firstGate = true;
        Time.timeScale = 1;
        racing = false;
    }

    public void QuitGame()
    {
        Application.Quit();
        print("HaveQuit");
    }

    public void PauseSceneToggle()
    {
        paused = !paused;
        if (paused) Time.timeScale = 0f;
        else Time.timeScale = 1f;
    }
}
