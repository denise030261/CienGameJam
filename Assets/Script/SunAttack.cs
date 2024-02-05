using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class SunAttack : MonoBehaviour
{
    bool isbeam = false;
    void Awake()
    {
        GetComponent<SpriteRenderer>().enabled=false;
        GetComponent<BoxCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle , Vector3.forward);
        transform.rotation = rotation;

        if(Input.GetMouseButton(0))
        {
            isbeam = true;
            GetComponent<SpriteRenderer>().enabled = isbeam;
            GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            isbeam = false;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "wind" && isbeam == true)
        {
            other.gameObject.SetActive(false);
        }
        
    }
}
