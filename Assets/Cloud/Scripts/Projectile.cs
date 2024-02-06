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
    private SunManager sun; // 내리는 속도

    [SerializeField]
    private float speedY; // 내리는 속도

    [SerializeField]
    private float speedX; // 쓸려가는 속도

    [SerializeField]
    private float damageDelay = 0.5f; // 받는 딜레이

    [SerializeField]
    private int sunDamage = 1; // 이만큼 데미지 받음

    [SerializeField]
    private int temperature = 1; // 나그네에게 온도를 내림

    /// <summary>
    /// /////////////////////////////////////
    /// </summary>

    [SerializeField]
    private int hpUp = 1; // 올라갈 체력

    [SerializeField]
    private int temperatureDown = 10; // 내려갈 온도

    [SerializeField]
    private float speedUp = 1; // 올라갈 스피드



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
            Debug.Log("찾을 수 없습니다");
        }
    }


}
