using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonS : MonoBehaviour
{ 


    public GameObject person;
    private Rigidbody2D rigidbody;
    private Vector2 vector;
    public int forse;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = person.GetComponent<Rigidbody2D>();
        vector = new Vector2();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
       
     
        vector.x = 0;
        vector.y = 0;
        rigidbody.velocity = vector;
        if (Input.GetKey(KeyCode.W))
        {
            vector.y = forse;
        }
        if (Input.GetKey(KeyCode.S))
        {
            vector.y = -forse;
        }
        if (Input.GetKey(KeyCode.D))
        {
            vector.x = forse;
        }
        if (Input.GetKey(KeyCode.A))
        {
            vector.x = -forse;
        }

        rigidbody.AddForce(vector, ForceMode2D.Force);
    }
}
