using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerJump>())
        {
            other.gameObject.GetComponent<PlayerJump>().resetJumpCount();
        }
    }
}
