using System.Collections;
using Mirror;
using UnityEngine;

public class Bomb : AbstractItem
{
    [SyncVar]
    private bool _isReady;

    
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(3);
        _isReady = true;
        GetComponent<Animator>().enabled = true;
    }
    

    public override void OnEnter(GameObject obj)
    { 
        base.OnEnter(obj);
        if (!_isReady) return;
        obj.GetComponent<PlayerHandler>().TakeDamage(5);
        Explode();
        NetworkServer.Destroy(gameObject);
   }
    
    [Command]
    void Explode()
    {
        NetworkServer.Spawn(GameManager.Singleton.Explode(transform.position));
        RpcOnFire();
    }

    [ClientRpc]
    void RpcOnFire()
    {
        //animator.set
    }
   
}