using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{
    [SerializeField] private int carHealth = 2;
    public TextMeshProUGUI livesText;
    [SerializeField] public ParticleSystem brokenSmoke;
    private int emissionRate= 0;

    // to show sparks when crashing
    [SerializeField]
    ParticleSystem bounceParticleSystem;

    [SerializeField]
    int bounceParticleEmission = 20;

    void Start()
    {
        var emission = brokenSmoke.emission;
    }

    void EmitBounceParticles(float x, float z, float rotation)
    {
        ParticleSystem.ShapeModule shape = bounceParticleSystem.shape;
        shape.position = new Vector3(x, 0f, z);
        shape.rotation = new Vector3(0f, rotation, 0f);
        bounceParticleSystem.Emit(bounceParticleEmission);
        print("Bounce");
    }


    public void TakeHealth(int damage)
    {
        carHealth-= damage;
        emissionRate += 20;

    }
    public void GiveHealth()
    {
        carHealth++;
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Update()
    {       

        if (carHealth > 0)
        {        
            var emission = brokenSmoke.emission;
            emission.rateOverTime = emissionRate;
            livesText.text = carHealth.ToString();

        }
        else
        {
            var emission = brokenSmoke.emission;
            emission.rateOverTime = 200;
            livesText.text = "You Deadddd";
            Invoke("ReloadScene", 3);
            GateManager.timer = 0;
            Gates.gatesLeft = GateManager.gateBrains.Length;
            Gates.firstGate = true;
            GameManager.racing = false;

        }

    }

}
