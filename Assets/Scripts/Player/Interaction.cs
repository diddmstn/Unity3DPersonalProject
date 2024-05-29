using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
   public float checkRate =0.05f;
   private float lastCheckTime;
   public float maxCheckDistance;
   public LayerMask layerMask;
   public GameObject curInteractGameObject;
   private IIteractable curInteractable;
   public TextMeshProUGUI promptText; 
   private Camera _camera;

   private void Start() 
   {
        _camera = Camera.main;
   }

   private void Update() 
   {
        if(Time.time - lastCheckTime>checkRate)
        {
            lastCheckTime=Time.time;

            Ray ray= _camera.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2));
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit , maxCheckDistance, layerMask))
            {
                if(hit.collider.gameObject != curInteractGameObject)
                {
                    curInteractGameObject= hit.collider.gameObject;
                    curInteractable = hit.collider.GetComponent<IIteractable>();
                    //프롬포트에 출력
                    SetPromptText();
                }
            }
            else
            {
                curInteractGameObject=null;
                curInteractable=null;
                promptText.gameObject.SetActive(false);
            }
        }
       
   }
   private void SetPromptText()
   {
        promptText.gameObject.SetActive(true);
        promptText.text =curInteractable.GetInteractPrompt();
   }

   public void OnInteractInput(InputAction.CallbackContext context)
   {
        if(context.phase == InputActionPhase.Started && curInteractable != null)
        {
            curInteractable.OnIteract();
            curInteractGameObject = null;
            curInteractable = null;
            promptText.gameObject.SetActive(false);

        }
   }

}
