using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        CharacterMoving enemy = collision.gameObject.GetComponent<CharacterMoving>();
        if (enemy != null)
        {
            enemy.die();
        }

    }
}
