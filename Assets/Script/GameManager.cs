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
    
    [Serializable]
    public class Stage
    {
        public List<GameObject> manSprites;
        public int manHp=100;
    };

    public List<Stage> stages;
    public static GameManager Instance;

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
                //OnTimeEnded.Invoke();
                //break;
            }
        }
    }
}
