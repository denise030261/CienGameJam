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
            // 현재 위치에서 Player의 위치로 부드럽게 이동
            transform.position = Vector3.Slerp(transform.position, playerTransform, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("감지");
            Destroy(this);
        }
    }
}
