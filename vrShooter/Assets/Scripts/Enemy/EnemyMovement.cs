using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 1;
    [SerializeField] public Transform[] cp;
    [SerializeField] public Transform target;
    [SerializeField] private GunManager gun;

    private bool isMoving;
    private bool isShooting;
    private bool isCpSet;
    private int cpIndex;
    private Animator m_Animator;
    private Rigidbody m_Rigidbody;
    private Vector3 movementDirection;
    private Vector3 goalPosition;


    void Awake()
    {
        isMoving = false;
        isShooting = false;
        isCpSet = false;
        cpIndex = 0;
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (isShooting)
        {
            return;
        }
        if (isMoving)
        {
            //Reached current cp
            if (NotSqrtDistance(goalPosition, transform.position) < 1)
            {
                isMoving = false;
                cpIndex++;
            }
        }
        else
        {
            //There is still cp to go
            if (cpIndex < cp.Length)
            {
                goalPosition= cp[cpIndex].position;
                movementDirection = (goalPosition - transform.position).normalized * speed;
                FaceObject(goalPosition);
                m_Animator.SetFloat("speedPercent",1f);
                isMoving = true;
            }
            //Final cp reached
            else
            {
                m_Animator.SetFloat("speedPercent", 0f);
                isShooting = true;
                InvokeRepeating("Shoot", 1f, 1f);
            }
        }
    }


    private void FixedUpdate()
    {
        if (isMoving)
        {
            Move();
        }

        if (isShooting)
        {
            FaceObject(target.position);
        }
    }

    private void Move()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + Time.fixedDeltaTime * movementDirection);
    }

    void FaceObject(Vector3 objectPosition)
    {
        Vector3 relativePos = objectPosition - transform.position;

        // the second argument, upwards, defaults to Vector3.up
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;
    }

    void Shoot()
    {
        gun.Shoot(target);
    }

    float NotSqrtDistance(Vector3 a, Vector3 b)
    {
        return Mathf.Pow(a.x - b.x, 2) + Mathf.Pow(a.y - b.y, 2) + Mathf.Pow(a.z - b.z, 2);
    }
}