using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GateManager : MonoBehaviour
{
    public static GameObject[] gateBrains;
    [SerializeField] private ParticleSystem winningParticle;
    public static float timer =0;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI fastestLapText;
    [SerializeField] private TextMeshProUGUI boardTimer;



    private float highScoreLevelOne;
    public bool resetScore = false;


    // Start is called before the first frame update
    void Start()
    {
        gateBrains = GameObject.FindGameObjectsWithTag("GateBrain");
        Gates.gatesLeft = gateBrains.Length;
        fastestLapText.text = "Fastest Lap :" + PlayerPrefs.GetFloat($"Fastest{SceneManager.GetActiveScene().name}Lap").ToString("0.00");
        if (resetScore) PlayerPrefs.SetFloat($"Fastest{SceneManager.GetActiveScene().name}Lap", 100f);


    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.racing == true)
        {
            StartTimer();
        }
        UpdateTimerUI();
        if (Gates.gatesLeft <= 0)
        {
            GameManager.racing = false;
            highScoreLevelOne = timer;
            timerText.text = highScoreLevelOne.ToString("0.00");
            winningParticle.gameObject.SetActive(true);
            CinemachineShaker.Instance.ShakeCamera(4, 3);

            CheckAndSetHighScore(highScoreLevelOne);
            Invoke("ReloadScene", 3);
            

        }
    }

    void CheckAndSetHighScore(float newTime)
    {

        if (highScoreLevelOne < PlayerPrefs.GetFloat($"Fastest{SceneManager.GetActiveScene().name}Lap"))
        {
            PlayerPrefs.SetFloat($"Fastest{SceneManager.GetActiveScene().name}Lap", highScoreLevelOne);
        }


        fastestLapText.text = "Fastest Lap : " + PlayerPrefs.GetFloat($"Fastest{SceneManager.GetActiveScene().name}Lap").ToString("0.00");

    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        timer = 0;
        Gates.gatesLeft = gateBrains.Length;
        Gates.firstGate = true;
    }
    public static void StartTimer()
    {
        timer += Time.deltaTime;
    }

    void UpdateTimerUI()
    {
        timerText.text = "LapTime: " + timer.ToString("0.00");
        boardTimer.text = "LapTime: " + timer.ToString("0.00");

    }
}
