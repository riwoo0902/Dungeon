using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.PlayerMove
{
    [RequireComponent(typeof(Rigidbody2D), typeof(PlayerInput))]
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5;
        private Vector2 moveDir;


        private Rigidbody2D _rigid;

        private void Awake()
        {
            _rigid = GetComponent<Rigidbody2D>();
        }


        private void Update()
        {
            _rigid.linearVelocity = moveDir * moveSpeed;
        }

        private void OnMove(InputValue value)
        {
            moveDir = value.Get<Vector2>();
        }



    } 
}
