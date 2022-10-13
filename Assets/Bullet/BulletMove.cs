using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    // ###############################################
    //             NAME : KimJaeMin                      
    //             MAIL : woals1566@gmail.com         
    // ###############################################
   
    
    public Transform tg { get;  set; }

    new Rigidbody rigidbody;
    public float turn;
    public float ballVelocity;
    // Update is called once per frame
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // À¯µµÅº
        
            rigidbody.velocity = transform.forward * ballVelocity;
            var ballTargetRotation = Quaternion.LookRotation(tg.position + new Vector3(0, 0.8f) - transform.position);
            rigidbody.MoveRotation(Quaternion.RotateTowards(transform.rotation, ballTargetRotation, turn));
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("MonsterEnemy"))
        {
            Destroy(gameObject);
        }
    }
}
