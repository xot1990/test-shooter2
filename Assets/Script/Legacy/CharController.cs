using NTC.ContextStateMachine;
using UnityEngine;

namespace Script
{
    [RequireComponent(typeof(ViewGg),typeof(Weapon))]
    public class CharController : MonoBehaviour
    {
        private readonly StateMachine<CharController> _animaMachine = new StateMachine<CharController>();

        private ViewGg _view;
        private Weapon _weapon;

        private IdleState _idleState;
        private RunState _runState;
        private AttackState _attackState;

        private KeyCode _activeKeyCodeMain;
        private KeyCode _activeKeyCodeSecond;

        private float _comboTimer;
        private float _attackCD;

        private State<CharController> _mainState;
        public float speed;
        public bool isCompliteRoll = true;
        private bool _isDie;

        private bool _isPause;

        private void Awake()
        {
            _view = GetComponent<ViewGg>();
            _weapon = GetComponent<Weapon>();
            
            InstallStates();
        }

        private void Start()
        {
            _animaMachine.SetState<RunState>();
        }

        private void Update()
        {
            if (!_isPause)
            {
                _animaMachine.Run();
            }
        }

        public void SetPause(bool value)
        {
            _isPause = value;
        }

        
        private void InstallStates()
        {
            _idleState = new IdleState(_view, this);
            _runState = new RunState(_view, this, _animaMachine);
            _attackState = new AttackState(_view, this,_animaMachine);

            _animaMachine.AddStates(_idleState, _runState, _attackState);
        }


        public Transform GetTransform()
        {
            return transform;
        }
        
        
    }
}