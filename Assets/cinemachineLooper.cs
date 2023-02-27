using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cinemachineLooper : MonoBehaviour
{
    private float timer;
    [SerializeField] GameObject obj;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 10)
        {
            print("HighTime");
            obj.SetActive(false);
            obj.SetActive(true);
        }
    }

}
