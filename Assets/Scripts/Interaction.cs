using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
//    public float checkRate =0.05f;
//    private float lastCheckTime;
//    public float maxCheckDistance;
//    public LayerMask layerMask;
//    private Camera _camera;

//    public Vector3 ThirdPersonPosition;
//    Transform cameraContainer;

//    private void Start() 
//    {
//         _camera = Camera.main;
//         cameraContainer = _camera.transform.parent;
//    }

//    private void Update() 
//    {
//         if(Time.time - lastCheckTime>checkRate)
//         {
//             lastCheckTime=Time.time;

//             //Ray ray= _camera.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2));
//             Ray ray= new Ray(cameraContainer.transform.position,cameraContainer.forward) ;
//             RaycastHit hit;
//             Debug.DrawRay(cameraContainer.transform.position,cameraContainer.forward, Color.blue);


//             Vector3 raydir = cameraContainer.transform.position- this.transform.position;
//             if(Physics.Raycast(ray, out hit , maxCheckDistance, layerMask))
//             {
//                 //Debug.Log(hit.transform.position);
//                 //scameraContainer.transform.localPosition = hit.point-raydir.normalized;
//                 cameraContainer.transform.localPosition
//             }
//             else
//             {
//                cameraContainer.transform.localPosition = new Vector3(0,0.5f,0);
//             }
           
//         }
       
//    }
 

  
}
