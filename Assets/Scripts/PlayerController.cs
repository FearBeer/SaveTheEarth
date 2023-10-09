using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Button nextLevelButton;
    [SerializeField] private Button tryAgainButton;
    [SerializeField] private Button shopButton;
    private Button rateButton;
    private EnemySpawner spawner;
    private Rigidbody2D rigidBody;
    private float playerSpeed;
    private float horizontalInput;
    private float reloadTime;
    private float timeToFire = 0f;
    private int playerHealth;
    private int earthHealth;

    public int destroyedEneemies = 0;

    public UnityEvent<int> OnPlayerHealthChange;
    public UnityEvent<int> OnEarthHealthChange;
    public UnityEvent<float> OnTimeToFireCnahge;

    public GameObject projectilePrefab;
   
    void Start()
    {
        DataManger.Instance.playerInfo.isGameActive = true;
        AudioSystem.instance.ChangeTrack(AudioSystem.instance.sounds[2]);               
        AudioSystem.instance.PlayMusic();
       
        playerHealth = DataManger.Instance.playerInfo.playerHealth;
        earthHealth = DataManger.Instance.playerInfo.earthHealth;
        reloadTime = DataManger.Instance.playerInfo.reloadTime;
        playerSpeed = DataManger.Instance.playerInfo.playerSpeed;
        rigidBody = GetComponent<Rigidbody2D>();
        spawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
        rateButton = GameObject.Find("Rate").GetComponent<Button>();
        if (rateButton != null)
        {
            rateButton.gameObject.SetActive(false);
        }
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

        if (DataManger.Instance.playerInfo.isGameActive && destroyedEneemies == spawner.enemyCount)
        {
            nextLevelButton.gameObject.SetActive(true);
            shopButton.gameObject.SetActive(true);
        }
        if(DataManger.Instance.playerInfo.isGameActive) { 
            if (Input.GetKeyDown(KeyCode.Space) && timeToFire == 0)
            {
                timeToFire = reloadTime;
                FireProjectile();
                StartCoroutine(TimerRoutine());
            }
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
        if (DataManger.Instance.playerInfo.isGameActive)
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
        AudioSystem.instance.PlaySound(AudioSystem.instance.playersSounds[3], 0.5f);
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
        DataManger.Instance.playerInfo.isGameActive = false;
        if(rateButton != null)
        {
            rateButton.gameObject.SetActive(true);
        }
        tryAgainButton.gameObject.SetActive(true);
        shopButton.gameObject.SetActive(true);
    }
}
