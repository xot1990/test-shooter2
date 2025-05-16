using NTC.ContextStateMachine;
using UnityEngine;

namespace Script
{
    public class RunState : State<CharController>
    {
        private readonly StateMachine<CharController> _animaMachine;

        private ViewGg _viewGG;
        private CharController controller;

        Vector3 dir;

        public RunState(ViewGg viewGG, CharController controllerGG,
            StateMachine<CharController> stateMachine) : base(controllerGG)
        {
            _viewGG = viewGG;
            _animaMachine = stateMachine;
            controller = controllerGG;
        }

        public override void OnEnter()
        {
            _viewGG.PlayAnimation("Run");
        }

        public override void OnRun()
        {
            base.OnRun();
            Run();
            LookAtCursor();
            
            if(Input.GetMouseButtonDown(0))
                _animaMachine.SetState<AttackState>();

        }

        private void Run()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            dir = new Vector3(horizontal, 0, vertical).normalized;
            dir = Quaternion.Euler(0, 45, 0) * dir;

            _viewGG.Move(dir, controller.speed);
            Quaternion quaternion = new Quaternion(0, -_viewGG.transform.rotation.y, 0, _viewGG.transform.rotation.w);

            Vector3 animaDir = quaternion * dir;

            _viewGG.SetFloatAnima("Horizontal", animaDir.x);
            _viewGG.SetFloatAnima("Vertical", animaDir.z);
        }

        private void LookAtCursor()
        {
            _viewGG.LookAt();
        }

        private void Attack()
        {
            if (Input.GetMouseButtonDown(0) == false)
                return;

            _viewGG.SetBoolAnima("isAttack", true);
        }
        
    }
}