using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float temperature;

    [SerializeField]
    private float speed;

    private GameObject playerObject;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerTransform = playerObject.transform.position;

        if (playerObject != null)
        {
            // ���� ��ġ���� Player�� ��ġ�� �ε巴�� �̵�
            transform.position = Vector3.Slerp(transform.position, playerTransform, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("����");
            Destroy(this);
        }
    }
}
