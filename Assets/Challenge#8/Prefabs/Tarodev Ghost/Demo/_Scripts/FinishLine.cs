using System;
using UnityEngine;

public class FinishLine : MonoBehaviour 
{
   // [SerializeField] private GameObject _startVisual, _finishedVisual;

    public static event Action<bool> Crossed;

    private bool _running;

    private void Awake() 
    {
      //  _startVisual.SetActive(true);
      //  _finishedVisual.SetActive(false);
    }


    // what do these do? set the waypoint on and off
   // private void OnEnable() => Goal.OnGoalTriggered += GoalOnOnGoalTriggered;
   // private void OnDisable() => Goal.OnGoalTriggered -= GoalOnOnGoalTriggered;

    private void GoalOnOnGoalTriggered() 
    {
       // _finishedVisual.SetActive(true);
    }

    private void OnTriggerEnter(Collider col) 
    {
        // if (_running && !_finishedVisual.activeSelf) return;

        if (col.tag == "Player" && this.tag == "Start")
        {
            _running = true;
            //  _startVisual.SetActive(false);
            // _finishedVisual.SetActive(false);
            Crossed?.Invoke(_running);
        }
        if (col.tag == "Player" && this.tag == "Finish")
        {
            _running = false;
            //  _startVisual.SetActive(false);
            // _finishedVisual.SetActive(false);
            Crossed?.Invoke(_running);
        }
    }

    private void OnTriggerExit(Collider col) 
    {
       // _startVisual.SetActive(!_running);
    }
}