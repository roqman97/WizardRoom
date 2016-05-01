using UnityEngine;
using System.Collections;
using NewtonVR;

public class wandScript : NVRInteractableItem
{
    public GameObject SpellPrefab;

    public Transform FirePoint;

    public Vector3 BulletForce = new Vector3(0, 0, 500);

    public override void UseButtonDown()
    {
        base.UseButtonDown();

        GameObject bullet = GameObject.Instantiate(SpellPrefab);
        bullet.transform.position = FirePoint.position;
        bullet.transform.forward = this.transform.forward;

        bullet.GetComponent<Rigidbody>().AddRelativeForce(BulletForce);
    }
}