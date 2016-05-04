using UnityEngine;
using System.Collections;
using NewtonVR;
using System;
using System.Collections.Generic;

public class MagicWand : NVRInteractableItem
{
    public GameObject SpellPrefab;

    public Transform FirePoint;

    public Vector3 SpellForce = new Vector3(0, 0, - 500);

    public int castLights = 0;
    public int maxLights = 5;

    private List<GameObject> lights = new List<GameObject>();

    public override void UseButtonDown()
    {
        if(castLights == maxLights)
        {
            CustomDestroy(lights[0]);
            lights.RemoveAt(0);
            castLights--;
        }
        if (castLights < maxLights)
        {
            base.UseButtonDown();

            GameObject spell = Instantiate(SpellPrefab);
            spell.transform.position = FirePoint.position;
            spell.transform.forward = this.transform.forward;

            spell.GetComponent<Rigidbody>().AddRelativeForce(SpellForce);
            lights.Add(spell);
            castLights++;
        }
    }

    static void CustomDestroy(GameObject o)
    {
        o.transform.position = new Vector3(100000000000f, 100000000000f, 1000000000f);
        Destroy(o);
    }
}
