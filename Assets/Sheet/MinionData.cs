using UnityEngine;

[CreateAssetMenu(fileName = "Minion Data", menuName = "Scriptable Object/Minion Data", order = int.MaxValue)]
public class MinionData : ScriptableObject
{
    // ###############################################
    //             NAME : KimJaeMin                      
    //             MAIL : woals1566@gmail.com         
    // ###############################################
    [SerializeField]
    private string _minionName;
    public string MinionName { get => _minionName; }
    [SerializeField]
    private int _hp;
    public int Hp { get => _hp; }
    [SerializeField]
    private int _damage;
    public int Damage { get => _damage; }
    [SerializeField]
    private float _attackRange;
    public float AttackRange { get => _attackRange; }
    [SerializeField]
    private float _moveSpeed;
    public float MoveSpeed { get => _moveSpeed; }




}


