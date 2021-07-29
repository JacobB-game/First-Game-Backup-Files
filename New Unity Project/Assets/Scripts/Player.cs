using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement Variables")]

    public int speed;

    [Header("Jump Variables")]

    public float yForce;
    public float yGravity;
    public float maxGravity;
    public float jumpSpeed;
    public bool isJumping;

    [Header("Refrences")]

    CharacterController myController;
    public DoubleJump doubleJump;
    public GameObject playerModel;
    public Animator animator;

    void Start()
    {
        // this is a comment in the start function
        myController = GetComponent<CharacterController>();
        //doubleJump = GetComponent<DoubleJump>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            MoveForward();
        }

        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }

        if (Input.GetKey(KeyCode.S))
        {
            MoveBack();
        }

        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(!isJumping)
            {    
                Jump();
            }
            else
            {
                if(doubleJump.available)
                {
                    doubleJump.available = false;
                    Jump();
                    animator.SetTrigger("DoubleJump");
                }
            }
        }

        if(myController.isGrounded && yForce < 0)
        {
            isJumping = false;
            doubleJump.available = true;
            animator.SetBool("IsJumping", false);
        }

        //if the player is not on the ground, make yForce = ygravity
        if (!myController.isGrounded)
        {
            yForce = Mathf.Max(maxGravity, yForce + (yGravity * Time.deltaTime));
        }

        myController.Move(Vector3.up * yForce * Time.deltaTime);

        if(isIdle())
        {
            animator.SetFloat("Speed", 0);
        }
    }    

    bool isIdle()
    {
        if
        (!Input.GetKey(KeyCode.W) && 
        !Input.GetKey(KeyCode.A) &&
        !Input.GetKey(KeyCode.S) &&
        !Input.GetKey(KeyCode.D) &&
        !isJumping
        )
        {
            return true;
        }
        return false;
    }

    void MoveForward()
    {       
        myController.Move(Vector3.forward * Time.deltaTime * speed);
        playerModel.transform.eulerAngles = new Vector3(0,0,0);
        animator.SetFloat("Speed", 1);
    }

    void MoveLeft()
    {       
        myController.Move(Vector3.left * Time.deltaTime * speed);
        playerModel.transform.eulerAngles = new Vector3(0,270,0);
        animator.SetFloat("Speed", 1);
    }

    void MoveBack()
    {       
        myController.Move(Vector3.back * Time.deltaTime * speed);
        playerModel.transform.eulerAngles = new Vector3(0,180,0);
        animator.SetFloat("Speed", 1);
    }

    void MoveRight()
    {       
        myController.Move(Vector3.right * Time.deltaTime * speed);
        playerModel.transform.eulerAngles = new Vector3(0,90,0);
        animator.SetFloat("Speed", 1);
    }

    void Jump()
    {
        isJumping = true;
        yForce = jumpSpeed;
        animator.SetBool("IsJumping", true);
    }
}