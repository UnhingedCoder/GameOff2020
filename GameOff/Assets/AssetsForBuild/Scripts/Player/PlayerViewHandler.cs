using UnityEngine;

[RequireComponent(typeof(PlayerInputHandler))]
public class PlayerViewHandler : MonoBehaviour
{
    [SerializeField] private Animator anim;

    [SerializeField] private ParticleSystem fx_JetpackL;
    [SerializeField] private ParticleSystem fx_JetpackR;
    [SerializeField] private float m_JetpackSmokeMaxEmission;

    private ParticleSystem.EmissionModule fxEmit_JetpackL;
    private ParticleSystem.EmissionModule fxEmit_JetpackR;

    private PlayerInputHandler playerInput;
    private PlayerController playerController;
    private CharacterController controller;

    private void Awake()
    {
        playerInput = this.GetComponent<PlayerInputHandler>();
        playerController = this.GetComponent<PlayerController>();
        controller = this.GetComponent<CharacterController>();

        fxEmit_JetpackL = fx_JetpackL.emission;
        fxEmit_JetpackR = fx_JetpackR.emission;

        playerController.e_Jump.AddListener(TriggerJumpAnimation);
    }

    private void Update()
    {
        SetAnimationStates();
        HandleJackPackSmoke();
    }

    void SetAnimationStates()
    {
        anim.SetBool("GROUNDED", controller.isGrounded);
        anim.SetFloat("SPEED", (Mathf.Abs(playerInput.InputVector.y) + Mathf.Abs(playerInput.InputVector.x)));
    }

    void TriggerJumpAnimation()
    {
        anim.SetTrigger("JUMP");
    }


    void HandleJackPackSmoke()
    {
        if (controller.velocity.y > 0.01 && !controller.isGrounded)
        {
            fxEmit_JetpackL.rateOverTime = m_JetpackSmokeMaxEmission;
            fxEmit_JetpackR.rateOverTime = m_JetpackSmokeMaxEmission;
        }
        else
        {
            fxEmit_JetpackL.rateOverTime = 0;
            fxEmit_JetpackR.rateOverTime = 0;
        }
    }
}
