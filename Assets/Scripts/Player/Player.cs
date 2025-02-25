﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private BombScript BombScript;
    private Vector2 playerLookAt;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        GetInput();
    }


    private void GetInput()
    {
        direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
            playerLookAt = Vector2.up;
        }

        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
            playerLookAt = Vector2.down;
        }

        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
            playerLookAt = Vector2.right;
        }

        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
            playerLookAt = Vector2.left;
        }
    }

    public void ThrowBomb()
    {
        BombScript.Throw(rbody.transform.position.x, rbody.transform.position.y, playerLookAt);
    }

}