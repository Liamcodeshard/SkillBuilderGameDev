using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static bool racing = false;
    private bool paused = false;

    public static float timer = 0;

    public CinemachineVirtualCamera fpsCam;
    public CinemachineVirtualCamera thirdPersonCam;
    public CinemachineVirtualCamera godViewCam;

    public static GameManager instance;

    // UI Stuff
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI fastestLapText;
    [SerializeField] private TextMeshProUGUI boardTimer1 = null;
    [SerializeField] private TextMeshProUGUI boardTimer2 = null;

    public bool resetSpeedLapTime = false;


    private float highScoreLevelOne;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        ResetRace();
        CheckAndSetPlayerPrefs();
        if (resetSpeedLapTime) PlayerPrefs.SetFloat($"Fastest{SceneManager.GetActiveScene().name}Lap", 100f);
        print(PlayerPrefs.GetFloat($"Fastest{SceneManager.GetActiveScene().name}Lap"));

    }

    // Update is called once per frame
    void Update()
    {
        CameraSwitcher();

        highScoreLevelOne = timer;
        timerText.text = highScoreLevelOne.ToString("0.00");


        if (GameManager.racing)
        {
            StartTimer();
        }
        else if(!GameManager.racing)
        {
            ResetRace();
        }

        UpdateTimerUI();

    }

    private void CameraSwitcher()
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

    public static void StartTimer()
    {
        timer += Time.deltaTime;
    }

    public void CheckAndSetPlayerPrefs()
    {
        if (!PlayerPrefs.HasKey($"Fastest{SceneManager.GetActiveScene().name}Lap") || PlayerPrefs.GetFloat($"Fastest{SceneManager.GetActiveScene().name}Lap") < 1)
        {
            PlayerPrefs.SetFloat($"Fastest{SceneManager.GetActiveScene().name}Lap", 100f);
        }
    }

    // ran by the FinishLine  script
    public void CheckAndSetHighScore()
    {
        print("Checking");
        if (highScoreLevelOne < PlayerPrefs.GetFloat($"Fastest{SceneManager.GetActiveScene().name}Lap"))
        {
            PlayerPrefs.SetFloat($"Fastest{SceneManager.GetActiveScene().name}Lap", highScoreLevelOne);
        }

        fastestLapText.text = "Speed Lap : " + PlayerPrefs.GetFloat($"Fastest{SceneManager.GetActiveScene().name}Lap").ToString("0.00");

    }

    public void ResetLap()
    {
        timer = 0;
        Gates.firstGate = true;

        // set the gates triggered back to false
        /*
         foreach (GameObject gateBrain in GateManager.gateBrains)
        {
            gateBrain.GetComponent<Gates>().triggered = false;
        }
        */
    }
    void UpdateTimerUI()
    {
        timerText.text = "LapTime: " + timer.ToString("0.00");
        fastestLapText.text = "Speed Lap : " + PlayerPrefs.GetFloat($"Fastest{SceneManager.GetActiveScene().name}Lap").ToString("0.00");

        if (boardTimer1 != null)
        {
            boardTimer1.text = timer.ToString("0.00");
        }
        if (boardTimer2 != null)
        {
            boardTimer2.text = timer.ToString("0.00");
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

    public static void ResetRace()
    {
        timer = 0;
       // Gates.gatesLeft = GateManager.gateBrains.Length;
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
