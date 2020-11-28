using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ExitGame()
    {
            
        NetworkManager.singleton.StopHost();
        NetworkManager.singleton.StopClient();
    }
}
