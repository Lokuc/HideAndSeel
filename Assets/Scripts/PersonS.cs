using com.severgames.lib.Socket;
using UnityEngine;

public class PersonS : MonoBehaviour
{ 


    public GameObject person;
    private Rigidbody2D rigidbody;
    private Vector2 vector;
    public int forse;
    private Client client;
    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = person.GetComponent<Rigidbody2D>();
        vector = new Vector2();
        client = Client.getClient();
        client.run("127.0.0.1");
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
        if (vector.x != 0 || vector.y != 0)
        {
            client.sendText("M " + "client " + vector.x + " " + vector.y);
            count++;
            Debug.Log("SEND " + count);
        }

        rigidbody.AddForce(vector, ForceMode2D.Force);
    }
}
