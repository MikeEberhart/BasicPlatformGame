using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float movementSpeed;
    public bool horizontalMovement;
    public bool verticalMovement;

    private bool moveLeft;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveLeft = true;
    }

    // Update is called once per frame
    void Update()
    {
        movePlatform();
    }

    private void movePlatform()
    {
        // this need to be multiplied by time.deltatime so that we are moving the object
        // based off time and not framerate. We do not do this when moving the player
        if(horizontalMovement)
        {
            transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("WallMovementLeftBound"))
        {
            moveLeft = false;
        }
        else if(collision.gameObject.CompareTag("WallMovementRightBound"))
        {
            moveLeft= true;
        }
        else if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(gameObject.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}

