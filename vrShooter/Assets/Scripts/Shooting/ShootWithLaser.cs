using Valve.VR;
using UnityEngine;
using UnityEngine.Experimental.VFX;

public class ShootWithLaser : MonoBehaviour
{
    public float damage = 30f;
    public float range = 100f;
    public float be = 0.5f; //sizeOfBloodEffect
    public Transform firePointFront;
    public Transform firePointBack;
    public GameObject impactEffect;
    public GameObject fireEffect;


    public SteamVR_Input_Sources handType;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (SteamVR_Input.GetStateDown("InteractUI", handType))
        {
            rayShoot();
        }
    }

    void rayShoot()
    {
        Vector3 direction = Vector3.Normalize(firePointFront.position - firePointBack.position);
        GameObject fire = Instantiate(fireEffect, firePointFront.transform.position, Quaternion.identity);
        Destroy(fire, 2f);

        FindObjectOfType<AudioManager>().Play("ShootVoiceEffect");

        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit))
        {
            Debug.Log(hit.transform.name);

            EnemyScript es = hit.transform.GetComponentInParent<EnemyScript>();
            if (es != null)
            {
                es.Ragdoll(true, hit.transform, direction);
                ShowImpactEffect(direction, hit);
            }


        }
    }

    void ShowImpactEffect(Vector3 direction, RaycastHit hit)
    {
        GameObject impact = Instantiate(impactEffect, hit.point, Quaternion.identity);
        VisualEffect impactVFX = impact.GetComponent<VisualEffect>();

        Vector3 max = new Vector3(direction.x + be, direction.y + be, direction.z + be);
        Vector3 min = new Vector3(direction.x - be, direction.y - be, direction.z - be);

        impactVFX.SetVector3("directionMax", -max);
        impactVFX.SetVector3("directionMin", -min);

        Destroy(impact, 2f);
    }


}
