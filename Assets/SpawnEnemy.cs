using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]private GameObject enemy;
    public EnemyM enemyM;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(enemyM.spawnTrue == true)
        {
            Instantiate(enemy);
        }
    }
}
