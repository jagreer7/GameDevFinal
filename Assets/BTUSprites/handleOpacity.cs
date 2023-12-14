using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handleOpacity : MonoBehaviour
{
    [SerializeField] private GameObject[] walls;
    [SerializeField] private float newOpacity = 0.5f;
    [SerializeField] private float originalOpacity = 1f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject wall in walls)
            {
                SpriteRenderer spriteRenderer = wall.GetComponent<SpriteRenderer>();
                Color newColor = spriteRenderer.color;
                newColor.a = newOpacity;
                spriteRenderer.color = newColor;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject wall in walls)
            {
                SpriteRenderer spriteRenderer = wall.GetComponent<SpriteRenderer>();
                Color newColor = spriteRenderer.color;
                newColor.a = originalOpacity;
                spriteRenderer.color = newColor;
            }
        }
    }
}
