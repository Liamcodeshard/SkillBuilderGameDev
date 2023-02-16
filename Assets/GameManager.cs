using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public static bool racing = false;
    private bool paused = false;

    public CinemachineVirtualCamera fpsCam;
    public CinemachineVirtualCamera thirdPersonCam;
    public CinemachineVirtualCamera godViewCam;

    public static GameManager instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        ResetRace();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            fpsCam.gameObject.SetActive(false);
            fpsCam.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            thirdPersonCam.gameObject.SetActive(false);
            thirdPersonCam.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            godViewCam.gameObject.SetActive(false);
            godViewCam.gameObject.SetActive(true);
        }
    }



    public void RaceToggle()
    {
        racing = !racing;
    }
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
