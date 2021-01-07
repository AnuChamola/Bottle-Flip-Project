using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D myRigidBody;
    public float speed;
    private float direction;
    private bool isGrounded;
    public Transform feetPos;
    public float checkradius;
    public float jumpForce;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    public LayerMask whatIsGround;
    private Animator myAnimator;
 

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
      

    }

    // Update is called once per frame
 
    
void Update()

 {
       
     isGrounded = Physics2D.OverlapCircle(feetPos.position, checkradius, whatIsGround);

       

     if(isGrounded && Input.GetKeyDown(KeyCode.Space))
     {
         isJumping = true;
         jumpTimeCounter = jumpTime;
            
         myRigidBody.velocity = Vector2.up * jumpForce;
           

        }

     if(Input.GetKey(KeyCode.Space) && isJumping)
     {
         if(jumpTimeCounter > 0)
         {
                // myRigidBody.velocity = Vector2.up * jumpForce;
                
                //transform.Rotate(0, 0, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
                Vector3 pos = Vector3.right;
                
                myRigidBody.AddForceAtPosition(pos * speed, transform.position);

                myAnimator.SetBool("rotate", true);

            }
         else
         {
             isJumping = false;
             myAnimator.SetBool("rotate", false);

            }

     }

     if(Input.GetKeyUp(KeyCode.Space))
     {
         isJumping = false;
            myAnimator.SetBool("rotate", false);

        }


 }
     


}
