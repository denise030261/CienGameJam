using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int maxHP=4;
    public int currentHP;

    private man Man; // 나그네
    private bool noDamage; // 데미지 여부

    [SerializeField]
    private float speed; // 내리는 속도

    [SerializeField]
    private float damageDelay = 0.5f; // 받는 딜레이

    [SerializeField]
    private int sunDamage = 1; // 이만큼 데미지 받음

    [SerializeField]
    private int temperature = 1; // 나그네에게 온도를 내림

    private void Start()
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
            Man.Hp -= temperature;
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "SunBeam" && !noDamage)
        {
            currentHP -= sunDamage;
            Debug.Log(currentHP);
            noDamage = true;
            Invoke("Damage", damageDelay);
        }
    }

    void Damage()
    {
        noDamage = false;
    }

    void Init()
    {
        currentHP = maxHP;
        noDamage = false;
        Man = GameObject.Find("Man").GetComponent<man>();
    }


}
