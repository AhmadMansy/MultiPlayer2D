using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

public class FightBehavior : AbstractBehavior
{
    private static readonly int Fight1 = Animator.StringToHash("Fight");

    [SyncVar]

    private PlayerHandler _playerInRange;
    
    [SyncVar]

    public GameObject bomb;
    
    [SyncVar]

    public ParticleSystem ParticleSystem;
    
    public void Fight(InputAction.CallbackContext context)
    {
        if (!isLocalPlayer) return;

        if (context.canceled) return;
        if (context.started)
        {
            PlaceBomb();

        }

    }
    
    [Command]
    void PlaceBomb()
    {
        if (_playerInRange != null)_playerInRange.TakeDamage(5);
        ParticleSystem.Play();
        var b = Instantiate(bomb, transform.position, Quaternion.identity);
        NetworkServer.Spawn(b);
        RpcOnFire();
    }

    [ClientRpc]
    void RpcOnFire()
    {
        animator.SetBool(Fight1,true);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        _playerInRange = other.GetComponent<PlayerHandler>();

        if (other.TryGetComponent(out Bomb b))b.OnEnter(gameObject);
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        _playerInRange = null;
    }
}
