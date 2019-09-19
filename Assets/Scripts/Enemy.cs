using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float moveSpeed = 3;
    private SpriteRenderer sr;
    public Sprite[] TankSprite;//up,right,down,left
    public GameObject bulletPrefab;
    private Vector3 bulletEulerAngles;
    private float timeVal;
    public GameObject explosionPrefab;
    private float timeValChangeDirection=4;
    private float v;
    private float h;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (timeVal >= 2f)
        {
            Attack();
        }
        else
        {
            timeVal += Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        Move();

    }
    //tankAttack
    private void Attack()
    {
        
       

            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.eulerAngles + bulletEulerAngles));
            timeVal = 0;
        
    }
    //tankMove
    private void Move()
    {
        if (timeValChangeDirection >= 4)
        {
            int num = Random.Range(0, 8);
            if (num > 5)
            {
                v = -1;
                h = 0;
            }
            else if (num == 0)
            {
                v = 1;
                h = 0;
            }
            else if (num > 0 && num <= 2)
            {
                h = -1;
                v = 0;
            }
            else if (num > 2 && num <= 4)
            {
                h = 1;
                h = 0;
            }

            timeValChangeDirection = 0;
        }

        else
        {
            timeValChangeDirection += Time.fixedDeltaTime;
        }
        
        transform.Translate(Vector3.up * v * moveSpeed * Time.fixedDeltaTime);
        if (v > 0)
        {
            sr.sprite = TankSprite[0];
            bulletEulerAngles = new Vector3(0, 0, 0);
        }
        else if (v < 0)
        {
            sr.sprite = TankSprite[2];
            bulletEulerAngles = new Vector3(0, 0, -180);
        }
        if (v != 0)
        {
            return;
        }
        transform.Translate(Vector3.right * h * moveSpeed * Time.fixedDeltaTime);
        if (h < 0)
        {
            sr.sprite = TankSprite[3];
            bulletEulerAngles = new Vector3(0, 0, 90);
        }
        else if (h > 0)
        {
            sr.sprite = TankSprite[1];
            bulletEulerAngles = new Vector3(0, 0, -90);
        }

    }
    private void Die()
    {
        
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
