using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelControl : MonoBehaviour
{
    public Vector2 normalisedMousePosition;
    public float angle;
    public int selection;

    private int previousSelected;
    public GameObject[] MenuItems;
    private WheelItems wheelItems;
    private WheelItems wheelPreviousItem;

    void Start()
    {
        wheelItems = GetComponent<WheelItems>();
        wheelPreviousItem = GetComponent<WheelItems>();
    }
    void Update()
    {

        normalisedMousePosition = new Vector2(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2);
        angle = Mathf.Atan2(normalisedMousePosition.y, normalisedMousePosition.x) * Mathf.Rad2Deg;
        angle = (angle + 315) % 360;
        selection = (int)((angle / 90));

        if (selection != previousSelected)
        {
            wheelPreviousItem = MenuItems[previousSelected].GetComponent<WheelItems>();
            wheelPreviousItem.Deselected();
            previousSelected = selection;
            wheelItems = MenuItems[selection].GetComponent<WheelItems>();
            wheelItems.Selected();
            Weapon();
        }

    }
    public void Weapon()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().WeaponActive(selection);
        Debug.Log(selection);
    }
}
