using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUIManager : MonoBehaviour {

    [SerializeField] private List<HouseItem> m_AllItemCategories;

    [Header("Button Vars:")]
    [SerializeField] private GameObject m_ButtonPrefab;
    [SerializeField] private Transform m_CategoryHolder;
    [SerializeField] private Transform m_ItemHolder;

    // Use this for initialization
    void Start ()
    {
        Init();
	}

    private void Init()
    {

        //spawn category buttons
        foreach(var item in m_AllItemCategories)
        {
            var go = Instantiate(m_ButtonPrefab, transform.position, Quaternion.identity);
            go.transform.SetParent(m_CategoryHolder);

            go.transform.GetChild(0).GetComponent<Image>().sprite = item.BaseIcon;
            go.GetComponent<Button>().onClick.AddListener(delegate () { SpawnItemButtons(item); });
        }
    }


    private void SpawnItemButtons(HouseItem itemList)
    {
        foreach (Transform child in m_ItemHolder.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (var item in itemList.ItemVariants)
        {
            var go = Instantiate(m_ButtonPrefab, transform.position, Quaternion.identity);
            go.transform.SetParent(m_ItemHolder);

            go.transform.GetChild(0).GetComponent<Image>().sprite = item.ItemSprite;
        }
    }
}
