using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    private Transform backgroundTransform;
    private float backgroundPosition;
    private float backgroundSize;
    // Start is called before the first frame update
    void Start()
    {
        backgroundTransform = GetComponent<Transform>();
        backgroundSize = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        backgroundPosition -= speed * Time.deltaTime;
        backgroundPosition = Mathf.Repeat(backgroundPosition, backgroundSize);
        backgroundTransform.position = new Vector3(0, backgroundPosition, 0);
    }
}
