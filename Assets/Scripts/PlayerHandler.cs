using Mirror;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerHandler : AbstractBehavior
{
    [SerializeField]private BoxCollider2D _collider2D;
    [SerializeField] private float _speed = 1;
    [SerializeField] private Rigidbody2D rigidbody2D;

    private Vector2 _move;

     private static readonly int V = Animator.StringToHash("V");
     private static readonly int H = Animator.StringToHash("H");
     private static readonly int B = Animator.StringToHash("B");
     [SerializeField] private float health = 100;
     private void FixedUpdate()
     {
         GetComponent<SpriteRenderer>().color = spriterendereColor;

         if (!isLocalPlayer) return;
        Vector2 currentPos = rigidbody2D.position;
        _move = Vector2.ClampMagnitude(_move, 1);
        Vector2 movement = _move * _speed;
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        //isoRenderer.SetDirection(movement);
        rigidbody2D.MovePosition(newPos);

    }
    
    public void Move(InputAction.CallbackContext context)
    {
        if (!isLocalPlayer) return;
       context.action.started += a =>
       {
           animator.SetBool(B,true);

       };  context.action.canceled += a =>
       {
           animator.SetBool(B,false);
       };
     
        _move = context.ReadValue<Vector2>();
        animator.SetFloat(H,_move.x);
        animator.SetFloat(V,_move.y);
    }

    public void NotMoving(InputAction.CallbackContext context)
    {
        
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        spriterendereColor = Color.black;
        enabled = false;
    }
    
}