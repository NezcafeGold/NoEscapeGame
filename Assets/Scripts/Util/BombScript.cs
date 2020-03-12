using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class BombScript : MonoBehaviour
{

    private Animation animation;
    private float timeLeft;
    
    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
    }

    public void Explode()
    {
 
    }

    public void Throw(float positionX, float positionY)
    {
        
        var b = Instantiate(gameObject, new Vector3(positionX, positionY, 0 ), Quaternion.identity);
       
        
        animation.Play();
      
        Destroy(b, 3.0f);
        
       
        
    }
}