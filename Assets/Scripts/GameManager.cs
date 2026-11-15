using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int scoreP1;
    private int scoreP2;
    [SerializeField] TMP_Text uiP1;
    [SerializeField] TMP_Text uiP2;

    [SerializeField] BallMovement ball;//reference to the script component of ball
    [SerializeField] PlayerController player1Script;
    [SerializeField] PlayerController player2Script;

    [SerializeField] GameObject gameOverPanel;
    [SerializeField] TMP_Text gameOverText;
    public int winningScore = 1;
    bool isGameOver=false;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ball.GoalScored += UpdateScore;//subscribing to event
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void UpdateScore(int player)
    {
        ResetPlayer(player1Script);
        ResetPlayer(player2Script);

        
        if (player == 1)
        {
            scoreP1++;
            uiP1.text=scoreP1.ToString();
            if(scoreP1 >= winningScore)
            {
                isGameOver=true;
                GameOver(1);
            }
            else { StartCoroutine(ResetBall(0)); }
        }
        else
        {
            scoreP2++;
            uiP2.text = scoreP2.ToString();
            if (scoreP2 == winningScore)
            {
                isGameOver = true;
                GameOver(2);
            }else { StartCoroutine(ResetBall(0)); }
        }
        
            

        
    }
    private IEnumerator ResetBall(int player)
    {
        ball.isAllowedToMove = false;
        ball.transform.position = new Vector3(0, 0, 0);//it changes the transform of the component ball(script) is attached to
        yield return new WaitForSeconds(1f);
        ball.Serve();//calling serve from ballmovement
        ball.isAllowedToMove = true;
    }
    private  void ResetPlayer(PlayerController playerScript)
    {
        playerScript.transform.position = playerScript.initialPlayerPosition;
    }
    void GameOver(int playerNo)
    {
        gameOverPanel.SetActive(true);
        ball.isAllowedToMove=false;
        gameOverText.text="Player " + playerNo.ToString() + " Wins";

    }
    public void RestartGame()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
   
}
