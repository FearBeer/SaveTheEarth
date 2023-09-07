using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 10;
    [SerializeField] private Button nextLevelButton;
    [SerializeField] private Button tryAgainButton;
    private EnemySpawner spawner;
    private Rigidbody2D rigidBody;
    private float horizontalInput;
    private float canFire = 0f;
    public float playerHealth = 3;
    public int earthHealth = 1;
    public float rechargeTime = 2.0f;
    public bool isGameActive;

    public int destroyedEneemies = 0;

    public GameObject projectilePrefab;
    void Start()
    {
        isGameActive = true;
        rigidBody = GetComponent<Rigidbody2D>();
        spawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
    }

    void Update()
    {
        if (playerHealth <= 0 || earthHealth <= 0)
        {
            GameOver();
        }
        else if (isGameActive && destroyedEneemies == spawner.enemyCount)
        {
            nextLevelButton.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGameActive && Time.time > canFire)
        {
            FireProjectile();
        }
    }

    void FixedUpdate()
    {
        Movement();

    }
    private void Movement()
    {
        if (isGameActive)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            rigidBody.velocity = Vector2.zero;
            Vector2 movement = new Vector2(horizontalInput, 0);
            rigidBody.AddForce(movement * playerSpeed);
        }
        else
        {
            rigidBody.AddForce(new Vector2(0, 0));
        }
    }

    private void FireProjectile()
    {
        canFire = Time.time + rechargeTime;
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
    }

    public void GameOver()
    {
        isGameActive = false;
        tryAgainButton.gameObject.SetActive(true);
    }
}
