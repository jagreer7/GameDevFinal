using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NumLock : MonoBehaviour
{
    [SerializeField] private GameObject[] highlights;
    private TextMeshProUGUI current;
    private int currentIndex = 0;
    private bool won = false;
    private int[] correctCombo = { 3, 8, 1, 4 };
    private int[] currentSquareIndex = { 0, 1, 2, 3 };
    private int pos = 0;
    [SerializeField]
    private TextMeshProUGUI[] texts;

    void Start()
    {
      current = texts[0];
      for (int i = 0; i < texts.Length; i++)
      {
          texts[i].text = currentSquareIndex[i].ToString();
          SpriteRenderer highlight = highlights[i].GetComponent<SpriteRenderer>();
          highlight.enabled = false;
      }
    }

    void Update()
    {
      if(won == false){
        //Clear Highlights
        for(int i = 0; i < 4; i++){
          SpriteRenderer highlight = highlights[i].GetComponent<SpriteRenderer>();
          highlight.enabled = false;
        }

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
        if (currentSquareIndex[currentIndex] == 9)
        {
            currentSquareIndex[currentIndex] = 0;
        }
        else
        {
            currentSquareIndex[currentIndex] += 1;
        }
        UpdateCombinationText();
    }

    private void UpdateCombinationText()
     {
         texts[0].text = currentSquareIndex[0].ToString();
         texts[1].text = currentSquareIndex[1].ToString();
         texts[2].text = currentSquareIndex[2].ToString();
         texts[3].text = currentSquareIndex[3].ToString();
     }

    private void handleMovement(){
      //handle key presses and shift the position array approapriately
      if(Input.GetKeyDown(KeyCode.A) && pos != 0){
          pos -= 1;
      } else if (Input.GetKeyDown(KeyCode.D) && pos != 3) {
          pos += 1;
      }

      if(pos == 0){
        current = texts[0];
        currentIndex = 0;
        SpriteRenderer highlight = highlights[0].GetComponent<SpriteRenderer>();
        highlight.enabled = true;
      } else if(pos == 1){
        current = texts[1];
        currentIndex = 1;
        SpriteRenderer highlight = highlights[1].GetComponent<SpriteRenderer>();
        highlight.enabled = true;
      } else if(pos == 2){
        current = texts[2];
        currentIndex = 2;
        SpriteRenderer highlight = highlights[2].GetComponent<SpriteRenderer>();
        highlight.enabled = true;
      } else if(pos == 3){
        current = texts[3];
        currentIndex = 3;
        SpriteRenderer highlight = highlights[3].GetComponent<SpriteRenderer>();
        highlight.enabled = true;
      }
    }

    private void checkWin(){
      bool check = true;
      for(int i = 0; i < 4; i++){
        if(correctCombo[i] != currentSquareIndex[i]){
          check = false;
        }
      }
      if(check == true){
        won = true;
        MinigameStatic.setLaserUnlock();
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
