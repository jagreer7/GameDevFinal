using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opacity : MonoBehaviour
{
  public SpriteRenderer targetSpriteRenderer; 
  public float targetOpacity = 0.5f;

  private void OnTriggerEnter2D(Collider2D other)
  {
      if (other.CompareTag("Player")) // Change "Player" to the tag of your player object
      {
          SetOpacity(targetOpacity);
      }
  }

  private void OnTriggerExit2D(Collider2D other)
  {
      if (other.CompareTag("Player")) // Change "Player" to the tag of your player object
      {
          // You can reset the opacity or perform other actions when the player exits the collider
          // For example, uncomment the line below to reset opacity to 1.
          SetOpacity(1f);
      }
  }

  private void SetOpacity(float opacity)
  {
      Color targetColor = targetSpriteRenderer.color;
      targetColor.a = opacity;
      targetSpriteRenderer.color = targetColor;
  }
}
