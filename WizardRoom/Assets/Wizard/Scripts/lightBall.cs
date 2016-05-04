using UnityEngine;
using System.Collections;

public class lightBall : MonoBehaviour {

    // Use this for initialization
    public Rigidbody rb;
    public Vector3 rbVel;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter()
    {
        rb.isKinematic = true;
    }
}
