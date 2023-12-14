using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tag : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int id;
    
    public int getID()
    {
        return id;
    }
}
