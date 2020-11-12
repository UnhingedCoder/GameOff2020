using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CineCamController : MonoBehaviour
{
    [SerializeField] private Transform _rover;
    [SerializeField] private Transform _astronaut;

    private CinemachineFreeLook cineFreelookCam;

    private void Awake()
    {
        cineFreelookCam = GetComponent<CinemachineFreeLook>();
    }

    void SwapTargetTo(Transform target)
    {
        cineFreelookCam.LookAt = target;
        cineFreelookCam.Follow = target;
    }

    [ContextMenu("SwitchToAstronaut")]
    void SwitchToAstronaut()
    {
        SwapTargetTo(_astronaut);
    }

    [ContextMenu("SwitchToRover")]
    void SwitchToRover()
    {
        SwapTargetTo(_rover);
    }


}
