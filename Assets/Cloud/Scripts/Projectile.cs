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
    private int sunDamage = 1; // �̸�ŭ ������ ����

    [SerializeField]
    private int attackDamage = 1; // ���׳׿��� �µ��� ����

    private void Awake()
    {
        Init();
    }

    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - Time.deltaTime * speed);
    
        if(currentHP==0)
        {
            Debug.Log("�ı�");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            // ���׳��� �µ��� ��� �ڵ�
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.name=="SunBeam")
        {
            Debug.Log("�������� �ְڽ��ϴ�");
            InvokeRepeating("Damage", damageDelay, damageDelay);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "SunBeam")
        {
            Debug.Log("�������� ���");
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
