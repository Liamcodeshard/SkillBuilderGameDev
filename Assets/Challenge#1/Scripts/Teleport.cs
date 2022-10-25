using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

// GameDev.tv Challenge Club. Got questions or want to share your nifty solution?
// Head over to - http://community.gamedev.tv

public class Teleport : MonoBehaviour
{
    [SerializeField] Transform teleportTarget;
    [SerializeField] GameObject player;
    [SerializeField] Light areaLight;
    [SerializeField] Light mainWorldLight;
    private bool hasBeenUsed = false;
    [SerializeField] private float timeDelay;

    void Start() 
    {
        // CHALLENGE TIP: Make sure all relevant lights are turned off until you need them on
        // because, you know, that would look cool.
        areaLight.GetComponent<Light>().intensity = 0;
        mainWorldLight.GetComponent<Light>().intensity = 0;

    }

    void OnTriggerEnter(Collider other) 
    {
        // Challenge 2:
        TeleportPlayer();
        // Challenge 3: DeactivateObject();
        // Challenge 4: 
        IlluminateArea();
        // Challenge 5:
       // StartCoroutine ("BlinkWorldLight");
        // Challenge 6: TeleportPlayerRandom();
    }

    void TeleportPlayer()
    {
        // code goes here
        if (!hasBeenUsed)
        {
            player.transform.position = teleportTarget.transform.position;
            StartCoroutine(BlinkWorldLight());
            hasBeenUsed = true;

        }
    }

    void DeactivateObject()
    {
        
        // code goes here 
        this.gameObject.GetComponent<Teleport>().enabled = false;
        // why does this not work?


    }

    void IlluminateArea()
    {
       // code goes here 
       areaLight.GetComponent<Light>().intensity = 8;
    }

     IEnumerator BlinkWorldLight()
     {

            mainWorldLight.GetComponent<Light>().intensity = 1;
            print("Lights on");
            timeDelay = .1f;
            yield return new WaitForSeconds(timeDelay);
            mainWorldLight.GetComponent<Light>().intensity = 0;
            print("Lights on");
            timeDelay = 0.2f;
            yield return new WaitForSeconds(timeDelay);
            mainWorldLight.GetComponent<Light>().intensity = 1;
            print("Lights on");
            timeDelay = .2f;
            yield return new WaitForSeconds(timeDelay);
            mainWorldLight.GetComponent<Light>().intensity = 0;
            print("Lights on");
            timeDelay = .1f;
            yield return new WaitForSeconds(timeDelay);
        

    }

    void TeleportPlayerRandom()
    {
        // code goes here... or you could modify one of your other methods to do the job.
    }

}
