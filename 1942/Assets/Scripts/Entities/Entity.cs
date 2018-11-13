namespace com.emad.game.entities
{
    using UnityEngine;
    using System.Collections;

    public abstract class Entity : MonoBehaviour, IEntity
    {
        private const float UNSPAWN_PROCESS_INTERVAL = 2f;

        [SerializeField]
        private int _instanceInPool = 5;
        /// <summary>
        /// Number of instances in the pool
        /// </summary>
        public int InstancesCount => _instanceInPool;

        private bool _isDisabled;
        public bool IsDisabled => _isDisabled;

        protected float _entitySpeed;
        protected float _entityZLayer;

        public virtual void OnSpawn(Transform parentTransform)
        {
            _isDisabled = false;
            float xPosition = Random.Range(GameSettings.Instance.SpawningBound.min.x, GameSettings.Instance.SpawningBound.max.x);
            float yPosition = GameSettings.Instance.SpawningBound.max.y;
            transform.position = new Vector3(xPosition, yPosition, _entityZLayer);
            transform.SetParent(parentTransform);
            StartCoroutine(UnspawnProcess());
        }

        protected IEnumerator UnspawnProcess()
        {
            while (true)
            {
                CheckSpawningBound();

                if (_isDisabled)
                {
                    UnSpawn();
                    break;
                }

                yield return new WaitForSeconds(UNSPAWN_PROCESS_INTERVAL);
            }
        }

        protected abstract void UnSpawn();

        public virtual void Tick()
        {
            transform.position -= new Vector3(0, Time.deltaTime * _entitySpeed, 0);
        }

        /// <summary>
        /// Check the spawning bound to see if it needs to set the entity to disable
        /// </summary>
        /// <returns></returns>
        protected void CheckSpawningBound()
        {
            if (!GameSettings.Instance.SpawningBound.Contains(transform.position))
            {
                _isDisabled = true;
            }
            else
            {
                _isDisabled = false;;
            }
        }
    }

}