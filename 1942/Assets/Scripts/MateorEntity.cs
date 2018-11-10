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
        private Vector2 _validPositionRange;

        // Use this for initialization
        void OnEnable()
        {
            _validPositionRange = new Vector2(-Camera.main.orthographicSize-ENTITY_BOUND_SIZE, Camera.main.orthographicSize +ENTITY_BOUND_SIZE);
            float xPosition = Random.Range(_validPositionRange.x, _validPositionRange.y);
            float yPosition = _validPositionRange.y;
            transform.position = new Vector3(xPosition, yPosition);
            transform.Rotate(0, 0, Random.Range(0, 360));
        }

        // Update is called once per frame
        void Update()
        {
            transform.position -= new Vector3(0, Time.deltaTime * 3,0);
            if(transform.position.y < _validPositionRange.x)
            {
                ObjectPool<MeteorEntity>.Instance.ReleaseObject(this);
            }
        }
    }

}