using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Player : Character
{

    [SerializeField]
    private Status madness;

    [SerializeField] 
    private BombScript BombScript;

  
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        madness.MaxMadness = 100;
        madness.CurrentMadness = 100;


    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        GetInput();
        ChangeMadness();
        
    }

    private void ChangeMadness()
    {
        madness.CurrentMadness -=0.1f;
    }
    
    private void GetInput()
    {
        direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }

        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }

        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }

        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }
        
        if (Input.GetKey(KeyCode.K))
        {
            madness.CurrentMadness +=0.2f;
        }
       
    }

    public void ThrowBomb()
    {
        BombScript.Throw(rbody.transform.position.x, rbody.transform.position.y);
      }
}