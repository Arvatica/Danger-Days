using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup2 : MonoBehaviour
{
    public List<TabControl2> tabButtons;

    public Sprite Idle;
    public Sprite Hover;
    public Sprite Selected;
    public TabControl2 selectedTab;
    public List<GameObject> swapObjects;

    public void Subscribe(TabControl2 button)
    {
        if (tabButtons == null)
        {
            tabButtons = new List<TabControl2>();
        }

        tabButtons.Add(button);

    }


    public void OnTabEnter(TabControl2 button)
    {
        ResetTabs();
        if (selectedTab == null || button != selectedTab)
        {
            button.BG.sprite = Hover;
            button.text.color = new Color32(255, 59, 59, 255);
        }
    }
    public void OnTabExit(TabControl2 button)
    {
        ResetTabs();
    }
    public void OnTabSelected(TabControl2 button)
    {
        selectedTab = button;
        ResetTabs();
        button.BG.sprite = Selected;
        button.text.color = new Color32(255, 255, 6, 255);
        int index = button.transform.GetSiblingIndex();
        for (int i = 0; i < swapObjects.Count; i++)
        {
            if (i == index)
            {
                swapObjects[i].SetActive(true);
            }
            else
            {
                swapObjects[i].SetActive(false);
            }
        }
    }

    public void ResetTabs()
    {
        foreach (TabControl2 button in tabButtons)
        {
            if (selectedTab != null && button == selectedTab) { continue; }
            button.BG.sprite = Idle;
            button.text.color = new Color32(255, 59, 59, 255);
        }

    }
}


