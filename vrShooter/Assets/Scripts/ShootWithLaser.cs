using Valve.VR;
using UnityEngine;

public class ShootWithLaser : MonoBehaviour
{
    public float damage = 30f;
    public float range = 100f;
    public Transform firePointFront;
    public Transform firePointBack;
    public GameObject impactEffect;
    public GameObject fireEffect;


    public SteamVR_Input_Sources handType;

    // Update is called once per frame
    void Update()
    {
        if (SteamVR_Input.GetStateDown("InteractUI", handType))
        {
            rayShoot();
        }
    }

    void rayShoot()
    {
        Vector3 direction = firePointFront.position - firePointBack.position;

        GameObject fire = Instantiate(fireEffect, firePointFront.transform.position, Quaternion.identity);
        Destroy(fire, 2f);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit))
        {
            Debug.Log(hit.transform.name);

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * 100000);
            }

            GameObject impact = Instantiate(impactEffect, hit.point, Quaternion.identity);
            Destroy(impact, 2f);
        }
    }


}
