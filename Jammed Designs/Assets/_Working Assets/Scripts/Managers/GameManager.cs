using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game Time:")]
    public float MaxTime;
    [Range(0,1f)]
    public float NormalizedTime;

    [Header("Game State:")]
    public SystemState CurrentState;
    [Space]
    public LayerMask clickableLayer;

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

    public float TimeRemaining
    {
        get
        {
            return MaxTime - elapsedTime;
        }
    }

    private void Awake()
    {
        Instance = this;
        MaxTime = LevelManager.Instance.CurrentLevel.TimeLimit;
    }

    // Use this for initialization
    void Start ()
    {
        Started += StartGame;

        GetComponent<ObjectiveManager>().Init();

        LoadScene("UI Overlay", LoadSceneMode.Additive);
        LoadScene("AudioManager", LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update ()
    {
		if(Input.anyKeyDown && !_started)
        {
            SetupGame();
        }

        if (Input.GetKey(KeyCode.T))
            Time.timeScale = 10;
        else
            Time.timeScale = 1;
    }

    public void SetupGame()
    {
        _started = true;
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
        elapsedTime = 0;

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

    private void LoadScene(string sceneToLoad, LoadSceneMode mode)
    {
        StartCoroutine(LoadSceneAsync(sceneToLoad, mode));
    }

    private IEnumerator LoadSceneAsync(string sceneToLoad, LoadSceneMode mode)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad,mode);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    private float elapsedTime;
    private bool _started = false;
}
