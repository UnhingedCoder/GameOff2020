using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInputHandler))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_MoveSpeed;
    [SerializeField] private float m_JumpForce;
    [SerializeField] private float m_JumpBreakForce;
    [SerializeField] private float m_gravityScale;

    private Vector3 _moveDir;

    private CharacterController controller;
    private PlayerInputHandler playerInput;

    private void Awake()
    {
        controller = this.GetComponent<CharacterController>();
        playerInput = this.GetComponent<PlayerInputHandler>();
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        _moveDir = new Vector3(playerInput.InputVector.x * m_MoveSpeed, _moveDir.y, playerInput.InputVector.y * m_MoveSpeed);

        if (controller.isGrounded)
        {
            if (playerInput.Jump)
            {
                _moveDir.y = m_JumpForce;
            }
        }
        else
        {
            if (playerInput.JumpBreak)
            {
                _moveDir.y *= m_JumpBreakForce;
            }
        }

        _moveDir.y = _moveDir.y + (Physics.gravity.y * m_gravityScale * Time.deltaTime);

        controller.Move(_moveDir * Time.deltaTime);
    }


}
