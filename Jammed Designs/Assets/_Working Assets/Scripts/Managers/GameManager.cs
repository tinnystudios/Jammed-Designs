using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game Time:")]
    public float MaxTime;
    [Range(0,1f)]
    public float NormalizedTime;

    [Header("Game State:")]
    public SystemState CurrentState;


    [System.Serializable]
    public enum SystemState
    {
        Paused,
        SettingUp,
        Running,
        Ending,
        Finished,
    };

    public delegate void GamePaused();
    public delegate void GameSetup();
    public delegate void GameStarted();
    public delegate void GameEnded();

    public GamePaused Paused;
    public GameSetup SettingUp;
    public GameStarted Started;
    public GameEnded Ended;

    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start ()
    {
        Started += StartGame;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            SetupGame();
        }
	}

    public void SetupGame()
    {
        CurrentState = SystemState.SettingUp;

        if (SettingUp != null)
        {
            SettingUp.Invoke();
        }
    }

    public void StartGame()
    {
        CurrentState = SystemState.Running;
        StartCoroutine(CountdownRoutine());
    }

    public void PausedGame()
    {
        CurrentState = SystemState.Paused;

        if (Paused != null)
        {
            Paused.Invoke();
        }

        StartCoroutine(CountdownRoutine());
    }

    private IEnumerator CountdownRoutine()
    {
        float elapsedTime = 0;

        while (elapsedTime < MaxTime)
        {
            while (CurrentState != SystemState.Running)
            {
                yield return new WaitForEndOfFrame();
            }

            elapsedTime += Time.deltaTime;
            NormalizedTime = elapsedTime / MaxTime;
            yield return new WaitForEndOfFrame();
        }

        if (Ended != null)
        {
            Ended.Invoke();
        }
    }

    private void ResetGame()
    {
        NormalizedTime = 0;
    }
}
