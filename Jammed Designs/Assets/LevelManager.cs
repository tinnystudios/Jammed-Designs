using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : SingletonMonoBehaviour<LevelManager>
{
    public Level CurrentLevel;

    public int Level
    {
        get
        {
            return _currentLevelIndex + 1;
        }
    }

    protected override void Awake()
    {
        base.Awake();

        GetComponentsInChildren(_levels);
    }

    public void RetryLevel()
    {
        GameManager.Instance.Restart();
    }

    public void NextLevel()
    {
        GameManager.Instance.Restart();
    }

    public void IncreaseLevel()
    {
        _currentLevelIndex++;

        if (_currentLevelIndex >= _levels.Count - 1)
        {
            AllLevelsCleared();
            _currentLevelIndex = _levels.Count - 1;
        }

        CurrentLevel = _levels[_currentLevelIndex];
    }

    public void AllLevelsCleared()
    {
        //Get Game Manager to player some completion thing and thank the player!
    }

    public bool IsLevelSuccess(Vector2 coldWarm, Vector2 rusticModern, Vector2 retroFuturistic)
    {
        var currentLevelRequirement = CurrentLevel.LevelRequirement;

        var coldSuccess = ValidateSingleScore(currentLevelRequirement.Cold, coldWarm,ValueRange.Cold);
        var warmSuccess = ValidateSingleScore(currentLevelRequirement.Warm, coldWarm, ValueRange.Warm);
        var RusticSuccess = ValidateSingleScore(currentLevelRequirement.Rustic, rusticModern, ValueRange.Rustic);
        var ModernSuccess = ValidateSingleScore(currentLevelRequirement.Modern, rusticModern, ValueRange.Modern);
        var RetroSuccess = ValidateSingleScore(currentLevelRequirement.Retro, retroFuturistic, ValueRange.Retro);
        var FuturisticSuccess = ValidateSingleScore(currentLevelRequirement.Futuristic, retroFuturistic, ValueRange.Futuristic);

        bool success = coldSuccess && warmSuccess && RusticSuccess && ModernSuccess && RetroSuccess && FuturisticSuccess;

        return success;
    }

    public bool ValidateSingleScore(float expectedValue, Vector2 value, ValueRange curCheck)
    {
        bool retVal = false;
        switch (curCheck)
        {
            case ValueRange.Warm:
                if(value.x>=expectedValue)
                {
                    print(value.x + "  " + expectedValue);
                    retVal = true;
                }
                break;
            case ValueRange.Cold:
                if (value.y>= expectedValue)
                {
                    print(value.y + "  " + expectedValue);
                    retVal = true;
                }
                break;
            case ValueRange.Rustic:
                if (value.y>= expectedValue)
                {
                    print(value.y + "  " + expectedValue);
                    retVal = true;
                }
                break;
            case ValueRange.Modern:
                if (value.x>= expectedValue)
                {
                    print(value.x + "  " + expectedValue);
                    retVal = true;
                }
                break;
            case ValueRange.Retro:
                if (value.y>= expectedValue)
                {
                    print(value.y + "  " + expectedValue);
                    retVal = true;
                }
                break;
            case ValueRange.Futuristic:
                if (value.x >= expectedValue)
                {
                    print(value.x + "  " + expectedValue);
                    retVal = true;
                }
                break;
            default:
                break;
        }
        return retVal;
        /*
        if(value >= expectedValue)
        {
            return true;
        }
        else
        {
            return false;
        }
        */
    }

    [System.Serializable]
    public enum ValueRange
    {
        Warm,
        Cold,
        Rustic,
        Modern,
        Retro,
        Futuristic,
    }


    private List<Level> _levels = new List<Level>();
    private int _currentLevelIndex = 0;
}