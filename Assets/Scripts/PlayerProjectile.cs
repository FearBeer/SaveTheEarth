using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] private float speed = 100;
    private Rigidbody2D projectileRb;
    // Start is called before the first frame update
    void Start()
    {
        projectileRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ProjectileBehavouir();
    }

    private void ProjectileBehavouir()
    {
        projectileRb.velocity = Vector3.up * speed;        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }
    }
}
