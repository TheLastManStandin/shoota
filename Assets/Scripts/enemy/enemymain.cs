using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymain : MonoBehaviour
{
    public float health_points = 100;

    public void take_damage(float amount)
    {
        health_points -= amount;

        if (health_points <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
