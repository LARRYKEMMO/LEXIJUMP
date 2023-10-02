using UnityEngine;

//namespace StarterAssets

    public class UICanvasControllerInput : MonoBehaviour
    {

        [Header("Output")]
        public PlayerMovement inputs;

        public void VirtualMoveInput(Vector2 virtualMoveDirection)
        {
            inputs.horizontal = virtualMoveDirection.x;
        }

        //public void VirtualLookInput(Vector2 virtualLookDirection)
        //{
        //    starterAssetsInputs.LookInput(virtualLookDirection);
        //}

        //public void VirtualJumpInput(bool virtualJumpState)
        //{
        //    starterAssetsInputs.JumpInput(virtualJumpState);
        //}

        //public void VirtualSprintInput(bool virtualSprintState)
        //{
        //    starterAssetsInputs.SprintInput(virtualSprintState);
        //}
        
    }


