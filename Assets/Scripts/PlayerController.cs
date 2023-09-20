using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Button nextLevelButton;
    [SerializeField] private Button tryAgainButton;
    [SerializeField] private AudioClip fireSound;
    private EnemySpawner spawner;
    private Rigidbody2D rigidBody;
    private AudioSource audioSource;
    private float playerSpeed;
    private float horizontalInput;
    private float reloadTime;
    private float timeToFire = 0f;
    private int playerHealth;
    private int earthHealth;
    
    public bool isGameActive;
    public int destroyedEneemies = 0;

    public UnityEvent<int> OnPlayerHealthChange;
    public UnityEvent<int> OnEarthHealthChange;
    public UnityEvent<float> OnTimeToFireCnahge;

    public GameObject projectilePrefab;
    void Start()
    {
        isGameActive = true;
        playerHealth = DataManger.Instance.playerHealth;
        earthHealth = DataManger.Instance.earthHealth;
        reloadTime = DataManger.Instance.reloadTime;
        playerSpeed = DataManger.Instance.playerSpeed;
        rigidBody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        spawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
    }

    public int GetPlayerHealth()
    {
        return playerHealth;
    }

    public int GetEarthHealth()
    {
        return earthHealth;
    }

    public float GetTimeToFire()
    {
        return timeToFire;
    }

    void Update()
    {
        Movement();

        if (isGameActive && destroyedEneemies == spawner.enemyCount)
        {
            nextLevelButton.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGameActive && timeToFire == 0)
        {
            timeToFire = reloadTime;
            FireProjectile();
            audioSource.PlayOneShot(fireSound, 1.0f);
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
            OnTimeToFireCnahge.Invoke(timeToFire);
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

    public void TakePlayerDamage(int damage)
    {
        playerHealth -= damage;
        if (playerHealth <= 0)
        {
            playerHealth = 0;
            GameOver();
        }
        OnPlayerHealthChange.Invoke(playerHealth);
    }

    public void TakeEarthDamage(int damage)
    {
        earthHealth -= damage;
        if (earthHealth <= 0)
        {
            earthHealth = 0;
            GameOver();
        }
        OnEarthHealthChange.Invoke(earthHealth);
    }

    public void GameOver()
    {
        isGameActive = false;
        tryAgainButton.gameObject.SetActive(true);
    }
}
