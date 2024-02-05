using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    private bool isFog=false;

    [SerializeField]
    private bool isRow = false;

    [SerializeField]
    private GameObject[] projectiles; // 발사체

    [SerializeField]
    private float spawnSpeed=1f; // 스폰 반복 속도

    [SerializeField]
    private float spawnMinSpeed = 1f; // 스폰 반복 속도

    [SerializeField]
    private float spawnMaxSpeed = 1f; // 스폰 반복 속도

    [SerializeField]
    private float spawnXMax; // 스폰 X 최대 반경

    [SerializeField]
    private float spawnXMin; // 스폰 X 최소 반경

    void Start()
    {
        randomSpeed();
    }

    void SpawnObject()
    {
        float spawnX = Random.Range(spawnXMin, spawnXMax);

        Vector2 spawnTransform = new Vector2(this.transform.position.x + spawnX,
            this.transform.position.y);

        if (GameManager.Instance.stage >= 1 && !isRow)
        {
            Debug.Log("1레벨 스폰");
            Instantiate(projectiles[0], spawnTransform, Quaternion.identity);
        }

        if(GameManager.Instance.stage>=2 && isRow)
        {
            Debug.Log("2레벨 스폰");
            Instantiate(projectiles[0], spawnTransform, Quaternion.identity);
        }
        
        if (GameManager.Instance.stage == 3 && !isFog && !isRow)
        {
            Debug.Log("3레벨 스폰");
            spawnTransform = new Vector2(0, 0);
            Instantiate(projectiles[1], spawnTransform, Quaternion.identity);
            isFog = true;
        }
        

        randomSpeed();
    }

    void randomSpeed()
    {
        spawnSpeed = Random.Range(spawnMinSpeed, spawnMaxSpeed);
        Invoke("SpawnObject", spawnSpeed);
    }
}
