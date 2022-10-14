using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySatatus : Enemybase
{
    // ###############################################
    //             NAME : KimJaeMin                      
    //             MAIL : woals1566@gmail.com         
    // ###############################################

    public Transform _target;
  
    private Transform _PrevTarget;
    Rigidbody _rigidbody;
    enum ESTATE
    {
        move,
        attack
    }
    ESTATE _estate;
   public bool canAttack { get; private set; }
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    float distance;

    void Awake()
    {
         
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _PrevTarget = _target;


    }

    private void Start()
    {
        StartCoroutine(StateChange());
    }

    private IEnumerator move() // ������
    {
        while (true)
        {
            _animator.SetBool("Attack",false);
            _navMeshAgent.SetDestination(_target.position);
            transform.LookAt(_target.position);
            distance = Vector3.Distance(_target.position, transform.position);
            if (distance < 1f)
            {
                _estate = ESTATE.attack;
                Debug.Log($"{_estate}");

                break;
            }
            yield return null;

        }
    }
    private IEnumerator Attack() // ����
    {
        while (true)
        {
            // ����
            _navMeshAgent.stoppingDistance = 0;
            _animator.SetBool("Attack",true);
            // �ִϸ��̼� �߰� + ���ݵ����� ������
            //yield return new WaitForSeconds(1f); //������Ÿ��
            canAttack = true;


                if (distance > 2f)
                {
                    _estate = ESTATE.move;
                    _navMeshAgent.isStopped = false;
                }                 
        yield return null;
        }
    }

    private IEnumerator StateChange()
    {     
        while (true)
        {

            switch (_estate)
            {
                case ESTATE.attack:
                    StartCoroutine(Attack());
                    StopCoroutine(move());
                    break;
                default:
                    StartCoroutine(move());
                    StopCoroutine(Attack());
                    break;

            }
        yield return null;
        }

    }

    private void OnTriggerStay(Collider other) // Ÿ�� �̴Ͼ����� ����
    {
        if (other.CompareTag("MonsterEnemy"))
        {
           
            _estate = ESTATE.attack;
            _target = other.gameObject.transform;

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MonsterEnemy"))
        {
            //_navMeshAgent.isStopped = false;
            _estate = ESTATE.move;
            _target = _PrevTarget;
        }
    }

   
}

