using com.severgames.lib.Socket;
using UnityEngine;
using UnityEngine.UI;

public class LocalClient : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick(InputField inputField)
    {
        Debug.Log("gho");
        Client.getClient().run(inputField.text);
    }
}
