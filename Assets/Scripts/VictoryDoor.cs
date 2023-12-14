using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryDoor : MonoBehaviour
{

    [SerializeField] private List<GameObject> itemsRequired;

    private List<GameObject> playersItems;

    [SerializeField] private GameObject Player;

    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TextMeshProUGUI dialogueBoxText;

    public int allItemsCollected;

    private bool selectable;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("EnterTrade");

        //Set Selectable on
        selectable = true;

        if (dialogueBox != null && dialogueBoxText != null)
        {
            dialogueBox.GetComponent<SpriteRenderer>().enabled = true;
            dialogueBoxText.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("ExitTrade");

        //Set Selectable off
        selectable = false;

        if (dialogueBox != null && dialogueBoxText != null)
        {
            dialogueBox.GetComponent<SpriteRenderer>().enabled = false;
            dialogueBoxText.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && selectable == true)
        {
            for (int i = 0; i < itemsRequired.Count; i++) //For each required item
            {
                ItemsStatic.checkIfCollected(itemsRequired[i].GetComponent<Tag>().getID());
                if (ItemsStatic.checkIfCollected(itemsRequired[i].GetComponent<Tag>().getID()) == true)
                {
                    allItemsCollected++;
                }
            }

            if (allItemsCollected == itemsRequired.Count) //Successfully found all items
            {
                //Transport to victory screen
                SceneManager.LoadScene("Victory");
            }
        }
    }
}
