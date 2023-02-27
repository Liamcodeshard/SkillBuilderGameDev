using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MenuScreen");
    }
    public void GoToRaceOne()
    {
        SceneManager.LoadScene("Race 1");

    }
    public void GoToRaceTwo()
    {
        SceneManager.LoadScene("Race 2");
    }
}
