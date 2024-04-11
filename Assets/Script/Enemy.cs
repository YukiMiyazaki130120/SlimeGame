using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 startpos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startpos = transform.position;
        
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        rb.MovePosition(new Vector3(
            startpos.x,
            startpos.y + 3 * Mathf.Sin(Time.time * 2f),
            startpos.z
        ));
    }
}
