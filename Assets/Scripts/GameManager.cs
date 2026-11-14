using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int scoreP1;
    public int scoreP2;
    [SerializeField] TMP_Text uiP1;
    [SerializeField] TMP_Text uiP2;

    [SerializeField] BallMovement ball;//reference to the script component of ball
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ball.GoalScored += UpdateScore_ResetBall;//subscribing to event
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void UpdateScore_ResetBall(int player)
    {
        switch (player)
        {
            case 1:
                scoreP1++;
                uiP1.text = scoreP1.ToString();
                break;
            case 2:
                scoreP2++;
                uiP2.text = scoreP2.ToString();
                break;

        }
        ball.transform.position = new Vector3(0, 0, 0);//it changes the transform of the component ball(script) is attached to
        ball.Serve();//calling serve from ballmovement
        
    }
    
   
}
