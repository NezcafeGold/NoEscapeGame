using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    private float timeLeft;
    private GameObject bomb;
    private static List<GameObject> bombList = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft<0 && bomb !=null)
            Destroy(bomb);
    }

    public void Explode()
    {
 
    }

    public void Throw(float positionX, float positionY)
    {
        timeLeft = 3.0f;
        bomb = Instantiate(gameObject, new Vector3(positionX, positionY, 0 ), Quaternion.identity);
    }
}