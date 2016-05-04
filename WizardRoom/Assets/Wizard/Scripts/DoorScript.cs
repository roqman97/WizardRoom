using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

    public GameObject puzzleDoor;
    public string OnTriggerEnterParameterName;
    public string OnTriggerExitParameterName;

    public Animator animator;

	// Use this for initialization
	void Start () {

        if(animator == null)
        {
            puzzleDoor = GetComponent<GameObject>();
            animator = puzzleDoor.GetComponent<Animator>();
            if(animator == null)
            {
                Debug.LogError("No animator component on this script!", puzzleDoor);
            }
        }


	}
	

    void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "WhiteLight")
        {
            animator.SetTrigger(OnTriggerEnterParameterName);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(OnTriggerExitParameterName != null && other.gameObject.tag == "WhiteLight")
        {
            animator.SetTrigger(OnTriggerExitParameterName);
        }
    }
}
