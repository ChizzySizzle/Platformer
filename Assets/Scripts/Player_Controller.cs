
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    [Header("Player Variables")]
    public float speed = 5;
    // public float maxSpeed = 7;
    public float jumpPower = 8;
    public bool isGrounded = true;
    public GameObject fire;
    public GameObject firePoint;


    // Private Variables
    private Vector2 moveVector;
    private Animator animator;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private float fireRate = 0.3f;
    private float nextFire = 3f;
    

    // Start is called before the first frame update
    void Start() {

        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate() {

        animator.SetFloat("Speed", moveVector.magnitude);

        if (moveVector.x > 0 /* && rb.velocity.x < maxSpeed */) {
            rb.velocity = new Vector2(1 * speed, rb.velocity.y);
            // transform.Translate(Vector2.right * Time.deltaTime * speed);
            // rb.AddForce(Vector2.right * speed);
            sprite.flipX = false;
        }
        else if (moveVector.x < 0 /* && rb.velocity.x > -maxSpeed */){
            rb.velocity = new Vector2(-1 * speed, rb.velocity.y);
            // transform.Translate(Vector2.left * Time.deltaTime * speed);
            // rb.AddForce(Vector2.left * speed);
            sprite.flipX = true;
        }
        else {
            rb.velocity = new Vector2(0, rb.velocity.y);
            // rb.AddForce(new Vector2(transform.position.x, transform.position.y));
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
    
        if (other.gameObject.CompareTag("ground")){
            isGrounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.CompareTag("boundary")) {
            GameManager.instance.DecreaseLives();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void OnMove(InputValue moveValue) {

        moveVector = moveValue.Get<Vector2>();
    }

    public void OnJump() {

        if (isGrounded && rb.velocity.y == 0) {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    public void OnFire() {
        if (Time.time >= nextFire) {
            nextFire = Time.time + fireRate;
            Instantiate(fire, firePoint.transform.position, firePoint.transform.rotation);
            animator.SetTrigger("isShooting");
        } 
    }
}
