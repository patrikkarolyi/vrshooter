using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 direction = new Vector3(0,0,2);
    
    void Update()
    {
        transform.position += Time.deltaTime * direction;
    }
}
