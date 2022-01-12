using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerCollectible : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        HeroController controller = other.GetComponent<HeroController>();

        if (controller != null)
        {
            if (controller.flowers < controller.maxFlowers)
            {
                controller.ChangeFlowers(1);
                Destroy(gameObject);             
            }
        }
    }
}
