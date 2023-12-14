using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

//attached to

public class UnlockableWall : MonoBehaviour
{
    [SerializeField] GameObject wallBlock;
    [SerializeField] Mover player;

    void Update()
    {
        if (MinigameStatic.getSolderingMinigameWon() == true)
        {
            wallBlock.GetComponent<SpriteRenderer>().enabled = false;
            wallBlock.GetComponent<PolygonCollider2D>().enabled = false;
        }
    }
}
