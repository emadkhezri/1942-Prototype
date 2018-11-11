namespace com.emad.game
{
    using UnityEngine;

    public abstract class Entity : MonoBehaviour
    {

        [SerializeField]
        private int _instanceInPool = 5;
        /// <summary>
        /// Number of instances in the pool
        /// </summary>
        public int InstancesCount => _instanceInPool;

        protected float _entitySpeed;

        public virtual void Init()
        {
            float xPosition = Random.Range(GameSettings.Instance.SpawningBound.min.x, GameSettings.Instance.SpawningBound.max.x);
            float yPosition = GameSettings.Instance.SpawningBound.max.y;
            transform.position = new Vector3(xPosition, yPosition);
            transform.Rotate(0, 0, Random.Range(0, 360));
        }

        // Update is called once per frame
        public void Tick()
        {
            transform.position -= new Vector3(0, Time.deltaTime * _entitySpeed, 0);
        }

        /// <summary>
        /// Entity is invalid if its outside the valid bound
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            if (GameSettings.Instance.SpawningBound.Contains(transform.position))
            {
                return true;
            }
            return false;
        }
    }

}