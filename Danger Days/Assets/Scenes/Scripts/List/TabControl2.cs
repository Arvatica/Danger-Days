using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

[RequireComponent(typeof(Image))]

public class TabControl2 : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public TabGroup2 tabGroup;
    public Image BG;
    public TMP_Text text;

    void Start()
    {
        BG = GetComponent<Image>();
        tabGroup.Subscribe(this);
        tabGroup.ResetTabs();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tabGroup.OnTabEnter(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {

        tabGroup.OnTabExit(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        tabGroup.OnTabSelected(this);
    }
}
