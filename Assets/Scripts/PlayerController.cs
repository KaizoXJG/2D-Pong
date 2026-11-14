using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed =5f;
    public  InputAction moveAction;
    public float playerInput;
    public float yRange = 3.75f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        playerInput = moveAction.ReadValue<float>();
        transform.Translate(Vector2.up * speed * Time.deltaTime * playerInput);
        if (transform.position.y > yRange)
        {
            transform.position=new Vector2(transform.position.x, yRange);
        }
        if (transform.position.y < -yRange)
        {
            transform.position = new Vector2(transform.position.x, -yRange);
        }

    }
}
