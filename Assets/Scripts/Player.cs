using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float moveSpeed = 3;
    private SpriteRenderer sr;
    public Sprite[] TankSprite;//up,right,down,left
    public GameObject bulletPrefab;
    private Vector3 bulletEulerAngles;
    private float timeVal;
    private float defendedTimeVal=3f;
    public GameObject explosionPrefab;
    public GameObject defendEffectPrefab;
    private bool isDefended=true;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isDefended)
        {
            defendEffectPrefab.SetActive(true);
            defendedTimeVal -= Time.deltaTime;
            if (defendedTimeVal <= 0)
            {
                isDefended = false;
                defendEffectPrefab.SetActive(false);
            }
        }
        if (timeVal >= 0.4f)
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
        if (Input.GetKeyDown("space"))
        {

            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.eulerAngles+bulletEulerAngles));
            timeVal = 0;
        }
    }
    //tankMove
    private void Move()
    {
        float v = Input.GetAxisRaw("Vertical");
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
        float h = Input.GetAxisRaw("Horizontal");
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
        if (isDefended)
        {
            return;
        }
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
