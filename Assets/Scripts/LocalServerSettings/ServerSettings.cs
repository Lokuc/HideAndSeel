using com.severgames.lib.Socket;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ServerSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick()
    {
        ServerSocket.getInstains();
        //Client.getClient().run("192.168.0.103");
        SceneManager.LoadScene("MainGame");

    }
}
