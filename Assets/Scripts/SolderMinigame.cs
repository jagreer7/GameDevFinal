using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SolderMinigame : MonoBehaviour
{
    [SerializeField] GameObject Player;

    [SerializeField] TextMeshProUGUI Score;
    [SerializeField] TextMeshProUGUI Action;
    [SerializeField] TextMeshProUGUI SuccessFail;

    [SerializeField] GameObject SolderBlobGood;
    [SerializeField] GameObject SolderBlobBad;

    [SerializeField] int VictoryNum;

    public float finaltimer = 1f;
    public float gameFinaltimer = 1f;
    public float gameTimer = 9f;

    private int scoreInt = 0;

    private bool buttonHasBeenReleased = true;

    private void Start()
    {
        Action.text = "Hold to Start";
        Score.text = "Score: 0";
        SuccessFail.text = string.Empty;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Fixed");
        }

        if (Input.GetKeyUp(KeyCode.Space)) 
        {
            buttonHasBeenReleased = true;
        }

        //Only run if holding
        if (Input.GetKey(KeyCode.Space) && buttonHasBeenReleased == true)
        {

            gameTimer -= Time.deltaTime;

            //Condition to clear the "you failed" text
            if (gameTimer <= 8.5f)
            {
                SuccessFail.text = string.Empty;
            }
            
            //Minigame
            if (gameTimer > 6 && gameTimer <= 9)
            {
                SolderBlobBad.GetComponent<SpriteRenderer>().enabled = false; //Turn this one off 
                Action.text = "Hold...";
                SolderBlobGood.GetComponent<SpriteRenderer>().enabled = true;
                SolderBlobGood.transform.localScale = new Vector3(0.2f, 0.2f, 0f);
                SolderBlobGood.transform.position = new Vector3(0.38f, -0.24f, 0f);
            }
            else if (gameTimer > 3 && gameTimer <= 6)
            {
                Action.text = "Keep Holding...";
                SolderBlobGood.transform.localScale = new Vector3(0.5f, 0.5f, 0f);
                SolderBlobGood.transform.position = new Vector3(0.25f, -0.16f, 0f);
            }
            else if (gameTimer > 0 && gameTimer <= 3)
            {
                Action.text = "HOLD!!!";
                SolderBlobGood.transform.localScale = new Vector3(1f, 1f, 0f);
                SolderBlobGood.transform.position = new Vector3(0, 0, 0f);
            }
            else //Timer is over
            {
                Action.text = "RELEASE!";
                gameFinaltimer -= Time.deltaTime;
            }
        }

        //Checking for player release
        if (Input.GetKeyUp(KeyCode.Space) && gameTimer <= 0 && gameFinaltimer > 0)
        {
            SuccessFail.text = "You Scored!";
            scoreInt++;
            Action.text = "Hold to Start";
            Score.text = "Score: " + scoreInt.ToString();
            gameFinaltimer = finaltimer;
            gameTimer = 9f;
        }
        //Failed to hold in time
        else if (gameFinaltimer <= 0 && gameTimer <= 0)
        {
            SuccessFail.text = "You Failed";
            gameTimer = 9f;
            gameFinaltimer = finaltimer;
            Action.text = "Hold to Start";
            SolderBlobGood.GetComponent<SpriteRenderer>().enabled = false;
            SolderBlobBad.GetComponent<SpriteRenderer>().enabled = true;
            buttonHasBeenReleased = false;
        }
        //Let Go Mid Game
        else if (Input.GetKeyUp(KeyCode.Space) && gameTimer != 9)
        {
            SuccessFail.text = "You Released Too Early!";
            gameFinaltimer = finaltimer;
            gameTimer = 9f;
            Action.text = "Hold to Start";
            SolderBlobGood.GetComponent<SpriteRenderer>().enabled = false;
            SolderBlobBad.GetComponent<SpriteRenderer>().enabled = true;
        }

        //Check for score
        if (scoreInt >= VictoryNum)
        {
            SuccessFail.text = "Key Part Collected! \n Press [ESC] to exit back to the BTU";
            //Send some data about victory to game manager

            MinigameStatic.setSolderingMinigameWon(true);
            ItemsStatic.setCollected(8);
        }
    }
}
