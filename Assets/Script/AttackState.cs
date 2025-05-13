using NTC.ContextStateMachine;
using UnityEngine;

namespace Script
{
    public class AttackState : State<CharController>
    {
        private readonly StateMachine<CharController> _animaMachine;

        private ViewGg _viewGG;
        private CharController controller;

        Vector3 dir;

        public AttackState(ViewGg viewGG, CharController controllerGG,
            StateMachine<CharController> stateMachine) : base(controllerGG)
        {
            _viewGG = viewGG;
            _animaMachine = stateMachine;
            controller = controllerGG;
        }

        public override void OnEnter()
        {
            _viewGG.PlayAnimation("Aim");
        }

        public override void OnRun()
        {
            base.OnRun();
            
            LookAtCursor();
            
            if(Input.GetMouseButtonUp(0))
                _animaMachine.SetState<RunState>();

        }
        private void LookAtCursor()
        {
            _viewGG.LookAt();
        }

    }
}