using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float impactPower;
    private Rigidbody[] rbs;
    private bool died = false;

    void Start()
    {
        rbs = GetComponentsInChildren<Rigidbody>();
        SetRagdoll(false,transform,transform.position);
    }


    public void SetRagdoll(bool enabled, Transform pointToShoot, Vector3 shootDirection)
    {
        if (died) return;
        
        foreach(Rigidbody rb in rbs)
        {
            rb.isKinematic = !enabled;
        }
        if (enabled)
        {
            Destroy(pointToShoot.GetComponentInParent<Animator>());
            Destroy(pointToShoot.GetComponentInParent<EnemyMovement>());


            pointToShoot.GetComponent<Rigidbody>().AddForce(shootDirection* impactPower, ForceMode.Impulse);

            died = true;
            //FindObjectOfType<EnemyManager>().OnEnemyDiedEvent();
        }
    }

}
