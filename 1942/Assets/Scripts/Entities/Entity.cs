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

        protected float _entitySpeed;
        protected float _entityZLayer;

        public virtual void OnSpawned(Transform parentTransform)
        {
            float xPosition = Random.Range(GameSettings.Instance.SpawningBound.min.x, GameSettings.Instance.SpawningBound.max.x);
            float yPosition = GameSettings.Instance.SpawningBound.max.y;
            transform.position = new Vector3(xPosition, yPosition, _entityZLayer);
            transform.SetParent(parentTransform);
            StartCoroutine(DeSpawnProcess());
        }

        protected IEnumerator DeSpawnProcess()
        {
            while (true)
            {
                //Does the entity needs to despawn
                if (!GameSettings.Instance.SpawningBound.Contains(transform.position))
                {
                    DeSpawn();
                    break;
                }

                yield return new WaitForSeconds(UNSPAWN_PROCESS_INTERVAL);
            }
        }

        public virtual void DeSpawn()
        {
            StopCoroutine(DeSpawnProcess());
            EntityManager.Instance.Remove(this);
        }

        public virtual void Tick()
        {
            transform.localPosition -= new Vector3(0, Time.deltaTime * _entitySpeed, 0);
        }

    }

}