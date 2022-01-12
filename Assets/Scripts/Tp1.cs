using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tp1 : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Object that entered the trigger : " + other);
        HeroController controller = other.GetComponent<HeroController>();

        if (controller != null)
        {
            controller.ChangeHealth(-2);

        }
    }
}
