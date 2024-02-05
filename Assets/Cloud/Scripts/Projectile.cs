using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int maxHP=4;
    public int currentHP;

    private man Man; // ���׳�
    private bool noDamage; // ������ ����

    [SerializeField]
    private float speedY; // ������ �ӵ�

    [SerializeField]
    private float speedX; // �������� �ӵ�

    [SerializeField]
    private float damageDelay = 0.5f; // �޴� ������

    [SerializeField]
    private int sunDamage = 1; // �̸�ŭ ������ ����

    [SerializeField]
    private int temperature = 1; // ���׳׿��� �µ��� ����

    private void Start()
    {
        Init();

        if(transform.position.x<0)
        {
            speedX *= -1;
        }
    }

    void Update()
    {
        transform.position = new Vector2(transform.position.x-speedX*Time.deltaTime, transform.position.y - Time.deltaTime * speedY);

        if (currentHP==0)
        {
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
