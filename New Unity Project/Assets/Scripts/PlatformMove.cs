using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{

    [Header ("Floats")]
    public float moveSpeed;
    public float patrolTime;

    [Header ("Patrol Bools")]
    public bool xPatrol;
    public bool yPatrol;
    public bool zPatrol;
    public bool movePlayer;

    [Header ("Refs")]
    public Vector3 direction;
    CharacterController playerController;


    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindWithTag("Player").GetComponent<CharacterController>();
        StartCoroutine(xRoutine());
        StartCoroutine(yRoutine());
        StartCoroutine(zRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction*Time.deltaTime*moveSpeed);

        if(movePlayer)
        {
            playerController.Move(direction*Time.deltaTime*moveSpeed);
        }

    }

    IEnumerator xRoutine()
    {
        while(xPatrol)
        {
            direction = Vector3.left;
            yield return new WaitForSeconds(patrolTime);
            direction = Vector3.right;
            yield return new WaitForSeconds(patrolTime);
        }
    }

    IEnumerator yRoutine()
    {
        while(yPatrol)
        {
            direction = Vector3.up;
            yield return new WaitForSeconds(patrolTime);
            direction = Vector3.down;
            yield return new WaitForSeconds(patrolTime);
        }
    }

    IEnumerator zRoutine()
    {
        while(zPatrol)
        {
            direction = Vector3.forward;
            yield return new WaitForSeconds(patrolTime);
            direction = Vector3.back;
            yield return new WaitForSeconds(patrolTime);
        }
    }
}