using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticChange : MonoBehaviour
{
    [SerializeField] GameObject button;

    private void OnTriggerEnter2D(Collider2D other)
    {
      if(other.CompareTag("Player")){
        button.GetComponent<CircleCollider2D>().enabled = true;
      }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
      if(other.CompareTag("Player")){
        button.GetComponent<CircleCollider2D>().enabled = false;
      }
    }
}
