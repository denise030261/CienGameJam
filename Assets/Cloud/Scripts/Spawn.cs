using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] projectiles; // 발사체

    [SerializeField]
    private float spawnSpeed=1f; // 스폰 속도

    [SerializeField]
    private float spawnXMax; // 스폰 X 최대 반경

    [SerializeField]
    private float spawnXMin; // 스폰 X 최소 반경

    [SerializeField]
    private float spawnYMax; // 스폰 Y 최대 반경

    [SerializeField]
    private float spawnYMin;// 스폰 Y 최소 반경


    void Start()
    {
        InvokeRepeating("SpawnWind", 1f, spawnSpeed); // 소환
    }

    void SpawnWind()
    {
        float spawnX = Random.Range(spawnXMin, spawnXMax);
        float spawnY = Random.Range(spawnYMin, spawnYMax);


        Vector2 spawnTransform = new Vector2(this.transform.position.x + spawnX,
            this.transform.position.y - spawnY);

        Instantiate(projectiles[0],spawnTransform, Quaternion.identity);
    }
}
