using NTC.ContextStateMachine;

namespace Script
{
    public class IdleState : State<CharController>
    {
        private ViewGg _viewGG;

        public IdleState(ViewGg viewGG, CharController controllerGG) : base(controllerGG)
        {
            _viewGG = viewGG;
        }

        public override void OnEnter()
        {
            _viewGG.PlayAnimation("Idle");
        }

        public override void OnRun()
        {
            base.OnRun();
        }

        public override void OnExit()
        {
            base.OnExit();
        }
    }
}
