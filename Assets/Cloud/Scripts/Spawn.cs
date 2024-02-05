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
    private float spawnMinSpeed = 1f; // ���� �ݺ� �ӵ�

    [SerializeField]
    private float spawnMaxSpeed = 1f; // ���� �ݺ� �ӵ�

    [SerializeField]
    private float spawnXMax; // ���� X �ִ� �ݰ�

    [SerializeField]
    private float spawnXMin; // ���� X �ּ� �ݰ�

    [SerializeField]
    private float spawnYMax; // ���� Y �ִ� �ݰ�

    [SerializeField]
    private float spawnYMin; // ���� Y �ּ� �ݰ�

    void Start()
    {
        randomSpeed();
    }

    void SpawnObject()
    {
        float spawnX = Random.Range(spawnXMin, spawnXMax);
        float spawnY = Random.Range(spawnYMin, spawnYMax);

        Vector2 spawnTransform = new Vector2(this.transform.position.x + spawnX,
            this.transform.position.y+spawnY);

        int num = Random.Range(0, projectiles.Length);
        Instantiate(projectiles[num],spawnTransform, Quaternion.identity);

        randomSpeed();
    }

    void randomSpeed()
    {
        spawnSpeed = Random.Range(spawnMinSpeed, spawnMaxSpeed);
        Invoke("SpawnObject", spawnSpeed);
    }
}
