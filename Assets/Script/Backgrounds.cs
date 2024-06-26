using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgrounds : MonoBehaviour
{
    private bool _move = true;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnGameEnded.AddListener(()=>
        {
            _move = false;
        });
        
        GameManager.Instance.OnGameStart.AddListener((() => _move=true));
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_move)
            transform.position+=Vector3.left*Time.deltaTime;
    }
}
