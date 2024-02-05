using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class SunAttack : MonoBehaviour
{
    bool isbeam = false;
    public float cooldownTime = 2.0f;
    private bool canUse = true;

    void Start()
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

        if(Input.GetMouseButton(0) && canUse)
        {
            isbeam = true;
            GetComponent<SpriteRenderer>().enabled = isbeam;
            GetComponent<BoxCollider2D>().enabled = true;

            StartCoroutine(DelayCoroutine());
        }
        else
        {
            isbeam = false;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(ButtonCoolDownCoroutine());
    }
    IEnumerator ButtonCoolDownCoroutine()
    {
        canUse = false;
        yield return new WaitForSeconds(cooldownTime);
        canUse = true;
    }

    
}
