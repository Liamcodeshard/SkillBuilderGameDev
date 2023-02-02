// GameDev.tv Challenge Club. Got questions or want to share your nifty solution?
// Head over to - http://community.gamedev.tv

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates : MonoBehaviour
{
    [SerializeField] MeshRenderer leftGate;
    [SerializeField] MeshRenderer rightGate;

    private static int gatesLeft = 2;
    private bool triggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (!triggered)
        {
            rightGate.material.color = Color.yellow;
            leftGate.material.color = Color.yellow;
            TriggerCheckpoint();
            triggered = true;
        }

    }
    
    static void TriggerCheckpoint()
    {
        if(gatesLeft > 0)
        {
            gatesLeft--;
        }
        print("gates left: " + gatesLeft.ToString());
    }
}
