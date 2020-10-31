using com.severgames.lib.network;
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
    private bool move = false;
    private Vector2 temp;
    private VectorPull vectors;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = client1.GetComponent<Rigidbody2D>();
        vector = new Vector2();
        temp = new Vector2(0,0);
        vectors = new VectorPull();
        Client.getClient().setNetwork(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Move(string name, float x, float y)
    {
        vectors.add(x, y);
    }

    private void FixedUpdate()
    {

        temp.x = 0;
        temp.y = 0;
        rigidbody.velocity = temp;
        rigidbody.AddForce(vectors.getLast(), ForceMode2D.Force);
    }

}

