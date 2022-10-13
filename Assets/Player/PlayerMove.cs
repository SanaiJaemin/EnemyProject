using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // ###############################################
    //             NAME : KimJaeMin                      
    //             MAIL : woals1566@gmail.com         
    // ###############################################

    PlayerInput _input;
    Vector3 moveVec; 
    
    void Start()
    {
    _input = GetComponent<PlayerInput>();    
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

   public void move()
    {
        moveVec = new Vector3(_input.moveX,0, _input.moveZ).normalized;
        transform.position += moveVec * 5f * Time.deltaTime;
        //if (moveVec != Vector3.zero)
        //{
        //    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(moveVec.normalized), 5);
        //}


    }
}
