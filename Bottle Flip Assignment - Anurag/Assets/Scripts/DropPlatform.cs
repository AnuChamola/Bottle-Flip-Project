using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPlatform : MonoBehaviour
{
    private Rigidbody2D myRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Invoke("Drop", 0.5f);
            Destroy(gameObject, 2f);
        }
    }

    void Drop()
    {
        myRigidBody.isKinematic = false;
    }
}
