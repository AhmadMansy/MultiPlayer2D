using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public abstract class AbstractBehavior : NetworkBehaviour
{
    protected Animator animator;
    [SerializeField]protected UnityEvent OnNonLocalPlayerAwake;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    [SyncVar]protected Color spriterendereColor = Color.white;

    void Start()
    {
        if(!isLocalPlayer)
        {
            OnNonLocalPlayerAwake.Invoke();
        }
        
    }

    public override void OnStartServer()
    {
        base.OnStartServer();
        spriterendereColor = Color.white;
        GetComponent<SpriteRenderer>().color = spriterendereColor;
    }

    public override void OnStartClient()
    {
        base.OnStartClient();
        spriterendereColor = Color.white;
        GetComponent<SpriteRenderer>().color = spriterendereColor;
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        GetComponent<PlayerInput>().enabled = false;
        GetComponent<PlayerInput>().enabled = true;
        spriterendereColor = Color.white;
        GetComponent<SpriteRenderer>().color = spriterendereColor;
    }

}
