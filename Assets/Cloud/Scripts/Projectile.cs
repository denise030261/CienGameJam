using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float temperature;
    public int maxHP=4;
    public int currentHP;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float damageDelay = 0.5f;

    [SerializeField]
    private int sunDamage = 1; // 이만큼 데미지 받음

    [SerializeField]
    private int attackDamage = 1; // 나그네에게 온도를 내림

    private void Awake()
    {
        Init();
    }

    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - Time.deltaTime * speed);
    
        if(currentHP==0)
        {
            Debug.Log("파괴");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            // 나그네의 온도를 깎는 코드
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.name=="SunBeam")
        {
            Debug.Log("데미지를 주겠습니다");
            InvokeRepeating("Damage", damageDelay, damageDelay);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "SunBeam")
        {
            Debug.Log("데미지를 취소");
            CancelInvoke("Damage");
        }
    }

    void Damage()
    {
        currentHP -= sunDamage;
    }

    void Init()
    {
        currentHP = maxHP;
    }


}
