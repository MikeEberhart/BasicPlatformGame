using NUnit.Framework.Internal;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UIElements;

public class LaserGlasses : MonoBehaviour
{
    string test;
    public GameObject laserBeam;
    public GameObject muzzle;
    public GameObject player;

    private GameObject beamToSpawn;
    //private float fireRate;
    private float time;
    public float delay;
    //private float damage;
    private bool isWearingGlasses;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isWearingGlasses = false;
    }

    // Update is called once per frame
    void Update()
    {
        shootGlasses();
        time += Time.deltaTime;
        if (time >= delay)
        {
            //used with KeyDown in the shootGlasses function
            //shootGlasses();
            //reset time so the delay is set for the next object to spawn
            time = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isWearingGlasses = true;
            Debug.Log("OnTriggerPlayer");
        }
    }
    private void shootGlasses()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && isWearingGlasses)
        {
            Debug.Log("Shooting Glasses");
            //beamToSpawn.transform.parent = this.gameObject.transform;
            beamToSpawn = Instantiate(laserBeam);
            beamToSpawn.transform.position = new Vector2(muzzle.transform.position.x, muzzle.transform.position.y);
        }
    }



}
