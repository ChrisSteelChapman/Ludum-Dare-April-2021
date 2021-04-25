using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    //Basic FPS Character Controller
    public float walkSpeed = 7.5f;
    public float runSpeed = 11.5f;
    public float jumpForce = 8.0f;

    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 60.0f;

    CharacterController characterController;
    Vector3 moveDir = Vector3.zero;
    float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;

    private PlayerAttack playerAttack;
    private bool canAttack = true;
    public float attackCooldown = 1f;

    public Transform holdPoint;
    public bool isCarryingObject;
    private Placeable heldObject;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerAttack = GetComponent<PlayerAttack>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isSprinting = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isSprinting ? runSpeed : walkSpeed) * Input.GetAxisRaw("Vertical") : 0;
        float curSpeedY = canMove ? (isSprinting ? runSpeed : walkSpeed) * Input.GetAxisRaw("Horizontal") : 0;
        float movementDirY = moveDir.y;
        moveDir = (forward * curSpeedX) + (right * curSpeedY);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        // On player Left Click, call to PlayerAttack and let it handle the weapons
        if (Input.GetKeyDown(KeyCode.Mouse0) && canAttack)
        {
            Debug.Log("Firing");
            playerAttack.Fire();
            StartCoroutine(AttackCooldown());
        }

        // TODO: Scroll wheel weapon switching. Modulo 2.
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerAttack.weaponType = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            playerAttack.weaponType = 1;
        }

        // Carry Object Logic
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isCarryingObject)
            {
                RaycastHit pick;
                Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out pick);

                heldObject = pick.transform.GetComponent<Placeable>();
                if (heldObject != null)
                {
                    heldObject.PickedUp(holdPoint);
                    isCarryingObject = true;
                }

            }
            else
            {
                heldObject.Released();
                heldObject = null;
                isCarryingObject = false;
            }
        }
        if (Input.GetKey(KeyCode.E))
        {
            RaycastHit build;
            Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out build);

            WorkStation workStation = build.transform.GetComponent<WorkStation>();
            if (workStation != null)
            {
                workStation.IncrementBuildTimer();
            }
        }
    }

    private void FixedUpdate()
    {
        characterController.Move(moveDir * Time.deltaTime);
    }

    IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}
