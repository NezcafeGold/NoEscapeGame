using UnityEngine;

public abstract class Character : MonoBehaviour
{
    
    [SerializeField] private float speed;
    
    private Animator animator;
    
    protected Vector2 direction;

    protected Rigidbody2D rbody;
    
    // Start is called before the first frame update
     protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Move();
        if (Input.GetKey(KeyCode.O))
        {
            speed = 5f;
        }
        if (Input.GetKey(KeyCode.I))
        {
            speed = 2f;
        }
    }

    private void Move()
    {
       // transform.Translate(direction * speed * Time.deltaTime);

        float moveHorizontal = direction.x;
        float moveVertical = direction.y;
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rbody.velocity = movement * speed;
        AnimatePlayer(direction);
    }

    public void AnimatePlayer(Vector2 direction)
    {
        animator.SetFloat("x", direction.x);
        animator.SetFloat("y", direction.y);
    }
}