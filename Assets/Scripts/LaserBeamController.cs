using UnityEngine;

public class LaserBeamController : MonoBehaviour
{
    public float playerDirection;
    public float speed;
    Rigidbody2D rb;
    private bool facingRight;
    private float time;
    public float delay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //playerDirection = Input.GetAxisRaw("Horizontal");
        GameObject player = GameObject.Find("Player");
        if(player.transform.rotation.y == 0)
        {
            facingRight = true;
            //fireRight();
        }
        else if(player.transform.rotation.y == -180)
        {
            facingRight = false;
            //fireLeft();
        }
        directionOfFire();
    }

    // Update is called once per frame
    void Update()
    {
        //directionOfFire();
        time += Time.deltaTime;
        if (time >= delay)
        {
            Destroy(this.gameObject);
            //reset time so the delay is set for the next object to spawn
            time = 0f;
        }
    }
    private void directionOfFire()
    {
        if (facingRight)
        {
            fireRight();
        }
        else if(!facingRight)
        {
            fireLeft();
        }
    }
    private void fireLeft()
    {
        rb.linearVelocity = new Vector2(speed * -1, 0);
    }
    private void fireRight()
    {
        rb.linearVelocity = new Vector2(speed * 1, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("InvisibleBoundry"))
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.CompareTag("Collectable"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
