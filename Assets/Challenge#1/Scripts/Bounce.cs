using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bounce : MonoBehaviour
{
    [SerializeField] float jumpForce = 1000f;
    
    void OnTriggerEnter(Collider other)
    {
        // Challenge 1: 
        JumpyJumpy(other);
    }

    void JumpyJumpy(Collider other)
    {
        other.attachedRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Force);

    }
}
