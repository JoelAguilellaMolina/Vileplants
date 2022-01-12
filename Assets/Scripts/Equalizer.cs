using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equalizer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        HeroController controller = other.GetComponent<HeroController>();

        if (controller != null)
        {
            if (controller.flowers < controller.maxFlowers)
            {
                controller.ChangeFlowers(0);
                Destroy(gameObject);
            }
        }
    }
}
