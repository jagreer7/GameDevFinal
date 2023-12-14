using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject Player;

    private bool inventoryIsOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        GraphicsSettings.transparencySortMode = TransparencySortMode.CustomAxis;
        GraphicsSettings.transparencySortAxis = new Vector3(0.0f, 1.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && inventoryIsOpen == false) //Open Inventory
        {
            Debug.Log("opening");
            inventory.SetActive(true);
            inventoryIsOpen = true;
            Player.GetComponent<Mover>().setAllowMovement(false);
            Player.GetComponent<SpriteRenderer>().sortingOrder = -1;
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && inventoryIsOpen == true) //Open Inventory
        {
            Debug.Log("Closing");
            inventory.SetActive(false);
            inventoryIsOpen = false;
            Player.GetComponent<SpriteRenderer>().sortingOrder = 0;
            Player.GetComponent<Mover>().setAllowMovement(true);
        }
    }
}
