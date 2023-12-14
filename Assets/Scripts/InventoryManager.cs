using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryManager : MonoBehaviour
{
    // Start is called before the first frame update

    private List<Vector3> vectorList = new List<Vector3>();

    public List<GameObject> list = new List<GameObject>();

    public List<GameObject> cloneList = new List<GameObject>();

    [SerializeField] Mover player;

    [SerializeField] private GameObject Cookie1;
    [SerializeField] private GameObject Cookie2;
    [SerializeField] private GameObject Cookie3;
    [SerializeField] private GameObject Filament;
    [SerializeField] private GameObject Solder;
    [SerializeField] private GameObject Electronic;
    [SerializeField] private GameObject Instructions;
    [SerializeField] private GameObject ATLASKey0;
    [SerializeField] private GameObject ATLASKey1;
    [SerializeField] private GameObject ATLASKey2;
    [SerializeField] private GameObject ATLASKey3;

    private void Awake()
    {
        //Setting the 8 possible positions for items
        vectorList.Add(new Vector3(-4f, 0.85f, 0f)); //Pos1
        vectorList.Add(new Vector3(-1.372f, 0.85f, 0f)); //Pos2
        vectorList.Add(new Vector3(1.372f, 0.85f, 0f)); //Pos3
        vectorList.Add(new Vector3(4f, 0.85f, 0f)); //Pos4
        vectorList.Add(new Vector3(-4f, -1.83f, 0f)); //Pos5
        vectorList.Add(new Vector3(-1.372f, -1.83f, 0f)); //Pos6
        vectorList.Add(new Vector3(1.372f, -1.83f, 0f)); //Pos7
        vectorList.Add(new Vector3(4f, -1.83f, 0f)); //Pos8
    }
    void OnEnable()
    {
        Debug.Log(list.Count);
        player.setAllowMovement(false);

        for (int id = 1; id <= 11; id++)
        {
            if (ItemsStatic.checkIfCollected(id) == true && ItemsStatic.checkIfTraded(id) == false) //if i is 1, then cookie1 would get checked
            {
                if (id == 1)
                {
                    list.Add(Cookie1);
                }
                else if (id == 2)
                {
                    list.Add(Cookie2);
                }
                else if (id == 3)
                {
                    list.Add(Cookie3);
                }
                else if (id == 4)
                {
                    list.Add(Filament);
                }
                else if (id == 5)
                {
                    list.Add(Solder);
                }
                else if (id == 6)
                {
                    list.Add(Electronic);
                }
                else if (id == 7)
                {
                    list.Add(Instructions);
                }
                else if (id == 8)
                {
                    list.Add(ATLASKey0);
                }
                else if (id == 9)
                {
                    list.Add(ATLASKey1);
                }
                else if (id == 10)
                {
                    list.Add(ATLASKey2);
                }
                else if (id == 11)
                {
                    list.Add(ATLASKey3);
                }
            }
        }

        for (int i = 0; i < list.Count; i++)
        {
            list[i].GetComponent<SpriteRenderer>().enabled = true;
            list[i].GetComponent<SpriteRenderer>().sortingOrder = 6;
            list[i].GetComponent<SpriteRenderer>().sortingLayerName = "Inventory";
            list[i].transform.position = vectorList[i];
            list[i].transform.localScale = new Vector3(6, 6, 0);
        }
    }

    private void OnDisable()
    {
        player.setAllowMovement(true);

        for (int i = 0; i < list.Count; i++)
        {
            list[i].GetComponent<SpriteRenderer>().enabled = false;
        }
        list.Clear();
    }
}
