using com.severgames.lib.Socket;
using UnityEngine;

public class Netword : MonoBehaviour
{

    private ServerSocket server;
    public GameObject client1;
    private Client client;
    private Vector2 vector;
    private Rigidbody2D rigidbody;
    private int count = 0;
    private int counts = 0;
    private bool move = false;
    private Vector2 temp;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = client1.GetComponent<Rigidbody2D>();
        vector = new Vector2();
        temp = new Vector2(0,0);
        Client.getClient().setNetwork(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Move(string name, float x, float y)
    {
        Debug.Log(x + " F " + y);

        vector.x = x;
        vector.y = y;
        Debug.Log(vector.x + " H " + vector.y);
        count++;
        Debug.Log("CO" + count);
        move = false;

    }

    private void FixedUpdate()
    {

        temp.x = 0;
        temp.y = 0;
        rigidbody.velocity = temp;
        rigidbody.AddForce(vector, ForceMode2D.Force);
        vector.x = 0;
        vector.y = 0;
        counts++;
        Debug.Log("SE" + counts);
    }

}

