using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    private float inputHorizontal;
    //because its public we have access to it in the unity editor
    public float horizontalMoveSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Hello from player controller");

        // I can only get this component because the rigidbody 2d is attached to 
        // this script is also attached to the player
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Looping game loop");
        movePlayerLateral();
        jump();
    }

    private void movePlayerLateral()
    {
        // if A/D <-/-> are pressed move the player left or right
        //"Horizontal" is defined in the input section of the project settings
        // the line below will return 
        //0-no btn pressed
        //1-right arrow or d pressed
        //2-left arrow or a pressed
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        rb.linearVelocity = new Vector2(horizontalMoveSpeed * inputHorizontal, rb.linearVelocity.y);

    }

    private void jump()
    {

    }
}
