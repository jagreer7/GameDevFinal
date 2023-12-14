using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadItems : MonoBehaviour
{
    [SerializeField] GameObject load;
    [SerializeField] private string room;
    // Start is called before the first frame update
    void Start()
    {
        if(room == "kitchen"){
          if(MinigameStatic.getKitchenUnlock() == true){
              load.GetComponent<SpriteRenderer>().enabled = false;
              load.GetComponent<PolygonCollider2D>().enabled = false;
          }
        }
        if(room == "laser"){
          if(MinigameStatic.getLaserUnlock() == true){
              load.GetComponent<SpriteRenderer>().enabled = false;
              load.GetComponent<PolygonCollider2D>().enabled = false;
          }
        }
        if(room == "triangle"){
          if(MinigameStatic.getTriangleUnlock() == true){
              load.GetComponent<CircleCollider2D>().enabled = false;
          }
        }
    }
}
