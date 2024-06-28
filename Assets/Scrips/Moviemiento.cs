using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moviemiento : MonoBehaviour
{
    public float horizontalspeed;
    public float verticalspeed;
    private Vector3 playerInput;


    public CharacterController player;

    public float playerSpeed;
    private Vector3 movePlayer;

    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;

    // Start is called before the first frame update
    void Start()
    {
      player = GetComponent<CharacterController>();  
    }

    // Update is called once per frame
    void Update()
    {
        horizontalspeed = Input.GetAxis("Horizontal");
        verticalspeed = Input.GetAxis("Vertical");

        playerInput = new Vector3(horizontalspeed, 0, verticalspeed);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        camDireccion();

        movePlayer = playerInput.x * camRight + playerInput.z * camForward;

        player.transform.LookAt(player.transform.position + movePlayer);

        player.Move(movePlayer * playerSpeed * Time.deltaTime);

        Debug.Log(player.velocity.magnitude);
    }

    void camDireccion()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }
}
