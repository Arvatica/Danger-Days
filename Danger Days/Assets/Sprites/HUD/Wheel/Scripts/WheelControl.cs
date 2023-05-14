using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelControl : MonoBehaviour
{

    // Variables

    public Vector2 normalisedMousePosition;
    public float angle;
    public int selection;
    public Animator anim;

    private int previousSelected;
    public GameObject[] MenuItems;
    private WheelItems wheelItems;
    private WheelItems wheelPreviousItem;
    public bool selectable = false;

    // Obtencion

    void Start()
    {
        wheelItems = GetComponent<WheelItems>();
        wheelPreviousItem = GetComponent<WheelItems>();
    }

    void Update()
    {
        if (selectable)
        {
            //Ubicacion mouse

            normalisedMousePosition = new Vector2(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2);
            angle = Mathf.Atan2(normalisedMousePosition.y, normalisedMousePosition.x) * Mathf.Rad2Deg;
            angle = (angle + 315) % 360;
            selection = (int)((angle / 90));

            // Selector cartesiano -45GRADOS

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
    }

    // Solucion Bug raro

    public void canSelect()
    {
        selectable = !selectable;
    }

    // Transmisor de seleccion de arma

    public void Weapon()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().WeaponActive(selection);
    }

    // Animaciones

    public void Open()
    {
        anim.SetBool("isOpen", true);
    }
    public void Close()
    {
        anim.SetBool("isOpen", false);
    }
}
