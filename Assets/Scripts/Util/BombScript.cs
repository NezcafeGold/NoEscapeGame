using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    private float timeLeft;
    private GameObject bomb;
    private List<BombClazz> listBomb = new List<BombClazz>();
    private static GameObject wall;
    private BombClazz toDelete;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
//        timeLeft -= Time.deltaTime;
        //        if (timeLeft < 0 && bomb != null)
        //        {
        //            var ex = Instantiate(explosion, new Vector3(bomb.transform.position.x, bomb.transform.position.y, 0), Quaternion.identity);
        //            if(!explosion.GetComponent<Animator>().hasBoundPlayables) Destroy(ex);
        //            Destroy(bomb);
        //         }

        foreach (var bombClazz in listBomb)
        {
            bombClazz.timeLeft -= Time.deltaTime;
            if (bombClazz.timeLeft < 0 && (bombClazz.bomb ?? true))
            {
                Instantiate(explosion,
                    new Vector3(bombClazz.bomb.transform.position.x, bombClazz.bomb.transform.position.y, 0),
                    Quaternion.identity);
                Destroy(bombClazz.bomb);
                if (!wall.Equals(null))
                {
                    Destroy(wall);
                    wall = null;
                }

                toDelete = bombClazz;
            }
        }

        listBomb.Remove(toDelete);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.transform.tag == "Wall")
        {
            wall = other.gameObject;
        }
    }

    public void Throw(float positionX, float positionY, Vector2 direction)
    {
        var nearPlayer = 0.5f;
        Vector2 placeToReach = new Vector2(positionX, positionY);
        if (direction.Equals(Vector2.up))
        {
            positionY += nearPlayer;
            placeToReach = new Vector2(positionX, positionY+2);
        }

        if (direction.Equals(Vector2.down))
        {
            positionY -= nearPlayer;
            placeToReach = new Vector2(positionX, positionY-2);

        }

        if (direction.Equals(Vector2.right))
        {
            positionX += nearPlayer;
            placeToReach = new Vector2(positionX+2, positionY);
        }

        if (direction.Equals(Vector2.left))
        {
            positionX -= nearPlayer;
            placeToReach = new Vector2(positionX-2, positionY);
        }
       
        
        timeLeft = 3.0f;
        bomb = Instantiate(gameObject, new Vector3(positionX, positionY, 0), Quaternion.identity);
        listBomb.Add(new BombClazz(timeLeft, bomb));
        bomb.GetComponent<Rigidbody2D>().AddForce(direction *1);
        //bomb.GetComponent<Rigidbody2D>().velocity = direction * 5;
     
    }


    private class BombClazz
    {
        public float timeLeft;
        public GameObject bomb;

        public BombClazz(float timeLeft, GameObject bomb)
        {
            this.timeLeft = timeLeft;
            this.bomb = bomb;
        }
    }
}