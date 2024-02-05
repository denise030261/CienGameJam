using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Backgrounds;
    public SpriteRenderer SpriteRenderer;
    public Camera Camera;
    private Background _next;
    public bool start=false;
    void Start()
    {
        Camera = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!start) return;
        if (_next==null)
        {
            start = false;
            _next=Instantiate(gameObject, Backgrounds.transform).GetComponent<Background>();
            start = true;
            _next.transform.position=Vector2.right*SpriteRenderer.bounds.size.x;
        }

        if (Camera.transform.position.x-transform.position.x>=SpriteRenderer.bounds.size.x)
        {
            _next.start = true;
            Destroy(gameObject);
        }
    }
}
