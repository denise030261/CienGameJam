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
    public UnityEvent OnTimeEnded;
    public int sweat;
    public man man;

    [Serializable]
    public class Clothes
    {
        public Sprite clothes;
        public int health;
    }
    [Serializable]
    public class Stage
    {
        public List<Clothes> clothesList;
        public int manHp=100;
    };

    public List<Stage> stages;
    public static GameManager Instance;
    public int stage;

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

    private void Update()
    {
        foreach (var clothes in stages[0].clothesList)
        {
            if (clothes.health<=man.Hp)
            {
                man.GetComponent<SpriteRenderer>().sprite = clothes.clothes;
                break;
            }
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
