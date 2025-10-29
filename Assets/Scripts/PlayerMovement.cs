
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D myRigidBody;
    [SerializeField] float speed = 5f;
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Run();
        FlipSprite();
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * speed, myRigidBody.linearVelocity.y);
        myRigidBody.linearVelocity = playerVelocity;
    }
    void FlipSprite()
    {
        bool hasHorizontalSpeed = Mathf.Abs(myRigidBody.linearVelocity.x) > Mathf.Epsilon;
        if (hasHorizontalSpeed)
        {
           transform.localScale = new Vector2(Mathf.Sign(myRigidBody.linearVelocity.x), 1f); 
        }
        
    }
}
