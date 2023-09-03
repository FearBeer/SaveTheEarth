using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] private float speed = 100;
    private Rigidbody2D projectileRb;
    private PlayerController playerController;
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
            Destroy(gameObject);
            Destroy(collision.gameObject);
            playerController.destroyedEneemies++;
            DataManger.Instance.money += 10;
        }
        if (collision.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }
    }
}
