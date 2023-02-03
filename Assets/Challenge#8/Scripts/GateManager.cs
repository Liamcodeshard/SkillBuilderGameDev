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


    // Start is called before the first frame update
    void Start()
    {
        gateBrains = GameObject.FindGameObjectsWithTag("GateBrain");
        Gates.gatesLeft = gateBrains.Length;
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
            winningParticle.gameObject.SetActive(true);
            Invoke("ReloadScene", 3);
            

        }
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
        timerText.text = timer.ToString();
    }
}
