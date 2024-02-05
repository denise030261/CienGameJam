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

    void Update()
    {
        Vector2 playerTransform = playerObject.transform.position;

        if (playerObject != null)
        {
            transform.position = Vector3.Slerp(transform.position, playerTransform, speed * Time.deltaTime);
        } // Player ¿Ãµø
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
