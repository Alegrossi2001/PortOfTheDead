using System;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] enemySpawnPoints = new Transform[1];
    [SerializeField] private GameObject enemyCapsule;
    private bool enemyCooldown;
    // Start is called before the first frame update
    void Awake()
    {
        enemyCooldown = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCooldown == true)
        {
            StartCoroutine(spawnEnemy());
            
        }
        
    }

    private IEnumerator spawnEnemy()
    {
        
        int randomIndex = UnityEngine.Random.Range(0, enemySpawnPoints.Length);
        Instantiate(enemyCapsule, enemySpawnPoints[randomIndex].position, Quaternion.identity);
        enemyCooldown = false;
        yield return new WaitForSeconds(4f);
        enemyCooldown = true;
    }
}
