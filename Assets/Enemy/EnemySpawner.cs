using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // ###############################################
    //             NAME : KimJaeMin                      
    //             MAIL : woals1566@gmail.com         
    // ###############################################
    public enum ENUMZOMBIETYPE
    { 
        Normal,
        Shot,
        Special,
    }
    [SerializeField]
    private List<MinionData> m_MinionData;
    [SerializeField]
    GameObject EnemyPrefabs; // 근접
    [SerializeField]
    GameObject ShotEnemyPrefabs; // 원거리

    int EnemyCount = 1;
    private Vector3 SpawnPos = new Vector3(0.5996317f, 1.3333f, 35.33f);
    void Start()
    {

        for (int i = 0; i < EnemyCount; i++)

        {

            GameObject PistonEnemy = Instantiate(EnemyPrefabs, SpawnPos, transform.rotation);
            GameObject ShotEnemy = Instantiate(ShotEnemyPrefabs, new Vector3(1.5996317f, 1.5f, 35.33f), transform.rotation);

        }



    }

   
   
    
}
