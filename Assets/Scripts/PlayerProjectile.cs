using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] private float speed = 100;
    private Rigidbody2D projectileRb;
    private PlayerController playerController;
    private EnemyBehavouir enemy;
    // Start is called before the first frame update
    void Start()
    {
        projectileRb = GetComponent<Rigidbody2D>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void FixedUpdate()
    {
        ProjectileBehavouir();
    }

    private void ProjectileBehavouir()
    {
        projectileRb.velocity = Vector3.zero;
        projectileRb.AddForce(Vector3.up * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemy = collision.gameObject.GetComponent<EnemyBehavouir>();
            Destroy(gameObject);
            enemy.enemyHealth--;
            if (enemy.enemyHealth < 1)
            {
                DataManger.Instance.money += enemy.enemyCost;
                Destroy(collision.gameObject);
                playerController.destroyedEneemies++;
            }
        }
        if (collision.gameObject.tag == "Boundary")
        {
            Debug.Log("OUT TO SPACE");
            Destroy(gameObject);
        }
    }
}
