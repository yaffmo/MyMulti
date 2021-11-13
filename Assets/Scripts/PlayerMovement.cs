using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] GameObject player;

    [Command]
    private void CmdMove(Vector3 movement)
    {
        player.transform.Translate(movement);
    }

    void Update()
    {
        if (hasAuthority)
        {
            float xSpeed = 5f;
            float zSpeed = 5f;
            float xInput = Input.GetAxis("Horizontal") * xSpeed * Time.deltaTime;
            float zInput = Input.GetAxis("Vertical") * zSpeed * Time.deltaTime;
            Vector3 movement = new Vector3(xInput, 0, zInput);

            CmdMove(movement);

        }
    }
}
