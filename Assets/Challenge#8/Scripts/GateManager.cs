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
    [SerializeField] private TextMeshProUGUI boardTimer1 = null;
    [SerializeField] private TextMeshProUGUI boardTimer2 = null;




    private float highScoreLevelOne;
    public bool resetScore = false;


    // Start is called before the first frame update
    void Start()
    {
        gateBrains = GameObject.FindGameObjectsWithTag("GateBrain");
        Gates.gatesLeft = gateBrains.Length;
        print(gateBrains.Length);
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
        print(Gates.gatesLeft);
        if (Gates.gatesLeft <= 0)
        {
            GameManager.racing = false;
            highScoreLevelOne = timer;
            timerText.text = highScoreLevelOne.ToString("0.00");
            winningParticle.gameObject.SetActive(true);
           // CinemachineShaker.Instance.ShakeCamera(4, 3);

            CheckAndSetHighScore(highScoreLevelOne);

            // Invoke("ReloadScene", 3);
            Invoke("ResetLap", 1f);



        }
    }

    void CheckAndSetHighScore(float newTime)
    {

        if (highScoreLevelOne < PlayerPrefs.GetFloat($"Fastest{SceneManager.GetActiveScene().name}Lap"))
        {
            PlayerPrefs.SetFloat($"Fastest{SceneManager.GetActiveScene().name}Lap", highScoreLevelOne);
        }


        fastestLapText.text = "Speed Lap : " + PlayerPrefs.GetFloat($"Fastest{SceneManager.GetActiveScene().name}Lap").ToString("0.00");

    }

    void ResetLap()
    {
        timer = 0;
        Gates.gatesLeft = gateBrains.Length;
        Gates.firstGate = true;

        // set the gates triggered back to false
        foreach (GameObject gateBrain in gateBrains)
        {
            gateBrain.GetComponent<Gates>().triggered = false;
        }
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
        if (boardTimer1 != null && boardTimer2 != null)
        {
            boardTimer1.text = timer.ToString("0.00");
            boardTimer2.text = timer.ToString("0.00");
        }

    }
}
