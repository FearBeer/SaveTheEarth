using System.Collections;
using UnityEngine;

public class EnemyBehavouir : MonoBehaviour
{
    [SerializeField] private float enemySpeed = 100;
    [SerializeField] private float timer = 2;
    [SerializeField] private int damage = 1;
    [SerializeField] private int limitRangeSpeed = 2;
    [SerializeField] private GameObject destroyParticle;

    private Rigidbody2D rigidBody;
    private PlayerController playerController;
    private MoneyBank moneyBank;
    //private SoundsPlay sounds;
    private DataManger dataManger;
    private float timeToChangeSpeed;
    
    public int enemyCost = 10;
    public int enemyHealth = 1;

    void Start()
    {
        //sounds = GameObject.Find("Sounds").GetComponent<SoundsPlay>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        dataManger = GameObject.Find("DataManager").GetComponent<DataManger>();
        moneyBank = GameObject.Find("MoneyBank").GetComponent<MoneyBank>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();
    }

    IEnumerator TimerRoutine(float rate)
    {
        enemySpeed = -(enemySpeed / rate) * Time.deltaTime;
        if (enemySpeed >= -limitRangeSpeed)
        {
            enemySpeed = -limitRangeSpeed;
        }

        while (timeToChangeSpeed > 0) {
            yield return new WaitForSeconds(0);
            timeToChangeSpeed -= Time.deltaTime;
            if(timeToChangeSpeed <= 0)
            {
                enemySpeed = -enemySpeed;
                if (enemySpeed <= limitRangeSpeed)
                {
                    enemySpeed = limitRangeSpeed;
                }
            }
        }


    }
    void Movement()
    {
        rigidBody.AddForce(Vector2.down * enemySpeed, ForceMode2D.Force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioSystem.instance.PlaySound(AudioSystem.instance.playersSounds[0], 0.5f);
            //sounds.ColissionStationSound();
            timeToChangeSpeed = timer;
            StartCoroutine(TimerRoutine(2));
            playerController.TakePlayerDamage(damage);
        }

        if (collision.gameObject.tag == "Enemy" && gameObject.tag == "Enemy")
        {
            timeToChangeSpeed = timer;
            StartCoroutine(TimerRoutine(3));
        }

        if (gameObject.tag == "Enemy" && collision.gameObject.tag == "Earth")
        {
            playerController.TakeEarthDamage(damage);
            AudioSystem.instance.PlaySound(AudioSystem.instance.playersSounds[1], 0.5f);
            //sounds.EarthCrashSound();
            playerController.destroyedEneemies++;
            Destroy(gameObject);
        }

        if (gameObject.tag == "Enemy" && collision.gameObject.tag == "Space")
        {
            playerController.destroyedEneemies++;
            Destroy(gameObject);
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerProjectile")
        {
            Destroy(collision.gameObject);
            enemyHealth -= DataManger.Instance.playerInfo.projectileDamage;
            if (enemyHealth < 1)
            {
                AudioSystem.instance.PlaySound(AudioSystem.instance.playersSounds[2], 0.5f);
                //sounds.DestroyEnemySound();
                moneyBank.ChangeMoneyValue(Mathf.CeilToInt(enemyCost * DataManger.Instance.moneyRate));
                dataManger.Save();
                Instantiate(destroyParticle, transform.position, Quaternion.identity);
                Destroy(gameObject);
                playerController.destroyedEneemies++;
            }
        }

        if (collision.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
            playerController.destroyedEneemies++;
        }
    }

}
