using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SelectableItem : MonoBehaviour
{
    [SerializeField] GameObject Item;
    [SerializeField] GameObject ItemHighlight;
    [SerializeField] List<GameObject> ScalableObjects;
    [SerializeField] GameObject Player;

    private bool selectable = false;
    private bool dialougeBoxOpen = false;

    [SerializeField] bool CollectableItem;

    [SerializeField] Vector3 initialPos;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enter");

        //Set Selectable on
        selectable = true;

        //Change Highlight
        
        if (ItemsStatic.checkIfCollected(this.GetComponent<Tag>().getID()) == false) //The item has not been collected or traded
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

        //remove Highlight
        ItemHighlight.GetComponent<SpriteRenderer>().enabled = false;
    }

    void Start()
    {
        initialPos = Item.transform.position;

        if (ItemsStatic.checkIfCollected(this.GetComponent<Tag>().getID()) == true) //Check if item was collected before a screen switch
        {
            Item.GetComponent<SpriteRenderer>().enabled = false;
            ItemHighlight.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && selectable == true && dialougeBoxOpen == false && ItemsStatic.checkIfCollected(this.GetComponent<Tag>().getID()) == false) //Opening
        {
            Player.GetComponent<Mover>().setAllowMovement(false);
            Player.GetComponent<SpriteRenderer>().sortingOrder = -1;
            for (var i = 0; i < ScalableObjects.Count; i++)
            {
                StartCoroutine(ScaleUpAndDown(ScalableObjects[i].transform, new Vector3(1f, 1f, 0f), new Vector3(0, 0f, 0f), 0.5f));
            }

            this.GetComponent<SpriteRenderer>().enabled = true;
            this.GetComponent<SpriteRenderer>().sortingOrder = 6;
            this.GetComponent<SpriteRenderer>().sortingLayerName = "Inventory";
            this.transform.localScale = new Vector3(10, 10, 0);
            this.transform.position = Vector3.zero;
            SetOpacity(1);

            Player.GetComponent<Mover>().setUnlockedArea(true);
            dialougeBoxOpen = true;

            
        }
        else if (Input.GetKeyDown(KeyCode.Space) && dialougeBoxOpen == true) //Closing
        {
            for (var i = 0; i < ScalableObjects.Count; i++)
            {
                StartCoroutine(ScaleUpAndDown(ScalableObjects[i].transform, new Vector3(0f, 0f, 0f), initialPos, 0.5f));
            }
            this.GetComponent<SpriteRenderer>().enabled = true;

            Player.GetComponent<SpriteRenderer>().sortingOrder = 0;
            Player.GetComponent<Mover>().setAllowMovement(true);

            dialougeBoxOpen = false;

            ItemsStatic.setCollected(this.GetComponent<Tag>().getID());

            if (CollectableItem == true)
            {
                Item.GetComponent<SpriteRenderer>().enabled = false;
                ItemHighlight.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }


    IEnumerator ScaleUpAndDown(Transform transform, Vector3 upScale, Vector3 newPos, float duration)
    {
        Vector3 initialScale = transform.localScale;
        Vector3 initialPos = transform.localPosition;
        for (float time = 0; time < duration * 2; time += Time.deltaTime)
        {
            float progress = time / duration;
            transform.localScale = Vector3.Lerp(initialScale, upScale, progress);
            transform.position = Vector3.Lerp(initialPos, newPos, progress);
            yield return null;
        }

    }

    private void SetOpacity(float opacity)
    {
        Color targetColor = this.GetComponent<SpriteRenderer>().color;
        targetColor.a = opacity;
        this.GetComponent<SpriteRenderer>().color = targetColor;
    }
}
