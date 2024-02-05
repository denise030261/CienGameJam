using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    private bool isFog=false;

    [SerializeField]
    private bool isRow = false;

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

        if (GameManager.Instance.stage >= 1 && !isRow)
        {
            Debug.Log("1���� ����");
            Instantiate(projectiles[0], spawnTransform, Quaternion.identity);
        }
        else if(GameManager.Instance.stage>=2 && isRow)
        {
            Debug.Log("2���� ����");
            Instantiate(projectiles[1], spawnTransform, Quaternion.identity);
        }
        
        if (GameManager.Instance.stage == 3 && !isFog)
        {
            Debug.Log("3���� ����");
            Instantiate(projectiles[2], spawnTransform, Quaternion.identity);
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
