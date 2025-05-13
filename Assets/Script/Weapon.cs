using UnityEngine;

namespace Script
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Transform _dealDamagePosition;
        [SerializeField] private Transform _nextPos;
        public GameObject effect;
        private AudioSource _audioSource;
        [SerializeField] private AudioClip _shot; 


        private LayerMask _layerMask;
        private Collider[] colliders = new Collider[10];


        private void Awake()
        {
            _layerMask = LayerMask.GetMask("Enemy","Obstacle");
            _audioSource = GetComponent<AudioSource>();
        }


        public void Damage()
        {
            _audioSource.clip = _shot;
            _audioSource.Play();
            var ray = new Ray(_dealDamagePosition.position, _nextPos.position - _dealDamagePosition.position);
            Physics.Raycast(ray, out var hit, 1000, _layerMask);
            if(hit.transform == null)
                return;
            
            if(hit.transform.TryGetComponent(out Enemy E))
            {
                E.Hit(hit.point);    
            }
            else
            {
                Instantiate(effect, hit.point, Quaternion.identity);
            }
        }
        


        private void OnDrawGizmosSelected()
        {
            if (_dealDamagePosition == null)
                return;

            Gizmos.DrawLine(_dealDamagePosition.position, _nextPos.position);
        }
    }
}