using Unity.VisualScripting;
using UnityEngine;
using System;

public class BallMovement : MonoBehaviour
{
    public Vector3 position=new Vector3(0,0,0);
    public float speed = 0.5f;
    private float modifierX=1f;
    private float modifierY = 1f;
    public event Action<int> GoalScored;//event which pushes an int when triggered
    public bool isAllowedToMove=true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Serve();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAllowedToMove)
        {
            MoveBall();
        }
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("WallY"))
        {
            modifierY *= -1; 
        }
        if (other.gameObject.CompareTag("Paddle"))
        {
            modifierX *= -1;
        }
        if(other.gameObject.CompareTag("P1Wall"))
        {
            GoalScored?.Invoke(2); 
        }
        if (other.gameObject.CompareTag("P2Wall"))
        {
            GoalScored?.Invoke(1);
        }
    }
    public void Serve()
    {
        
        modifierX = UnityEngine.Random.Range(0, 2);
        if (modifierX == 0) { modifierX = -1; }
        else { modifierX = 1; }
        modifierY = UnityEngine.Random.Range(0, 2);
        if (modifierY == 0) { modifierY = -1; }
        else { modifierY = 1; }
    }
    public void MoveBall()
    {
        position = transform.position;
        transform.position = position + new Vector3(speed * Time.deltaTime * modifierX, speed * Time.deltaTime * modifierY, 0);
    }


}
