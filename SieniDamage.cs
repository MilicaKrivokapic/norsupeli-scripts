using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SieniDamage : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController >();

        if (controller != null)
        {
            controller.ChangeHealth(-1);
            Destroy(gameObject);
        }
    }

}
