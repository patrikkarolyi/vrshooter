
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    private float impactPower;
    private Rigidbody[] rbs;

    void Start()
    {
        rbs = GetComponentsInChildren<Rigidbody>();
        Ragdoll(false,transform,transform.position);
    }


    public void Ragdoll(bool enabled, Transform pointToShoot, Vector3 shootDirection)
    {
        foreach(Rigidbody rb in rbs)
        {
            rb.isKinematic = !enabled;
        }
        if (enabled)
        {
            pointToShoot.GetComponent<Rigidbody>().AddForce(shootDirection, ForceMode.Impulse);
        }
    }

}
