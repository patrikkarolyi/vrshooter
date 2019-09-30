using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50;

    public void takeDamage(float damage)
    {
        health -= damage;
        if (health < 1)
        {
            die();
        }
    }

    private void die()
    {
        Destroy(gameObject);
    }
}
