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
    private SunManager sun; // ������ �ӵ�

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

    /// <summary>
    /// /////////////////////////////////////
    /// </summary>

    [SerializeField]
    private int hpUp = 1; // �ö� ü��

    [SerializeField]
    private int temperatureDown = 10; // ������ �µ�

    [SerializeField]
    private float speedUp = 1; // �ö� ���ǵ�



    private void Start()
    {
        if (GameManager.Instance.stage >= 2)
        {
            temperature -= temperatureDown;
        }
        if(GameManager.Instance.stage>=3)
        {
            maxHP += hpUp;
        }
        if(GameManager.Instance.stage>=4)
        {
            if(speedX==0)
                speedY += speedUp;
            else if(speedY==0)
                speedX += speedUp;
        }

        Init();

        if (transform.position.x<0)
        {
            speedX *= -1;
        }
    }

    

    void Update()
    {
        transform.position = new Vector2(transform.position.x-speedX*Time.deltaTime, transform.position.y - Time.deltaTime * speedY);

        if (currentHP<=0)
        {
            Destroy(gameObject);
        }

        if(sun.powerUp)
        {
            sunDamage = 3;
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
            if(sun.powerUp)
            {
                sunDamage = 3;
            }
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
        sun = GameObject.Find("Sun").GetComponent<SunManager>();
        if(!sun)
        {
            Debug.Log("ã�� �� �����ϴ�");
        }
    }


}
