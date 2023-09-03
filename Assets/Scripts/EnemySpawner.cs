using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private float spawPositionLeft = -78;
    private float spawPositionRight = 46;
    [SerializeField] private float spawnInterval = 1;
    public int enemyCount = 20;

    private PlayerController playerController;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        StartCoroutine(SpawnEnemyCourutine());        
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnEnemyCourutine()
    {
        int countToWin = enemyCount;
        while(countToWin > 0 && playerController.isGameActive)
        {
            yield return new WaitForSeconds(spawnInterval);
            countToWin--;
            RandomEnemySpawn();
        }
    }

    private void RandomEnemySpawn()
    {
        int index = Random.Range(0, enemyPrefabs.Length);
        Vector2 spawnPosition = new Vector2(Random.Range(spawPositionLeft, spawPositionRight), 7);
        Instantiate(enemyPrefabs[index], spawnPosition, enemyPrefabs[index].transform.rotation);
    }
}
