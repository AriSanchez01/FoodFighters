using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody playerChar;
    private Vector3 playerCam;

    public float speed = 10f;
    public Camera followCamera;

    public Animator charAnim;

    // Start is called before the first frame update
    void Awake()
    {
        playerChar = GetComponent<Rigidbody>();
        playerCam = followCamera.transform.position - transform.position;
        charAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction == Vector3.zero)
        {
            return;
        }

        Quaternion playerRot = Quaternion.LookRotation(direction);
        playerRot = Quaternion.RotateTowards(transform.rotation, playerRot, 360 * Time.fixedDeltaTime);
        playerChar.MovePosition(playerChar.position + direction * Time.fixedDeltaTime);
        playerChar.MoveRotation(playerRot);


    }

    private void LateUpdate()
    {
        followCamera.transform.position = playerChar.position + playerCam;
    }
}
