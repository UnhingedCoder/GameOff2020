using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 InputVector { get; private set; }

    public bool Jump { get; private set; }

    public bool JumpBreak { get; private set; }

    private float _horizontal;
    private float _vertical;

    private void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        InputVector = new Vector2(_horizontal, _vertical);

        Jump = Input.GetButtonDown("Jump");

        JumpBreak = Input.GetButtonUp("Jump");


    }
}
