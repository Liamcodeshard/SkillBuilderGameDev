using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{
    [SerializeField] private int carHealth = 2;
    public TextMeshProUGUI livesText;

    public void TakeHealth()
    {
        carHealth--;
    }
    public void GiveHealth()
    {
        carHealth++;
    }

    void ReloadScene()
    {
        SceneManager.LoadScene("Sandbox");
    }

    void Update()
    {
        if (carHealth > 0)
        {
            livesText.text = carHealth.ToString();

        }
        else
        {
            livesText.text = "You Deadddd";
            Invoke("ReloadScene", 3);
        }

    }

}
