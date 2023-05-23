using UnityEngine.Audio;
using UnityEngine;

public class WoodenDoor : MonoBehaviour
{
    [SerializeField] int ObjHealth;
    [SerializeField] Animator DoorAnim;

    public void woodDamage()
    {
        ObjHealth -= 1;

        if (ObjHealth == 0)
        {
            DoorAnim.SetBool("Open", true);
        }
    }
}
