using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : SingletonMonoBehaviour<LevelManager>
{
    public Level CurrentLevel;

    public bool IsLevelSuccess(float coldWarm, float rusticModern, float retroFuturistic)
    {
        var currentLevelRequirement = CurrentLevel.LevelRequirement;

        var coldSuccess = ValidateSingleScore(currentLevelRequirement.Cold, coldWarm);
        var warmSuccess = ValidateSingleScore(currentLevelRequirement.Warm, coldWarm);
        var RusticSuccess = ValidateSingleScore(currentLevelRequirement.Rustic, rusticModern);
        var ModernSuccess = ValidateSingleScore(currentLevelRequirement.Modern, rusticModern);
        var RetroSuccess = ValidateSingleScore(currentLevelRequirement.Retro, retroFuturistic);
        var FuturisticSuccess = ValidateSingleScore(currentLevelRequirement.Futuristic, retroFuturistic);

        bool success = coldSuccess && warmSuccess && RusticSuccess && ModernSuccess && RetroSuccess && FuturisticSuccess;

        return success;
    }

    public bool ValidateSingleScore(float expectedValue, float value)
    {
        if (value <= -1) value = -1;
        if (value >= 1) value = 1;

        bool isNegativeValue = expectedValue < 0;

        float good = 0.2F;
        float bad = 0.5F;

        //0 in this case means it doesn't expect anything (later just have a list of expected values but ceeebs atm. 4AM...
        if (expectedValue != 0)
        {
            //-1        +1  = 0                             1 - 1 = 0
            var diff = isNegativeValue ? expectedValue + value : expectedValue - value;

            if (diff <= good)
            {
                //Great!
                //2 Stars
                return true;
            }else if (diff > good && diff <= bad)
            {
                //Bad D:
                //1 Star
                return true;
            }
            else
            {
                //Failed!
                return false;
            }
        }
        else
        {
            return true;
        }
    }
}

/*
ScoreManager.Instance.MakeSlider((int)(warm_cold.x - warm_cold.y), "Cold -- Warm");
        ScoreManager.Instance.MakeSlider((int)(modern_rustic.x - modern_rustic.y), "Rustic -- Modern");
        ScoreManager.Instance.MakeSlider((int)(futuristic_retro.x - futuristic_retro.y), "Retro -- Futuristic");
        */