using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gridlock : MonoBehaviour
{
  [SerializeField] private GameObject[] squares;
  [SerializeField] private GameObject[] highlights;
  private GameObject current;
  private int currentIndex = 0;
  private bool won = false;

  // Change validColors array to use hex codes
  private string[] hexColorCodes = { "#b03a48", "#5c8b93", "#3e6958", "#e0c872" }; //red, blue, green, yellow
  private Color[] validColors;

  private int[] correctCombo = { 2, 1, 3, 0 }; // green, blue, yellow, red
  private int[] currentColorIndex = { 0, 1, 2, 3 };
  private int[] pos = { 0, 0 };

  void Start()
  {
      current = squares[0];
      validColors = new Color[hexColorCodes.Length];

      for (int i = 0; i < hexColorCodes.Length; i++)
      {
          if (ColorUtility.TryParseHtmlString(hexColorCodes[i], out validColors[i]))
          {
              SpriteRenderer square = squares[i].GetComponent<SpriteRenderer>();
              SpriteRenderer highlight = highlights[i].GetComponent<SpriteRenderer>();
              square.color = validColors[i];
              highlight.enabled = false;
          }
          else
          {
              // Handle the case where hex code is not valid
              Debug.LogError("Invalid hex code: " + hexColorCodes[i]);
          }
      }
  }

    // Update is called once per frame
    void Update()
    {
      if(won == false){
        //Clear Highlights
        for(int i = 0; i < 4; i++){
          SpriteRenderer highlight = highlights[i].GetComponent<SpriteRenderer>();
          highlight.enabled = false;
        }
        //SpriteRenderer ex = exitHighlight.GetComponent<SpriteRenderer>();
        //ex.enabled = false;

        handleMovement();

        if(Input.GetKeyDown(KeyCode.Space) == true){
          handleSelect();
        } else if(Input.GetKeyDown(KeyCode.Escape)) {
          handleExit();
        }

        checkWin();
      }

    }

    private void handleExit(){
      SceneManager.LoadScene("Fixed");
    }

    private void handleSelect()
    {
        SpriteRenderer square = current.GetComponent<SpriteRenderer>();
        if (currentColorIndex[currentIndex] == validColors.Length - 1)
        {
            currentColorIndex[currentIndex] = 0;
        }
        else
        {
            currentColorIndex[currentIndex] += 1;
        }
        square.color = validColors[currentColorIndex[currentIndex]];
    }

    private void handleMovement(){
      //handle key presses and shift the position array approapriately
      if(Input.GetKeyDown(KeyCode.A) && pos[1] == 1){
          pos[1] = 0;
      } else if (Input.GetKeyDown(KeyCode.D) && pos[1] == 0) {
          pos[1] = 1;
      } else if (Input.GetKeyDown(KeyCode.W) && pos[0] == 1) {
          pos[0] = 0;
      } else if (Input.GetKeyDown(KeyCode.S) && pos[0] == 0) {
          pos[0] = 1;
      }

      //clunky but handles picking what the currently highlighted square is

        if(pos[0] == 0){
          if(pos[1] == 0){
            current = squares[0];
            currentIndex = 0;
            SpriteRenderer highlight = highlights[0].GetComponent<SpriteRenderer>();
            highlight.enabled = true;
          } else {
            current = squares[1];
            currentIndex = 1;
            SpriteRenderer highlight = highlights[1].GetComponent<SpriteRenderer>();
            highlight.enabled = true;
          }
        } else {
          if(pos[1] == 0){
            current = squares[2];
            currentIndex = 2;
            SpriteRenderer highlight = highlights[2].GetComponent<SpriteRenderer>();
            highlight.enabled = true;
          } else {
            current = squares[3];
            currentIndex = 3;
            SpriteRenderer highlight = highlights[3].GetComponent<SpriteRenderer>();
            highlight.enabled = true;
          }
        }
    }

    private void checkWin(){
      bool check = true;
      for(int i = 0; i < 4; i++){
        if(correctCombo[i] != currentColorIndex[i]){
          check = false;
        }
      }
      if(check == true){
        won = true;
        MinigameStatic.setKitchenUnlock();
        SceneManager.LoadScene("Fixed");
        //StartCoroutine(transitionOut());
      }
    }

    private IEnumerator transitionOut()
    {
        //SpriteRenderer spriteRenderer = correct.GetComponent<SpriteRenderer>();
        float blinkDuration = 2f;
        float blinkSpeed = 0.4f;
        for (float t = 0; t < blinkDuration; t += blinkSpeed)
        {
           //spriteRenderer.enabled = !spriteRenderer.enabled; // Toggle visibility

           yield return new WaitForSeconds(blinkSpeed);
        }
        // Transition to another scene
        SceneManager.LoadScene("Fixed");
    }
}
