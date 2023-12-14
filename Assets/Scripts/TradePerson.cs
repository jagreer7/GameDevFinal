using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TradePerson : MonoBehaviour
{
    public int traderID;

    [SerializeField] private List<GameObject> itemsRequired;
    [SerializeField] private GameObject itemGiven; //Item the player recieves

    private List<GameObject> playersItems;

    [SerializeField] private GameObject TraderHightlight;

    [SerializeField] private GameObject Player;

    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TextMeshProUGUI dialogueBoxText;

    public int allItemsCollected;

    private bool selectable;

    public string newMessage;

    private bool allItemsCollectedBool = false;

    [SerializeField] bool freeTrade;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("EnterTrade");

        //Set Selectable on
        selectable = true;

        //Change Highlight
        if (TraderHightlight != null)
        {
            TraderHightlight.GetComponent<SpriteRenderer>().enabled = true;
            TraderHightlight.GetComponent<SpriteRenderer>().color = Color.white;
        }

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

        //No more Highlight
        if (TraderHightlight != null)
        {
            TraderHightlight.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (dialogueBox != null && dialogueBoxText != null)
        {
            dialogueBox.GetComponent<SpriteRenderer>().enabled = false;
            dialogueBoxText.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (MinigameStatic.checkIfTradeIsDone(traderID) == false)
        {
            if (Input.GetKeyDown(KeyCode.Space) && selectable == true)
            {
                if (freeTrade == false)
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
                        allItemsCollectedBool = true;
                    }
                }
                else
                {
                    Debug.Log("No Items Required");
                    allItemsCollectedBool = true;
                }
                

                if (allItemsCollectedBool == true) //Successfully found all items
                {
                    //Send good data to dialouge box
                    if (dialogueBoxText != null)
                    {
                        dialogueBoxText.text = newMessage;
                    }
                    
                    if (freeTrade == false)
                    {
                        for (int i = 0; i < itemsRequired.Count; i++)
                        {
                            ItemsStatic.setTraded(itemsRequired[i].GetComponent<Tag>().getID());
                        }
                    }
                    
                    ItemsStatic.setCollected(itemGiven.GetComponent<Tag>().getID()); //Give the player the new item

                    MinigameStatic.setTradeIsDone(traderID);
                }
            }
        }
    }
}
