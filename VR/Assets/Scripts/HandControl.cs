using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(ActionBasedController))]
public class HandControl : MonoBehaviour
{
    private ActionBasedController _controller;

    public Hand hand;

    void Start()
    {
        _controller = GetComponent<ActionBasedController>();

    }
    
    void Update()
    {
        hand.SetGrip(_controller.selectAction.action.ReadValue<float>());
        hand.SetTrigger(_controller.activateAction.action.ReadValue<float>());
    }
}
