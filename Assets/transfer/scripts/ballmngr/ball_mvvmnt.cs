using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_mvvmnt : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector2 initSpeed = new Vector2(5,5);
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = initSpeed;
        
    }

    
}
