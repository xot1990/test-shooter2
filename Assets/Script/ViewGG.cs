using System;
using Cysharp.Threading.Tasks;
using NTC.Pool;
using UnityEngine;

namespace Script
{
    [RequireComponent(typeof(Rigidbody))]
    public class ViewGg : MonoBehaviour
    {
        [SerializeField] private GameObject _slashEffect;
        [SerializeField] private Transform _slashPoint;
        [SerializeField] private GameObject _hitEffect;
        [SerializeField] private Transform _hitEffectPoint;
        [SerializeField] private GameObject _dashParticles;
        [SerializeField] private Transform _dashParticlesPoint;
        
        [Header("Частицы элементального урона")]
        [SerializeField] private GameObject _coldParticles;
        [SerializeField] private GameObject _fireParticles;
        [SerializeField] private GameObject _healParticles;
        
        private Camera _camera;
        private Rigidbody _body;
        private Animator _animator;
        private Vector3 _lookAtPoint;
        private float _speedMod = 1;
       

        private LayerMask _mask;

        private void Awake()
        {
            _mask = LayerMask.GetMask("Ground");
            _camera = Camera.main;
            _body = GetComponent<Rigidbody>();
            _animator = GetComponentInChildren<Animator>();
            
        }

        public void PlayAnimation(string animationName)
        {
            _animator.CrossFade(animationName,0.2f);
        }

        public void PlayAnimationInstase(string animationName)
        {
            _animator.Play(animationName);
        }

        public async void PlayAnimation(string animationName, int layer)
        {
            _animator.SetLayerWeight(layer, 1);
            _animator.CrossFade(animationName, 0.1f, layer, Time.deltaTime);
            await UniTask.DelayFrame(1);
            await UniTask.Delay(TimeSpan.FromSeconds(CurrentAnimaTime()));
            _animator.SetLayerWeight(layer, 0);
        }

        public void SetSpeedMod(float value)
        {
            _speedMod = value;
        }
        
        public void ColdEffectOn()
        {
            _coldParticles.SetActive(true);
        }

        public void FireEffectOn()
        {
            _fireParticles.SetActive(true);
        }

        public void ColdEffectOff()
        {
            _coldParticles.SetActive(false);
        }

        public void FireEffectOff()
        {
            _fireParticles.SetActive(false);
        }

        public void SetFloatAnima(string parameterName, float value)
        {
            _animator.SetFloat(parameterName, value, 0.05f, Time.deltaTime);            
        }

        public void SetBoolAnima(string parameterName, bool value)
        {
            _animator.SetBool(parameterName, value);
        }

        public bool GetBoolAnima(string parameterName)
        {
            return _animator.GetBool(parameterName);
        }

        public void Push(Vector3 vector3)
        {
            _body.AddForce(vector3 * _speedMod, ForceMode.Impulse);
        }

        public void StopMove()
        {
            _body.velocity = Vector3.zero;
        }

        public float CurrentAnimaTime()
        {
            if (_animator.GetCurrentAnimatorClipInfo(0).Length > 0)
                return _animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
            else return 0.5f;
        }

        public void Move(Vector3 direction, float speed)
        {
            transform.Translate(direction * speed * _speedMod * Time.deltaTime, Space.World);
        }

        public void Roll(Vector3 dir, float rollPower)
        {
            dir.Normalize();
            _body.AddForce(dir * rollPower * _speedMod, ForceMode.Impulse);
        }

        public void SpawnSlashEffect()
        {
            GameObject G = NightPool.Spawn(_slashEffect, _slashPoint.position,_slashPoint.rotation);
            NightPool.Despawn(G, 2);
        }

        public void HitEffect()
        {            
            GameObject G = NightPool.Spawn(_hitEffect, _hitEffectPoint.position, Quaternion.identity);
            NightPool.Despawn(G, 1);
        }

        public void SpawnDashParticles()
        {
            GameObject G = NightPool.Spawn(_dashParticles, _dashParticlesPoint.position, Quaternion.identity,transform);
            NightPool.Despawn(G, 1);
        }

        public void LookAt()
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out var hit, 1000, _mask);

            _lookAtPoint = hit.point - transform.position;
            _lookAtPoint.y = 0;
            transform.rotation = Quaternion.LookRotation(_lookAtPoint);
            _lookAtPoint.Normalize();
        }
    }
}