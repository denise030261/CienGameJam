using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public UnityEvent OnGameStart;
    public UnityEvent OnGameEnded;
    public UnityEvent OnTimeEnded;
    public int sweat;
    public man man;
    public Hash128 _currentHash;
    public GameObject effect;

    [Serializable]
    public class Clothes
    {
        public Sprite clothes;
        public Sprite clothesParts;
        public int health;
    }
    [Serializable]
    public class Stage
    {
        public List<Clothes> clothesList;
        public int manHp = 100;
    };

    public List<Stage> stages;
    public static GameManager Instance;
    public int stage=0;

    public float Time;

    public float MaxTime=5;
    // Start is called before the first frame update

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        OnGameStart.AddListener(StartGame);
        
        OnGameStart.Invoke();
    }

    private void Start()
    {
        man.OnManDamaged.AddListener(ManDamaged);
        NextStage();
    }

    private void ManDamaged(int hp)
    {
        
    }

    private void NextStage()
    {
        stage++;
        man.Hp = stages[stage - 1].manHp;
    }

    private void Update()
    {
        foreach (var clothes in stages[stage-1].clothesList)
        {
            if (clothes.health<=man.Hp)
            {
                if (_currentHash != clothes.clothes.texture.imageContentsHash)
                {
                    man.GetComponent<SpriteRenderer>().sprite = clothes.clothes;
                    var tmp=Instantiate(man.clothes.gameObject, null);
                    tmp.transform.position = man.transform.position+Vector3.up;
                    tmp.GetComponent<Rigidbody2D>().AddForce(new Vector2(-300,300));
                    tmp.GetComponent<Rigidbody2D>().AddTorque(20);
                    tmp.GetComponent<SpriteRenderer>().sprite = clothes.clothesParts;
                    Instantiate(effect, man.transform).transform.position+=Vector3.up*2;
                    _currentHash = clothes.clothes.texture.imageContentsHash;
                }
                break;
            }

            
        }
        if (man.Hp <= 0)
        {
            NextStage();
        }
    }

    public void StartGame()
    {
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Time += 1;
            if (Time >= MaxTime)
            {
            }
        }
    }
}
