namespace com.emad.game
{
    using UnityEngine;

    public class MeteorEntity : MonoBehaviour
    {

        [SerializeField]
        private int _instanceInPool = 5;
        /// <summary>
        /// Number of instances in the pool
        /// </summary>
        public int InstancesCount => _instanceInPool;

        public void Init()
        {
            float xPosition = Random.Range(GameSettings.Instance.MeteorSpawningBound.min.x, GameSettings.Instance.MeteorSpawningBound.max.x);
            float yPosition = GameSettings.Instance.MeteorSpawningBound.max.y;
            transform.position = new Vector3(xPosition, yPosition);
            transform.Rotate(0, 0, Random.Range(0, 360));
        }

        // Update is called once per frame
        public void Tick()
        {
            transform.position -= new Vector3(0, Time.deltaTime * GameSettings.Instance.MeteorSpeed,0);
        }

        /// <summary>
        /// MeteorEntity is invalid if its outside the valid bound
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            if (GameSettings.Instance.MeteorSpawningBound.Contains(transform.position))
            {
                return true;
            }
            return false;
        }
    }

}