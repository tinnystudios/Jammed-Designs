using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EndController : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        GameManager.Instance.Ended += End;
	}

    private void End()
    {
        List<ItemTag> itemTags = new List<ItemTag>();
        itemTags = FindObjectsOfType<ItemTag>().ToList();
       
        int Warm = 0,
        Cold = 0,
        Modern = 0,
        Rustic = 0,
        Retro = 0,
        Futuristic = 0,
        Neutral = 0;

        foreach (var item in itemTags)
        {
            switch (item.SensationEvoked)
            {
                case ItemTag.Tag.Warm:
                    Warm += item.SenseValue;
                    break;
                case ItemTag.Tag.Cold:
                    Cold += item.SenseValue;
                    break;
                case ItemTag.Tag.Modern:
                    Modern += item.SenseValue;
                    break;
                case ItemTag.Tag.Rustic:
                    Rustic += item.SenseValue;
                    break;
                case ItemTag.Tag.Retro:
                    Retro += item.SenseValue;
                    break;
                case ItemTag.Tag.Futuristic:
                    Futuristic += item.SenseValue;
                    break;
                case ItemTag.Tag.Neutral:
                    Neutral += item.SenseValue;
                    break;
                default:
                    break;
            }
        }

        print(string.Format("Warm: {0} Cold: {1} Modern: {2} Rustic: {3} Retro: {4} Futuristic: {5} Neutral: {6}", Warm, Cold, Modern, Rustic, Retro, Futuristic, Neutral));
    }
}
