using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class man : MonoBehaviour
{
    public UnityEvent<int> OnManDamaged;
    private int _hp;
    public int Hp
    {
        get=>_hp;
        set
        {
            var tmp = _hp;
            _hp = math.clamp(value, 0, MaxHp);
            if(tmp!=value)
                OnManDamaged.Invoke(tmp-value);
        }
    }
    public int MaxHp;

    public ParticleSystem Sweat;
    private bool _wait = false;
    public SpriteRenderer clothes;

    public List<GameObject> ManSprites;
    // Start is called before the first frame update

    private void Awake()
    {
        OnManDamaged.AddListener(ManDamaged);
    }

    private void ManDamaged(int hp)
    {
        Debug.Log(hp);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.name=="SunBeam")
            Sweat.Play();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.name == "SunBeam")
            StartCoroutine(Damage());
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.transform.name=="SunBeam")
            Sweat.Stop();
    }

    private IEnumerator Damage()
    {
        if (_wait) yield break;
        _wait = true;
        Hp -= 10;
        yield return new WaitForSeconds(0.5f);
        
        _wait = false;
    }
}
