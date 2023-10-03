using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int enemyCount = 20;

    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private float spawnInterval = 1;

    private float spawPositionLeft = -78;
    private float spawPositionRight = 46;
    private float spawnPositionTop = 3.0f;

    void Start()
    {
        StartCoroutine(SpawnEnemyCourutine());        
    }

    IEnumerator SpawnEnemyCourutine()
    {
        int enemySpawned = enemyCount;
        while(enemySpawned > 0 && DataManger.Instance.playerInfo.isGameActive)
        {
            yield return new WaitForSeconds(spawnInterval);
            enemySpawned--;
            RandomEnemySpawn();
        }
    }

    private void RandomEnemySpawn()
    {
        int index = Random.Range(0, enemyPrefabs.Length);
        Vector2 spawnPosition = new Vector2(Random.Range(spawPositionLeft, spawPositionRight), spawnPositionTop);
        Instantiate(enemyPrefabs[index], spawnPosition, enemyPrefabs[index].transform.rotation);
    }
}
