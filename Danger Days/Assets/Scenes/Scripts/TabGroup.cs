using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<TabControl> tabButtons;

    public Sprite Idle;
    public Sprite Hover;
    public Sprite Selected;
    public TabControl selectedTab;

    public void Subscribe(TabControl button)
    {
        if (tabButtons == null)
        {
            tabButtons = new List<TabControl>();
        }

        tabButtons.Add(button);

    }


    public void OnTabEnter(TabControl button)
    {
        ResetTabs();
        if (selectedTab == null || button != selectedTab)
        {
            button.BG.sprite = Hover;
            button.text.color = new Color32(255, 173, 3, 255);
        }
    }
    public void OnTabExit(TabControl button)
    {
        ResetTabs();
    }
    public void OnTabSelected(TabControl button)
    {
        selectedTab = button;
        ResetTabs();
        button.BG.sprite = Selected;
        button.text.color = new Color32(54, 227, 182, 255);
    }

    public void ResetTabs()
    {
        foreach (TabControl button in tabButtons)
        {
            if (selectedTab != null && button == selectedTab) { continue; }
            button.BG.sprite = Idle;
            button.text.color = new Color32(255, 173, 3, 255);
        }

    }
}


