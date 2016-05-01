using UnityEngine;
using System.Collections;

public class handController : MonoBehaviour {

    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }

    private GameObject pickup;

	// Use this for initialization
	void Start () {
        trackedObj = GetComponent <SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(controller == null)
        {
            Debug.Log("Controller not initialized");
            return;
        }

        if (controller.GetPressDown(gripButton) && pickup != null)
        {
            Debug.Log("This should grab");
            pickup.transform.parent = this.transform;
            pickup.GetComponent<Rigidbody>().useGravity = false;
        }

        if (controller.GetPressUp(gripButton) && pickup != null)
        {
            Debug.Log("This should release");
            pickup.transform.parent = null;
            pickup.GetComponent<Rigidbody>().useGravity = true;
        }

    }

    private void OnTriggerEnter(Collider collider)
    {
        pickup = collider.gameObject;
        Debug.Log(pickup);
    }

    private void OnTriggerExit(Collider collider)
    {
        pickup = null;
    }



}
