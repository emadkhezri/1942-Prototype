namespace com.emad.game
{
    using UnityEngine;
    using UnityEditor;

    [CreateAssetMenu]
    public class GameSettings : ScriptableObject
    {

        private GameSettings() { }

        private static GameSettings _instance;
        public static GameSettings Instance
        {
            get
            {
#if UNITY_EDITOR
                if (_instance == null)
                {
                    _instance = AssetDatabase.LoadAssetAtPath<GameSettings>("Assets/" + typeof(GameSettings).Name + ".asset");
                }
#endif

                return _instance;
            }
        }

        public void Load() => _instance = this;

        [SerializeField]
        private Bounds _screenBound;
        public Bounds ScreenBound => _screenBound;

        [SerializeField]
        private Bounds _spawningBound;
        public Bounds SpawningBound => _spawningBound;

        private const float MIN_SPAWN_INTERVAL = 0.5f;
        private const float MAX_SPAWN_INTERVAL = 10f;

        #region Meteor Settings

        [Header("Meteor Settings")]
        [SerializeField]
        private float _meteorSpeed = 2;
        public float MeteorSpeed => _meteorSpeed;

        [SerializeField]
        [Range(MIN_SPAWN_INTERVAL, MAX_SPAWN_INTERVAL)]
        private float _meteorSpawningInterval = 2;
        public float MeteorSpawningInterval => _meteorSpawningInterval;

        [SerializeField]
        private float _meteorZLayer = 1;
        public float MeteorZLayer => _meteorZLayer;
        #endregion

        #region Enemy Settings

        [Header("Enemy Settings")]
        [SerializeField]
        private float _enemySpeed = 2;
        public float EnemySpeed => _enemySpeed;

        [SerializeField]
        [Range(MIN_SPAWN_INTERVAL, MAX_SPAWN_INTERVAL)]
        private float _enemySpawningInterval = 2;
        public float EnemySpawningInterval => _enemySpawningInterval;

        [SerializeField]
        private float _enemyzLayer = 1;
        public float EnemyZLayer => _enemyzLayer;

        [SerializeField]
        private float _enemyBulletSpeed;
        public float EnemyBulletSpeed => _enemyBulletSpeed;

        [SerializeField]
        [Range(MIN_SPAWN_INTERVAL, MAX_SPAWN_INTERVAL)]
        private float _enemyBulletSpawningInterval;
        public float EnemyBulletSpawningInterval => _playerBulletSpawningInterval;

        #endregion

        #region Player Settings
        [Header("Player Settings")]
        [SerializeField]
        private float _playerSpeed;
        public float PlayerSpeed => _playerSpeed;

        [SerializeField]
        [Range(MIN_SPAWN_INTERVAL, MAX_SPAWN_INTERVAL)]
        private float _playerBulletSpawningInterval;
        public float PlayerBulletSpawningInterval => _playerBulletSpawningInterval;

        [SerializeField]
        private float _playerZLayer = 1;
        public float PlayerZLayer => _playerZLayer;

        [SerializeField]
        private float _playerBulletSpeed;
        public float PlayerBulletSpeed => _playerBulletSpeed;
        #endregion
    }

}