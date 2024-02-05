using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeMove : MonoBehaviour
{
    private Vector2 targetTransform;
    // Start is called before the first frame update
    void Start()
    {
        targetTransform = new Vector2(8, this.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetTransform = 
            new Vector2(this.transform.position.x + Time.deltaTime * 1, this.transform.position.y);
        this.transform.position = targetTransform;
    }
}
