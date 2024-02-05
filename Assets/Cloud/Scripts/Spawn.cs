using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] projectiles; // �߻�ü

    [SerializeField]
    private float spawnSpeed=1f; // ���� �ݺ� �ӵ�

    [SerializeField]
    private float spawnStartSpeed = 1f; // ���� �ӵ�

    [SerializeField]
    private float spawnXMax; // ���� X �ִ� �ݰ�

    [SerializeField]
    private float spawnXMin; // ���� X �ּ� �ݰ�

    void Start()
    {
        InvokeRepeating("SpawnWind", spawnStartSpeed, spawnSpeed); // ��ȯ
    }

    void SpawnWind()
    {
        float spawnX = Random.Range(spawnXMin, spawnXMax);

        Vector2 spawnTransform = new Vector2(this.transform.position.x + spawnX,
            this.transform.position.y);

        Instantiate(projectiles[0],spawnTransform, Quaternion.identity);
    }
}
