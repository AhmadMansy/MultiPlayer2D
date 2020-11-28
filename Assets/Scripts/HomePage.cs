using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class HomePage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void JoinGame()
    {
        NetworkManager.singleton.StartClient();
    }

    public void HostGame()
    {
        NetworkManager.singleton.StartHost();
    }

    public void StartServer()
    {
        NetworkManager.singleton.StartServer();
    }

    public void GoOnline(bool state) => NetworkManager.singleton.networkAddress = state ? "3.14.65.77" : "localhost";
}
