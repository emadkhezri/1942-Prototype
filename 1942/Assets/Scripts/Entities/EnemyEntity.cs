namespace com.emad.game.entities
{

    using UnityEngine;
    public class EnemyEntity : Entity
    {
        private static string PLAYER_TAG = "Player";

        [SerializeField]
        private spawners.EnemyBulletSpawner _enemyBulletSpawner;

        public override void DeSpawn()
        {
            base.DeSpawn();
            ObjectPool<EnemyEntity>.Instance.ReleaseObject(this);
            _enemyBulletSpawner.DeSpawn();
        }

        public override void OnSpawned(Transform parentTransform)
        {
            _entityZLayer = GameSettings.Instance.EnemyZLayer;
            base.OnSpawned(parentTransform);
            _entitySpeed = GameSettings.Instance.EnemySpeed;
            _enemyBulletSpawner.Spawn();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(PLAYER_TAG))
            {
                collision.gameObject.GetComponent<Entity>().DeSpawn();
                DeSpawn();
            }
        }
    }

}