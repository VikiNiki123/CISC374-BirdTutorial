using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;

    public int highScore;
    public Text highScoreText;


    public GameObject gameOverScreen;
    public GameObject startScreen;
    private bool isGameOver = false;
    private bool isGameStart = false;

    public AudioSource gameMusic;
    public AudioSource soundPoint;

    [ContextMenu("Increase Score")]

    void Start()
    {
        Time.timeScale = 0;
        startScreen.SetActive(true);

        //Saves the highest score & saves it!
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "" + highScore;
    }

    public void gameStart()
    {
        Time.timeScale = 1;
        startScreen.SetActive(false);
        isGameStart = true;
        //gameMusic.Play();
    }


    public void addScore(int scoreToAdd){
        if(!isGameOver && isGameStart){
            playerScore += scoreToAdd;
            scoreText.text = playerScore.ToString();
            playSound(soundPoint);
        }
        
    }

     public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        isGameOver = true;
        gameMusic.Pause();

        if (playerScore > highScore)
            {
                highScore = playerScore;
                PlayerPrefs.SetInt("HighScore", highScore);
                PlayerPrefs.Save();
            }
    }


    //Function that is use to play any Sound in the game
    public void playSound(AudioSource sound){
        if(sound != null){
            sound.Play();
        }
    }

}
