// GameDev.tv ChallengeClub.Got questionsor wantto shareyour niftysolution?
// Head over to - http://community.gamedev.tv

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private SpriteRenderer mySpriteRenderer;

    private Color[] colors = new Color[] { Color.red, Color.yellow, Color.blue };
    private enum colorOptions
    {
         red = 0, yellow, blue
    }

    [SerializeField] private colorOptions selection;
    void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        mySpriteRenderer.color = colors[(int)selection];
    }

    void Update()
    {


    }

    public void SetRandColour()
    {
        mySpriteRenderer.color = colors[Random.Range(0, 3)];
    }

}
