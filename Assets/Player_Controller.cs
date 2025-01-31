
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour
{
    [Header("Player Variables")]
    public float speed = 5;
    public float jumpPower = 8;
    public bool isGrounded = true;


    // Private Variables
    private Vector2 moveVector;
    private Animator animator;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    

    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        animator.SetFloat("Speed", Mathf.Abs(moveVector.x));

        if (moveVector.x > 0){
            transform.Translate(Vector2.right * Time.deltaTime * speed);
            sprite.flipX = false;
        }
        else if (moveVector.x < 0){
            transform.Translate(Vector2.left * Time.deltaTime * speed);  
            sprite.flipX = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("ground")){
            isGrounded = true;
        }
    }

    public void OnMove(InputValue moveValue) {

        moveVector = moveValue.Get<Vector2>();

        Debug.Log(moveVector.x);
        Debug.Log(moveVector.y);
    }

    public void OnJump() {
        if (isGrounded) {
            rb.AddForce(new Vector2(0,jumpPower), ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
}
