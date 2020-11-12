using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 InputVector { get; private set; }

    public bool PrepareForJump { get; private set; }

    public bool Jump { get; private set; }

    public bool JumpBreak { get; private set; }

    public bool InteractWithCar { get; private set; }

    private float _horizontal;
    private float _vertical;

    private void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        InputVector = new Vector2(_horizontal, _vertical);

        PrepareForJump = Input.GetButtonDown("Jump");

        Jump = Input.GetButton("Jump");

        JumpBreak = Input.GetButtonUp("Jump");

        InteractWithCar = Input.GetKeyDown(KeyCode.F);
    }

}
