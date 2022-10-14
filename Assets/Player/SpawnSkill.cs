using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class SpawnSkill : MonoBehaviour
{
    // ###############################################
    //             NAME : KimJaeMin                      
    //             MAIL : woals1566@gmail.com         
    // ###############################################
    [SerializeField]
    PlayerInput _playerInput;
    [SerializeField]
    GameObject _Prefab;
    float SkillCoolTime = 2f;
    float elaspedTime;
    bool skillTIme = false;
    [SerializeField]
    private Transform _firstTarget;
    // Update is called once per frame
    void Update()
    {


        if (_playerInput.QskillOn) // Å°ÀÔ·Â
        {
            elaspedTime += Time.deltaTime;
            if (!skillTIme)
            {
                skillTIme = true;
                GameObject Monster = Instantiate(_Prefab, transform.position, transform.rotation);
                Monster.AddComponent<NavMeshAgent>();
                Monster.AddComponent<EnemySatatus>()._target = _firstTarget;
                
            }
            if (elaspedTime >= SkillCoolTime)
            {
                skillTIme = false;
                _playerInput.QskillOn = false;
                elaspedTime = 0f;

            }

        }
    }


}
