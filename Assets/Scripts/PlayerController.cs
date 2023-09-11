using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float playerSpeed;
    [SerializeField] private Button nextLevelButton;
    [SerializeField] private Button tryAgainButton;
    private EnemySpawner spawner;
    private Rigidbody2D rigidBody;
    private float horizontalInput;
    public float timeToFire = 0f;
    public float playerHealth;
    public int earthHealth;
    private float reloadTime;
    public bool isGameActive;

    public int destroyedEneemies = 0;

    public GameObject projectilePrefab;
    void Start()
    {
        isGameActive = true;
        playerHealth = DataManger.Instance.playerHealth;
        earthHealth = DataManger.Instance.earthHealth;
        reloadTime = DataManger.Instance.reloadTime;
        playerSpeed = DataManger.Instance.playerSpeed;
        rigidBody = GetComponent<Rigidbody2D>();
        spawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
    }
    void Update()
    {
        Movement();
        if (playerHealth <= 0 || earthHealth <= 0)
        {
            GameOver();
        }
        else if (isGameActive && destroyedEneemies == spawner.enemyCount)
        {
            nextLevelButton.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGameActive && timeToFire == 0)
        {
            timeToFire = reloadTime;
            FireProjectile();
            StartCoroutine(TimerRoutine());
        }

    }

    IEnumerator TimerRoutine()
    {
        while(timeToFire > 0)
        {
            yield return new WaitForSeconds(0);
            timeToFire -= Time.deltaTime;
            if (timeToFire < 0)
            {
                timeToFire = 0;
            }
        }
    }
    private void Movement()
    {
        if (isGameActive)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            Vector2 movement = new Vector2(horizontalInput, 0);
            rigidBody.velocity = movement * playerSpeed;
        }
        else
        {
            rigidBody.velocity = Vector2.zero;
        }
    }

    private void FireProjectile()
    {
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
    }

    public void GameOver()
    {
        isGameActive = false;
        tryAgainButton.gameObject.SetActive(true);
    }
}
