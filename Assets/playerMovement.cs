using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// This script moves the character controller forward
// and sideways based on the arrow keys.
// It also jumps when pressing space.
// Make sure to attach a character controller to the same game object.
// It is recommended that you make only one call to Move or SimpleMove per frame.

public class playerMovement : MonoBehaviour
{
    //CharacterController characterController;
    Rigidbody rb;
    private float speed = 15.0f;
    
    
    private float jumpSpeed = 5.0f;
    private float gravity = 20.0f;
    private Vector3 offset;
    //private Vector3 moveDirection = Vector3.zero;
    private float distToGround;
    //Animator animator;

    
    void Start()
    {
       rb = GetComponent<Rigidbody>();
       
       distToGround = GetComponent<Collider>().bounds.extents.y;
       //Animator animator = GetComponent<Animator>();
    }

    bool isGrounded(){
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
    void Update()
    {
        
        //Vector3 pos = this.transform.position;

        // if (characterController.isGrounded){
        //     if(Input.GetKey(KeyCode.UpArrow)){
        //         pos.x -= speed * Time.deltaTime;
        //     }
        // }
        

        //if (!isGrounded())
        //{
            // We are grounded, so recalculate
            // move direction directly from axes

            //moveDirection = new Vector3();//Input.GetAxis("Vertical"), 0.0f, Input.GetAxis("Horizontal"));

            
            if(Input.GetKey(KeyCode.UpArrow)){
                 //moveDirection.x--;
                 transform.eulerAngles = new Vector3(0, -90, 0);
                 rb.AddForce(-500*Time.deltaTime * speed, 0, 0);
                 //this.transform.position = pos;
                 
            }
            if(Input.GetKey(KeyCode.DownArrow)){
                // moveDirection.x++;
                 transform.eulerAngles = new Vector3(0, 90, 0);
                 rb.AddForce(500*Time.deltaTime * speed, 0, 0);
                 //this.transform.position = pos;
            }
            if(Input.GetKey(KeyCode.LeftArrow)){
                 //moveDirection.z--;
                 transform.eulerAngles = new Vector3(0, 180, 0);
                 rb.AddForce(0, 0, -500 * Time.deltaTime * speed);
                 //this.transform.position = pos;
            }
            if(Input.GetKey(KeyCode.RightArrow)){
                 //moveDirection.z++;
                 transform.eulerAngles = new Vector3(0, 0, 0);
                 //rb.velocity = new Vector3(rb.velocity.x, speed);
                 
                 rb.AddForce(0, 0, 500 * Time.deltaTime * speed);
                 //this.transform.position = pos;
            }

            //moveDirection *= speed;
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
            {
                //rb.AddForce(0, 550*Time.deltaTime, 0);
                rb.velocity = new Vector3(rb.velocity.y, jumpSpeed);
                //moveDirection.y = jumpSpeed;
            }

            // if (Input.GetKeyDown(KeyCode.C)){
            //     animator.SetBool("Crouch", true);
            // }
        //}

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        //moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        //characterController.Move(moveDirection * Time.deltaTime);
    }
}