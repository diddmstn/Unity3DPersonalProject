using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;



public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float maxMoveSpeed;
    public float minMoveSpeed;
    public float jumpPower;
    private Vector2 curMovementInput;
    private Rigidbody rb;
    public LayerMask groundLayerMask;
    public bool dash;

    [Header("Look")]
    public Transform cameraContainer;
    public float minXLook;
    public float maxXLook;
    private float camCurXRot;
    public float lookSensitivity;
    public Vector2 mouseDelta;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start() 
    {
        Cursor.lockState= CursorLockMode.Locked;
    }

    private void FixedUpdate() 
    {
        Debug.DrawRay(transform.position +(transform.forward *0.2f)+ (transform.up*0.01f),  Vector3. down,Color.green);
        Debug.DrawRay(transform.position +(-transform.forward *0.2f)+ (transform.up*0.01f),  Vector3. down,Color.green);
        Debug.DrawRay(transform.position +(transform.right *0.2f)+ (transform.up*0.01f),  Vector3. down,Color.green);
        Debug.DrawRay(transform.position +(-transform.forward *0.2f)+ (transform.up*0.01f),  Vector3. down,Color.green);
         
        Move();
        //CameraMove();

    }
    private void LateUpdate() 
    {
        CameraLook();
    }

    void Move()
    {
        Vector3 dir = transform.forward *curMovementInput.y+transform.right*curMovementInput.x;
        if(dash==false||CharacterManager.Instance.Player.condition.UseStamina()==false)
        {
            moveSpeed=minMoveSpeed;
        }
        else
        {
            moveSpeed=maxMoveSpeed;
        }
        dir *=moveSpeed;

        dir.y = rb.velocity.y;

        rb.velocity=dir;
    }

    void CameraLook()
    {
        camCurXRot+=mouseDelta.y * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot,minXLook,maxXLook); 
        cameraContainer.localEulerAngles=new Vector3(-camCurXRot,0,0);

        transform.eulerAngles += new Vector3(0,mouseDelta.x * lookSensitivity);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.phase==InputActionPhase.Performed)
        {
            curMovementInput= context.ReadValue<Vector2>();
        }
        else if(context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started && isGround())
        {
            rb.AddForce(Vector2.up*jumpPower,ForceMode.Impulse);
        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            dash=true;
            
        }
        else if(context.phase == InputActionPhase.Canceled)
        {
            dash=false;
        }
    }

     bool isGround()
    {
        Ray[] rays= new Ray[4]
        {
            new Ray(transform.position +(transform.forward *0.2f)+ (transform.up*0.01f), Vector3. down),
            new Ray(transform.position +(-transform.forward *0.2f)+ (transform.up*0.01f), Vector3. down),
            new Ray(transform.position +(transform.right *0.2f)+ (transform.up*0.01f), Vector3. down),
            new Ray(transform.position +(-transform.forward *0.2f)+ (transform.up*0.01f), Vector3. down),
        };

        for(int i =0; i<rays.Length; i++)
        {
            if(Physics.Raycast(rays[i], 0.5f,groundLayerMask))
            {
                return true;
            }
        }
        return false;
    }


}


