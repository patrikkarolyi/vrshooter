using TMPro;
using UnityEngine;
using Valve.VR;

public class ShootWithLaser : MonoBehaviour
{
    //public float damage = 30f;
    public float range = 100f;
    public int maxAmmo = 10;

    private int currentAmmo;
    //public float sizeOfBloodEffect = 0.5f;

    public Transform firePointFront;

    public Transform firePointBack;

    //public GameObject impactEffect;
    public GameObject fireEffect;
    public TextMeshProUGUI ammoText;

    private bool toShoot;

    public SteamVR_Input_Sources handType;

    private void Start()
    {
        Reload();
    }

    void Update()
    {
        if (SteamVR_Input.GetStateDown("InteractUI", handType))
        {
            toShoot = true;
        }

        if (currentAmmo < maxAmmo && Vector3.Angle(transform.up, Vector3.up) > 100)
        {
            Reload();
        }
    }

    private void FixedUpdate()
    {
        if (toShoot)
        {
            if (currentAmmo > 0)
            {
                rayShoot();
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("NoAmmoVoiceEffect");
            }

            toShoot = false;
        }
    }

    void rayShoot()
    {
        Vector3 direction = Vector3.Normalize(firePointFront.position - firePointBack.position);
        GameObject fire = Instantiate(fireEffect, firePointFront.position,
            Quaternion.LookRotation(direction) * Quaternion.Euler(0, -90, 0));
        Destroy(fire, 0.01f);

        currentAmmo--;
        ammoText.text = currentAmmo.ToString();

        FindObjectOfType<AudioManager>().Play("ShootVoiceEffect");

        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, 100f))
        {
            EnemyScript es = hit.transform.GetComponentInParent<EnemyScript>();
            if (es != null)
            {
                es.Ragdoll(true, hit.transform, direction);
                //ShowImpactEffect(direction, hit);
            }
        }
    }

    /*void ShowImpactEffect(Vector3 direction, RaycastHit hit)
    {
        GameObject impact = Instantiate(impactEffect, hit.point, Quaternion.identity);
        VisualEffect impactVFX = impact.GetComponent<VisualEffect>();

        Vector3 max = new Vector3(direction.x + sizeOfBloodEffect, direction.y + sizeOfBloodEffect, direction.z + sizeOfBloodEffect);
        Vector3 min = new Vector3(direction.x - sizeOfBloodEffect, direction.y - sizeOfBloodEffect, direction.z - sizeOfBloodEffect);

        impactVFX.SetVector3("directionMax", -max);
        impactVFX.SetVector3("directionMin", -min);

        Destroy(impact, 2f);
    }*/

    void Reload()
    {
        FindObjectOfType<AudioManager>().Play("ReloadVoiceEffect");
        currentAmmo = maxAmmo;
        ammoText.text = maxAmmo.ToString();
    }
}