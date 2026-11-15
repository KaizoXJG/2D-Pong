using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int scoreP1;
    private int scoreP2;
    [SerializeField] TMP_Text uiP1;
    [SerializeField] TMP_Text uiP2;

    [SerializeField] BallMovement ball;//reference to the script component of ball
    [SerializeField] PlayerController player1Script;
    [SerializeField] PlayerController player2Script;

    public GameObject player1;
    public GameObject player2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ball.GoalScored += UpdateScore;//subscribing to event
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void UpdateScore(int player)
    {
        switch (player)
        {
            case 1:
                scoreP1++;
                uiP1.text = scoreP1.ToString();
                StartCoroutine(ResetBall(0));
                ResetPlayer(player1, player1Script);
                ResetPlayer(player2, player2Script);
                break;
            case 2:
                scoreP2++;
                uiP2.text = scoreP2.ToString();
                StartCoroutine(ResetBall(0));
                ResetPlayer(player1, player1Script);
                ResetPlayer(player2, player2Script);
                break;
            

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
    private void ResetPlayer(GameObject player,PlayerController playerScript)
    {
        player.transform.position = playerScript.initialPlayerPosition;
    }
    
   
}
