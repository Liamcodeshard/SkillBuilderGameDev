// GameDev.tv Challenge Club. Got questions or want to share your nifty solution?
// Head over to - http://community.gamedev.tv

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates : MonoBehaviour
{
    [SerializeField] MeshRenderer leftGate;
    [SerializeField] MeshRenderer rightGate;
    [SerializeField] private ParticleSystem gateParticles;

    public static int gatesLeft;
    public static bool firstGate = true;
    //public static bool racing = false;
    public bool triggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && triggered ==false)
        {
                rightGate.material.color = Color.yellow;
                leftGate.material.color = Color.yellow;
                TriggerCheckpoint();
                gateParticles.gameObject.SetActive(true);
                triggered = true;
        }

    }
    
    static void TriggerCheckpoint()
    {
        if(gatesLeft > 0)
        {
            gatesLeft--;
        }

        if (firstGate)
        {
            firstGate = false;
            GameManager.racing = true;
        }
    }
}
