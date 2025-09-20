using UnityEngine;

public class DoubleJumpCollectable : MonoBehaviour
{
    string test;
    //public GameObject laserBeam;
    //public GameObject muzzle;
    private float fireRate;
    private float damage;
    private bool isWearingGlasses;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //Destroy(this.gameObject);
        }
    }
    private void Update()
    {
        
    }
    public string getTestString()
    {
        test = "Hello from pink collectable";
        return test;
    }
    private void shootGlasses()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            
        }
    }
}
