using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    [SerializeField] private int damage = 1;


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<HealthScript>().TakeHealth(damage);
            CinemachineShaker.Instance.ShakeCamera(2, .2f);
            CinemachineShaker.Instance.shakeTimer = 0.2f;
        }
    }
}
