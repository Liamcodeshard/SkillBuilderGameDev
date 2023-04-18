using System;
using UnityEngine;

public class FinishLine : MonoBehaviour 
{
   // [SerializeField] private GameObject _startVisual, _finishedVisual;

    public static event Action<bool> Crossed;

    private bool _running;

    [SerializeField] private ParticleSystem winningParticle;


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
            Crossed?.Invoke(_running);
            GameManager.racing = true;
        }
        if (col.tag == "Player" && this.tag == "Finish")
        {
            _running = false;
            GameManager.racing = false;
            Crossed?.Invoke(_running);
           // GameManager.racing = false;

            GameManager.instance.CheckAndSetHighScore();

            GameManager.instance.ResetLap();


            winningParticle.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider col) 
    {
       // _startVisual.SetActive(!_running);
    }
}