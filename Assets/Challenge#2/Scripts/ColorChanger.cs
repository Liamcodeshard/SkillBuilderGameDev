// GameDev.tv ChallengeClub.Got questionsor wantto shareyour niftysolution?
// Head over to - http://community.gamedev.tv

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private SpriteRenderer mySpriteRenderer;
    private Color colors;
    private enum colorChangeEnum
    {
        blue, red, yellow
    }

    [SerializeField] private colorChangeEnum color;
    void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();        
    }

    void Start()
    {
        switch (color)
        {
            case colorChangeEnum.red:
                colors = Color.red;
                break;
            case colorChangeEnum.blue:
                colors = Color.blue;
                break;
            case colorChangeEnum.yellow:
                colors = Color.yellow;
                break;
        }
        mySpriteRenderer.color = colors;

    }


}
