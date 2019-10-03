using Valve.VR;
using UnityEngine;

public class CharacterMoving : MonoBehaviour
{
    public Animator animator;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        //SteamVR_Input.GetFloat("squeeze", SteamVR_Input_Sources.Any);
        animator.SetFloat("Speed", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(true == SteamVR_Input.GetStateDown("InteractUI", SteamVR_Input_Sources.Any))
        {
        }
    }

    public void die()
    {
        animator.SetBool("Die", true);
        Debug.Log("BAMM");
        Destroy(this,5f);
    }
}
