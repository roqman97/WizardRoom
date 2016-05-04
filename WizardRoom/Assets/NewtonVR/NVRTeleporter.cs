﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace NewtonVR
{
    public class NVRTeleporter : MonoBehaviour
    {
         public Color LineColor;
         public float LineWidth = 0.02f;
        public float blinkTransitionSpeed = .6f;

         private LineRenderer Line;
 
         private NVRHand Hand;
 
         private void Awake()
         {
             Line = this.GetComponent<LineRenderer>();
             Hand = this.GetComponent<NVRHand>();
 
             if (Line == null)
             {
                 Line = this.gameObject.AddComponent<LineRenderer>();
             }
 
             if (Line.sharedMaterial == null)
             {
                 Line.material = new Material(Shader.Find("Unlit/Color"));
                 Line.material.SetColor("_Color", LineColor);
                 Line.SetColors(LineColor, LineColor);
             }
 
             Line.useWorldSpace = true;
         }
 
         private void LateUpdate()
         {
             Line.enabled = (Hand != null && Hand.Inputs[Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad].SingleAxis != 0);
 
             if (Line.enabled == true)
             {
                 Line.material.SetColor("_Color", LineColor);
                 Line.SetColors(LineColor, LineColor);
                 Line.SetWidth(LineWidth, LineWidth);
 
                 RaycastHit hitInfo;
                 bool hit = Physics.Raycast(this.transform.position, this.transform.forward, out hitInfo, 1000);
                 Vector3 endPoint;
 
                 if (hit == true && hitInfo.collider.tag == "Floor")
                 {
                     endPoint = hitInfo.point;
 
                     if (Hand.Inputs[Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad].PressDown == true)
                     {
                         Vector3 offset = NVRPlayer.Instance.Head.transform.position - NVRPlayer.Instance.transform.position;
                         offset.y = 0;

                        SteamVR_Fade.Start(Color.black, 0);
                        SteamVR_Fade.Start(Color.clear, blinkTransitionSpeed);
                        NVRPlayer.Instance.transform.position = hitInfo.point - offset;
                     }
                 }
                 else
                 {
                     endPoint = this.transform.position + (this.transform.forward* 1000f);
                 }
 
                 Line.SetPositions(new Vector3[] { this.transform.position, endPoint });
             }
         }
    }

}