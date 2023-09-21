using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] private float speed = 100;
    private Rigidbody2D projectileRb;
    void Start()
    {
        projectileRb = GetComponent<Rigidbody2D>();
        switch(DataManger.Instance.projectileDamage)
        {
            case 1:
                transform.localScale *= 1;
                break;
            case 2: transform.localScale *= 1.1f; 
                break;
            case 3:
                transform.localScale *= 1.2f;
                break;
            case 4:
                transform.localScale *= 1.3f;
                break;
            case 5:
                transform.localScale *= 1.5f;
                break;
            default:
                transform.localScale *= 1;
                break;
        }
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
