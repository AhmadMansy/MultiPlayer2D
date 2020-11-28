using System;
using Mirror;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _singleton;
    public static GameManager Singleton
    {
        get
        {
            if (_singleton != null) return _singleton;
            _singleton = FindObjectOfType<GameManager>();
            return _singleton;
        }
    }
    [SyncVar]

    public GameObject Explosion;
    private void Awake()
    {
        if (Singleton != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public GameObject Explode(Vector2 pos)
    {
       var explosion = Instantiate(Explosion, pos, quaternion.identity);

       return explosion;
        

    }
}