using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EndController : MonoBehaviour
{ 

	// Use this for initialization
	void Start ()
    {
        GameManager.Instance.Ended += End;
	}

    private void End()
    {
        List<ItemTag> itemTags = new List<ItemTag>();
        itemTags = FindObjectsOfType<ItemTag>().ToList();

        ObjectiveManager.Progress CurState = new ObjectiveManager.Progress();

        //get item count
        foreach (var item in itemTags)
        {
            if (!CurState.ItemsPresent.ContainsKey((int)item.TypeOfItem))
            {
                CurState.ItemsPresent.Add((int)item.TypeOfItem, 1);
            }
            else
            {
                int curCount = CurState.ItemsPresent[(int)item.TypeOfItem];
                CurState.ItemsPresent[(int)item.TypeOfItem] = curCount + 1;
            }
        }

        //get senses
        foreach (var item in itemTags)
        {
            if (!CurState.SenseValue.ContainsKey((int)item.SensationEvoked))
            {
                CurState.SenseValue.Add((int)item.SensationEvoked, item.SenseValue);
            }
            else
            {
                int curSenseVal = CurState.SenseValue[(int)item.SensationEvoked];
                CurState.SenseValue[(int)item.SensationEvoked] = curSenseVal + item.SenseValue;
            }
        }


        //+ is warm, - is cold
        Vector2 warm_cold = new Vector2();
        Vector2 modern_rustic = new Vector2();
        Vector2 futuristic_retro= new Vector2();

        foreach (var item in CurState.SenseValue)
        {
            switch ((ItemTag.Tag)item.Key)
            {
                case ItemTag.Tag.Warm:
                    warm_cold.x = item.Value;
                    break;
                case ItemTag.Tag.Cold:
                    warm_cold.y = item.Value;
                    break;
                case ItemTag.Tag.Modern:
                    modern_rustic.x = item.Value;
                    break;
                case ItemTag.Tag.Rustic:
                    modern_rustic.y = item.Value;
                    break;
                case ItemTag.Tag.Retro:
                    futuristic_retro.y = item.Value;
                    break;
                case ItemTag.Tag.Futuristic:
                    futuristic_retro.x = item.Value;
                    break;
                default:
                    break;
            }
        }

        ScoreManager.Instance.MakeSlider((int)(warm_cold.x - warm_cold.y), "Cold -- Warm");
        ScoreManager.Instance.MakeSlider((int)(modern_rustic.x - modern_rustic.y), "Rustic -- Modern");
        ScoreManager.Instance.MakeSlider((int)(futuristic_retro.x - futuristic_retro.y), "Retro -- Futuristic");

        var coldWarm = (warm_cold.x - warm_cold.y);
        var modernRustic =(modern_rustic.x - modern_rustic.y);
        var futuristicRetro = (futuristic_retro.x - futuristic_retro.y);

        var success = LevelManager.Instance.IsLevelSuccess(warm_cold, modern_rustic, futuristic_retro);
        Debug.Log("Success : " + success);

        ScoreManager.Instance.UpdateNextMenuBoard(success);

        if(success)
            LevelManager.Instance.IncreaseLevel();

        foreach (var item in ObjectiveManager.Instance.curObjective.ItemsToHave)
        {
            int curCount = 0, numWanted = 0;
            string text = "";
            numWanted = item.Needed;
            text = item.type.ToString();

            foreach (var dict in CurState.ItemsPresent)
            {
                if((ItemTag.ItemType)dict.Key == item.type)
                {
                    curCount = dict.Value;
                    break;
                }
            }

            ScoreManager.Instance.MakeCheckbox(curCount, numWanted, text);
        }
        
    }
}
