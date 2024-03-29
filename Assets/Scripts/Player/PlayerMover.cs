﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    //private float speed;
    public Vector3 pos ;
    const float MOVE_SPEED = 0.12f;
    const float TURN_SPEED = 0.4f;
    const float JUMP_SPEED = 0.01f;
    const float JUMP_DEC_SPEED = 0.0007f;

    private Vector3 velocity;
    private Vector3 rota;
    private float rotaY;
    const float ROTA_X_VAL = 4.0f;
    const float ROTA_Y_VAL = 4.0f;

    private float jumpSpeed;

    private bool isGround;
    private bool doubleJumping;

    public void Init ()
    {
        pos = this.transform.position;
        velocity = new Vector3 (0.0f, 0.0f, 0.0f);

        rota = this.transform.localEulerAngles;
        rotaY = rota.y;

        jumpSpeed = 0.0f;
        isGround = true;
        doubleJumping = false;
    }

    public void ManagedUpdate ()
    {

        if (Input.GetKey (KeyCode.A))LeftTurn ();
        if (Input.GetKey (KeyCode.D))RightTurn ();
        if (Input.GetKey (KeyCode.W))ForwardMove ();
        if (Input.GetKey (KeyCode.S))BackMove ();

        if (Input.GetKey (KeyCode.UpArrow))UpTurn ();
        if (Input.GetKey (KeyCode.DownArrow))DownTurn ();

        if (!Input.GetKey (KeyCode.W) && !Input.GetKey (KeyCode.S))NonMove ();

        if (!this.GetComponent<Rigidbody> ().useGravity && isGround) //useGravityに変更する
        {
            if (Input.GetKeyDown (KeyCode.Space))Jump ();
        }
        else if (!this.GetComponent<Rigidbody> ().useGravity && !isGround)
        {
            Jumping ();
            if (Input.GetKeyDown (KeyCode.Space) && !doubleJumping)DoubleJump ();
        }

        JumpMove ();
        Move ();
        GroundCheck ();
    }

    void Move ()
    {
        pos += velocity;

        this.transform.position = pos;
        this.transform.localEulerAngles = rota;
    }

    void NonMove ()
    {
        velocity.x = 0.0f;
        velocity.z = 0.0f;
    }

    void Move (Vector3 pos)
    {

    }

    void LeftTurn ()
    {
        rotaY -= ROTA_Y_VAL;
        rota.y = rotaY;
    }

    void RightTurn ()
    {
        rotaY += ROTA_Y_VAL;
        rota.y = rotaY;
    }

    void ForwardMove ()
    {
        // float rad = rotaY * Mathf.Deg2Rad;

        // float vx, vz;
        // vx = MOVE_SPEED * Mathf.Sin (rad);
        // vz = MOVE_SPEED * Mathf.Cos (rad);

        // velocity.x = vx;
        // velocity.z = vz;

        velocity.x = this.transform.forward.x * MOVE_SPEED;
        velocity.z = this.transform.forward.z * MOVE_SPEED;

    }

    void BackMove ()
    {
        // float rad = rotaY * Mathf.Deg2Rad;

        // float vx, vz;
        // vx = MOVE_SPEED * Mathf.Sin (rad);
        // vz = MOVE_SPEED * Mathf.Cos (rad);

        // velocity.x = -vx;
        // velocity.z = -vz;

        velocity.x = this.transform.forward.x * -MOVE_SPEED;
        velocity.z = this.transform.forward.z * -MOVE_SPEED;

    }

    private void LeftMove ()
    {
        if (Input.GetKeyDown (KeyCode.A))
            velocity.x -= MOVE_SPEED;
    }

    private void RightMove ()
    {
        if (Input.GetKeyDown (KeyCode.D))
            velocity.x += MOVE_SPEED;
    }

    private void UpTurn ()
    {
        float rotaX = rota.x;
        rotaX -= ROTA_X_VAL;
        rota.x = rotaX;
    }

    private void DownTurn ()
    {
        float rotaX = rota.x;
        rotaX += ROTA_X_VAL;
        rota.x = rotaX;
    }

    private void Jump ()
    {
        jumpSpeed = JUMP_SPEED;
        isGround = false;
    }

    private void DoubleJump ()
    {
        jumpSpeed = JUMP_SPEED;
        doubleJumping = true;
    }

    private void Jumping ()
    {
        jumpSpeed -= JUMP_DEC_SPEED;
    }

    private void JumpMove ()
    {
        velocity.y += jumpSpeed;
    }

    private void GroundCheck ()
    {
        if (pos.y < 0.0f)
        {
            jumpSpeed = 0.0f;
            velocity.y = 0.0f;
            Vector3 tmpPos = new Vector3 (pos.x, 0.0f, pos.z);
            pos = tmpPos;

            isGround = true;
            doubleJumping = false;
        }
    }

}