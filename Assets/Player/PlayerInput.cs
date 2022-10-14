using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // ###############################################
    //             NAME : KimJaeMin                      
    //             MAIL : woals1566@gmail.com         
    // ###############################################

    public float moveX { get; private set; }
    public float moveZ { get; private set; }

    private float HP = 10f;

    private float monsterDamage = 1f;

    public bool QskillOn = false;
    

    MeshRenderer _meshRenderer;
    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");
        //Die();
        qSkill();
    }


    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.CompareTag("PistonEnemy"))
    //     {
    //        _meshRenderer.material.color = Color.red;
    //        Debug.Log("그만때려"); 
    //        HP -= monsterDamage;
    //        StartCoroutine(changecolor());
    //    }
    //}

    void Die()
    {
        if(HP <= 0f)
        {
            Debug.Log("나죽음");
            Destroy(gameObject);   
        }
    }

  void stopcoru()
    {
        StopAllCoroutines();
        
    }

    IEnumerator changecolor()
    {
        if(_meshRenderer.material.color == Color.red)
        {
            yield return new WaitForSeconds(.5f);
            _meshRenderer.material.color = Color.white;
            Invoke("stopcoru",1f);   
        
        }
        yield return null;
    }

    void qSkill()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            QskillOn = true;
            Debug.Log("키입력이 되나요?");
        }
    }
}
