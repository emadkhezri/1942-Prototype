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

        private const float ENTITY_BOUND_SIZE = 1f;
        private Bounds _validBound;

        public void Init()
        {
            float boundSize = (Camera.main.orthographicSize + ENTITY_BOUND_SIZE)*2f;
            _validBound = new Bounds(Vector3.zero, new Vector3(boundSize, boundSize, boundSize));
            float xPosition = Random.Range(_validBound.min.x, _validBound.max.x);
            float yPosition = _validBound.max.y;
            transform.position = new Vector3(xPosition, yPosition);
            transform.Rotate(0, 0, Random.Range(0, 360));
        }

        // Update is called once per frame
        public void Tick()
        {
            transform.position -= new Vector3(0, Time.deltaTime * 3,0);
        }

        /// <summary>
        /// MeteorEntity is invalid if its outside the valid bound
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            if (_validBound.Contains(transform.position))
            {
                return true;
            }
            return false;
        }
    }

}