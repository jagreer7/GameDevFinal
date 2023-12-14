using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectableMinigame : MonoBehaviour
{
    [SerializeField] GameObject Item;
    [SerializeField] GameObject ItemHighlight;
    [SerializeField] GameObject Player;

    [SerializeField] string minigameSceneName;

    private bool selectable = false;

    [SerializeField] private bool specialMover;

    [SerializeField] GameObject requiredItem;
    [SerializeField] private bool requiredItemFound = false;

    [SerializeField] Vector3 initialPos;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enter");

        //Set Selectable on
        selectable = true;

        //Change Highlight
        if (ItemHighlight != null)
        {
            ItemHighlight.GetComponent<SpriteRenderer>().enabled = true;
            ItemHighlight.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Exit");

        //Set Selectable off
        selectable = false;

        //No more Highlight
        if (ItemHighlight != null)
        {
            ItemHighlight.GetComponent<SpriteRenderer>().enabled = false;
        }

    }

    void Start()
    {
        initialPos = Item.transform.position;
    }


    void Update()
    {
        if (requiredItem != null)
        {
            if (ItemsStatic.checkIfCollected(requiredItem.GetComponent<Tag>().getID()) == true)
            {
                requiredItemFound = true;
            }
        }
        else
        {
            requiredItemFound = true;
        }
        

        if (Input.GetKeyDown(KeyCode.Space) && selectable == true && requiredItemFound == true) //Opening
        {
            Player.GetComponent<Mover>().setAllowMovement(false);
            Player.GetComponent<SpriteRenderer>().sortingOrder = -1;

            Debug.Log("Loading minigame");

            //Save players position
            if (specialMover == false)
            {
                Player.GetComponent<Mover>().setStartingPos(Player.transform.position);
            }
            

            //Load scene
            if (minigameSceneName != null)
            {
                SceneManager.LoadScene(minigameSceneName);
            }
        }
    }
}
