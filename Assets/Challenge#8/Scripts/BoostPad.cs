using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoostPad : MonoBehaviour
{
    private Rigidbody rb;
    public int boostAmount = 10000;

    void OnTriggerEnter(Collider other)
    {
        rb = other.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * boostAmount, ForceMode.Acceleration);
        print("ForceAdded");
    }


}
