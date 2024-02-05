using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] projectiles; // �߻�ü

    [SerializeField]
    private float spawnSpeed=1f; // ���� �ӵ�

    [SerializeField]
    private float spawnXMax; // ���� X �ִ� �ݰ�

    [SerializeField]
    private float spawnXMin; // ���� X �ּ� �ݰ�

    [SerializeField]
    private float spawnYMax; // ���� Y �ִ� �ݰ�

    [SerializeField]
    private float spawnYMin;// ���� Y �ּ� �ݰ�


    void Start()
    {
        InvokeRepeating("SpawnWind", 1f, spawnSpeed); // ��ȯ
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
