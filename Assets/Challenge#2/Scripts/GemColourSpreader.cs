using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GemColourSpreader : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<SpriteRenderer>().color = this.GameObject().GetComponent<SpriteRenderer>().color;
    }

}