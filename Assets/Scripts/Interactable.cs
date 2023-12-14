using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] GameObject ItemHighlight;
    [SerializeField] GameObject lights;
    private bool selectable = false;
    private bool lightsOn = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
      if(other.CompareTag("Player")){
        selectable = true;
        ItemHighlight.GetComponent<SpriteRenderer>().enabled = true;
        ItemHighlight.GetComponent<SpriteRenderer>().color = Color.white;
      }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
          selectable = false;
          ItemHighlight.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    void Update(){
      if(Input.GetKeyDown(KeyCode.Space) && selectable == true && lightsOn == false){
        lights.GetComponent<SpriteRenderer>().enabled = true;
        lightsOn = true;
      } else if(Input.GetKeyDown(KeyCode.Space) && selectable == true && lightsOn == true){
        lights.GetComponent<SpriteRenderer>().enabled = false;
        lightsOn = false;
      }
    }
}
