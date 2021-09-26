using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameSession : MonoBehaviour
{

    [SerializeField] Text NyawaText;
    [SerializeField] Text ScoreText;
    [SerializeField] int startNyawa;
    [SerializeField] GameObject Menu;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject gameWinText;
    [SerializeField] GameObject restartBtn;


    public bool isEscapeToExit;

    int currentNyawa;
    int currentScore;  

    public Text LevelText;
    Text txPemenang;
  
    private void Awake()
    {
        int instanceCount = FindObjectsOfType<GameSession>().Length;
        if(instanceCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        currentNyawa = startNyawa;
        
     
        Menu.GetComponent<Button>().onClick.AddListener(KembaliKeMenu);
        restartBtn.GetComponent<Button>().onClick.AddListener(Reset);
        

    }

    // Update is called once per frame
    void Update()
    {
        CountBalls();

        CountBlocks();

        UpdateUI();

        if (Input.GetKeyUp (KeyCode.Escape)) {
            if (isEscapeToExit) {
                Application.Quit ();
            } else {
                KembaliKeMenu ();
            } 
        }
        UnPause();
    }

    
    public void IncreaseScore(int value)
    {
        currentScore += value;
    }
    
    public void DecreaseNyawa()
    {
        currentNyawa--;

        if (currentNyawa <= 0)
        {
            GameOver();
        }
    }

    private void CountBalls()
    {
        var balls = GameObject.FindGameObjectsWithTag("Ball");
        if (balls.Length <= 0)
        {
            DecreaseNyawa();
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().ResetBall();
            Pause();
            return;
        }
        UnPause();
    }

    private void CountBlocks()
    {
        var blocks = GameObject.FindGameObjectsWithTag("Block");

        if (blocks.Length == 0)
        {
            //Saat Menang
            Debug.Log("Menang!");

            Win();

        }
    }

    private void UpdateUI()
    {
        NyawaText.text = currentNyawa.ToString();
        ScoreText.text = currentScore.ToString();
    }

    
    
 
    
    
    private void Win()
    {
        var numberOfScenes = SceneManager.sceneCountInBuildSettings;
        var currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentBuildIndex == numberOfScenes-1)
        {
            
            //Declare Winner!!
            gameOverScreen.SetActive(true);
            Menu.SetActive(true);
            restartBtn.SetActive(true);
            gameWinText.SetActive(true);

            
            Pause();
         
        }
        else
        {
            //Load New Scene
            SceneManager.LoadScene(currentBuildIndex +1);
        }
          
    }

    private void GameOver()
    {
        gameOverScreen.SetActive(true);
        gameOverText.SetActive(true);
        restartBtn.SetActive(true);
        Menu.SetActive(true);

        Pause();
    }

    

    private void Reset()
    {
        ResetScore();

        ResetScreen();

        ResetLevel1();
    }

    private void ResetScreen()
    {
        gameOverScreen.SetActive(false);
        gameOverText.SetActive(false);
        gameWinText.SetActive(false);
        restartBtn.SetActive(false);
        Menu.SetActive(false);
        

        UnPause();
    }

    private void ResetScore()
    {
        currentNyawa = startNyawa;
        currentScore = 0;
    }
    private void ResetLevel1()
    {
        SceneManager.LoadScene(1);
    }

    public void KembaliKeMenu ()
    {
        Destroy(gameObject);
        SceneManager.LoadScene ("MainMenu");
        ResetScore();

        ResetScreen();

        Pause();
    }

    private void Pause()
    {
        Time.timeScale = 0f;
    }
    
    private void UnPause()
    {
        Time.timeScale = 1f;
    }
}
