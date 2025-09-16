using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //https://docs.unity3d.com/ScriptReference/Physics.IgnoreCollision.html//
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {

        }
    }

}
