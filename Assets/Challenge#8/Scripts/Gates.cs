// GameDev.tv Challenge Club. Got questions or want to share your nifty solution?
// Head over to - http://community.gamedev.tv

using System.Collections;
using System.Collections.Generic;
using UnityEditor.EventSystems;
using UnityEngine;

public class Gates : MonoBehaviour
{
    [SerializeField] MeshRenderer leftGate;
    [SerializeField] MeshRenderer rightGate;
    [SerializeField] private ParticleSystem gateParticles;


    // set by gatemanager
    public static int gatesLeft;
    public static bool firstGate = true;

    // moved to game managerr
    //public static bool racing = false;
    public bool triggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && triggered ==false)
        { 
            rightGate.material.color = Color.yellow;
            leftGate.material.color = Color.yellow;
            TriggerCheckpoint();
            //gateParticles.Play();
            gateParticles.gameObject.SetActive(true);
            triggered = true;
        }

    }
    
    static void TriggerCheckpoint()
    {
        // checks first gate and sets off timer
        if (firstGate)
        {
            firstGate = false;
            GameManager.racing = true;
        }
        
        if(gatesLeft > 0)
        {
            gatesLeft--;
        }
        
        if(gatesLeft == 0)
        {
            print("0");
            GameManager.racing = false;
            GameManager.instance.CheckAndSetHighScore();
        }
    }
 
}
