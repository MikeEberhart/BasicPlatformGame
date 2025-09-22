using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    private float inputHorizontal;
    private int maxNumJumps;
    private int numJumps;
    //because its public we have access to it in the unity editor
    public float horizontalMoveSpeed;
    public float jumpForce;

    public GameObject doubleJumpHatLocation;
    public GameObject glassesSlotLocations;

    public float playerDirection;
    private bool facingRight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Debug.Log("Hello from player controller");

        // I can only get this component because the rigidbody 2d is attached to 
        // this script is also attached to the player
        rb = GetComponent<Rigidbody2D>();
        maxNumJumps = 1;
        numJumps = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Looping game loop");
        movePlayerLateral();
        jump();
    }

    PlayerController()
    {

    }
    public bool getPlayerDirection()
    {
        return facingRight;
    }
    public void settingPlayerDirection()
    { 

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
        flipPlayerSprite(inputHorizontal);
        rb.linearVelocity = new Vector2(horizontalMoveSpeed * inputHorizontal, rb.linearVelocity.y);

    }



    private void flipPlayerSprite(float inputHorizontal)
    {
        //this is how we will make the player face the direction they are moving
        if(inputHorizontal > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0); //right
            facingRight = true;
        }
        else if(inputHorizontal < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);//left
            facingRight = false;
        }
    }
    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && numJumps <= maxNumJumps)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            numJumps++;
        }
    }

    //Collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //collision will contain information about the object that the player collided with
        //Debug.Log(collision.gameObject);
        if(collision.gameObject.CompareTag("Ground"))
        {
            numJumps = 1;
        }
        else if(collision.gameObject.CompareTag("obBottom"))
        {
            //game over
            SceneManager.LoadScene("SampleScene");

        }
    }

    //Triggers
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("DoubleJump"))
        {
            //string fromPinkCollectable = collision.gameObject.GetComponent<PinkTriangleCollectable>().getTestString();
            //Debug.Log(fromPinkCollectable);
            GameObject hat = collision.gameObject;
            equipDoubleJumpHat(hat);
            maxNumJumps = 2;
        }
        else if(collision.gameObject.CompareTag("LaserGlasses"))
        {
            GameObject glasses = collision.gameObject;
            equipGlassesSlot(glasses);
        }
    }

    private void equipDoubleJumpHat(GameObject hat)
    {
        hat.transform.position = doubleJumpHatLocation.transform.position;
        hat.gameObject.transform.SetParent(this.gameObject.transform);
    }

    private void equipGlassesSlot(GameObject glasses)
    {
        GameObject parentObj = glasses.transform.parent.gameObject;
        glasses.transform.position = glassesSlotLocations.transform.position;
        glasses.gameObject.transform.SetParent(this.gameObject.transform);
        Destroy(parentObj);
    }
    
}
