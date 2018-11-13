namespace com.emad.game.entities
{
    using UnityEngine;
    using System.Collections;

    public abstract class Entity : MonoBehaviour
    {
        private const float UNSPAWN_PROCESS_INTERVAL = 2f;

        [SerializeField]
        private int _instanceInPool = 5;
        /// <summary>
        /// Number of instances in the pool
        /// </summary>
        public int InstancesCount => _instanceInPool;

        protected bool _isValid { get; private set; }


        protected float _entitySpeed;
        protected float _entityZLayer;

        public virtual void OnSpawn(Transform parentTransform)
        {
            _isValid = true;
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
                EvaluateValidation();

                if (!_isValid)
                {
                    UnSpawn();
                    break;
                }

                yield return new WaitForSeconds(UNSPAWN_PROCESS_INTERVAL);
            }
        }

        protected abstract void UnSpawn();

        private void Update()
        {
            Tick();
        }
        // Update is called once per frame
        public virtual void Tick()
        {
            transform.position -= new Vector3(0, Time.deltaTime * _entitySpeed, 0);
        }

        /// <summary>
        /// Check the entity validation
        /// </summary>
        /// <returns></returns>
        protected void EvaluateValidation()
        {
            if (GameSettings.Instance.SpawningBound.Contains(transform.position))
            {
                _isValid = true;
            }
            else
            {
                _isValid = false;;
            }
        }
    }

}