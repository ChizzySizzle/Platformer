
using UnityEngine;

public class DragonController : MonoBehaviour
{
    private int direction = 1;
    private SpriteRenderer rend;
    void Start() {
        
        rend = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate() {
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f);
        Debug.DrawRay(transform.position, new Vector2(0,-3), Color.red, 0.5f);

        if (hit.collider == null) {
            direction = direction * -1;
            rend.flipX = !rend.flipX;
        }

        transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x - 1 * direction, transform.position.y), Time.deltaTime);

        RaycastHit2D headHit = Physics2D.Raycast(transform.position, Vector2.up, 1f);
        if (hit.collider != null) {
            if (hit.collider.gameObject.CompareTag("player")) {
                Destroy(gameObject);
            }
        }
    }
}
