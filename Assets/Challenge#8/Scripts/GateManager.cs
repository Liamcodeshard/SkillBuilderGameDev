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


    private float highScoreLevelOne;
    public bool resetScore = false;


    // Start is called before the first frame update
    void Start()
    {
        gateBrains = GameObject.FindGameObjectsWithTag("GateBrain");
        Gates.gatesLeft = gateBrains.Length;
        fastestLapText.text = "Fastest Lap : " + PlayerPrefs.GetFloat("FastestLevelOneLap").ToString();
        if (resetScore) PlayerPrefs.SetFloat("FastestLevelOneLap", 100f);


    }

    // Update is called once per frame
    void Update()
    {

        if (Gates.racing == true)
        {
            StartTimer();
        }
        UpdateTimerUI();
        if (Gates.gatesLeft <= 0)
        {
            Gates.racing = false;
            highScoreLevelOne = timer;
            timerText.text = highScoreLevelOne.ToString();
            winningParticle.gameObject.SetActive(true);

            CheckAndSetHighScore(highScoreLevelOne);
            Invoke("ReloadScene", 3);
            

        }
    }

    void CheckAndSetHighScore(float newTime)
    {

        if (highScoreLevelOne < PlayerPrefs.GetFloat("FastestLevelOneLap"))
        {
            PlayerPrefs.SetFloat("FastestLevelOneLap", highScoreLevelOne);
            print(PlayerPrefs.GetFloat("FastestLevelOneLap"));
        }


        fastestLapText.text = "Fastest Lap : " + PlayerPrefs.GetFloat("FastestLevelOneLap").ToString();

    }
    public void ReloadScene()
    {
        SceneManager.LoadScene("Sandbox");
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
        timerText.text = "LapTime: " + timer.ToString();
    }
}
