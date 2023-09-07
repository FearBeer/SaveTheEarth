using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavouir : MonoBehaviour
{
    [SerializeField] public float enemySpeed = 1400;
    [SerializeField] private float timer = 2;
    private Rigidbody2D rigidBody;
    private PlayerController playerController;


    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(enemySpeed > 0)
        {
            Movement();
        } else
        {
            timer -= Time.deltaTime;
            if (timer == 0)
            {
                enemySpeed = -enemySpeed;
            }
        }
    }
    void Movement()
    {
        rigidBody.velocity = Vector2.zero;
        rigidBody.AddForce(Vector2.down * enemySpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enemySpeed = -enemySpeed/2;
            Movement();
            playerController.playerHealth--;
            if(playerController.playerHealth < 1)
            {
                playerController.playerHealth = 0;
            }
        }

        if (collision.gameObject.tag == "Enemy" && gameObject.tag == "Enemy")
        {
            enemySpeed = -enemySpeed/1.5f;
            Movement();
        }

        if (gameObject.tag == "Enemy" && collision.gameObject.tag == "Earth")
        {
            playerController.earthHealth--;
            if (playerController.earthHealth < 0)
            {
                playerController.earthHealth = 0;
            }
            playerController.destroyedEneemies++;
            Destroy(gameObject);
        }

        if (gameObject.tag == "Enemy" && collision.gameObject.tag == "Space")
        {
            playerController.destroyedEneemies++;
            Destroy(gameObject);
        }
    }

}
