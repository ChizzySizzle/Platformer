using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Controller : MonoBehaviour
{
    public float force = 25f;
    
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = force * Vector2.right;

        Invoke("Die", 4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Die(){
        Destroy(gameObject);
    }
}
