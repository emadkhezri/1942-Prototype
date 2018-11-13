namespace com.emad.game.entities
{
    using UnityEngine;
    public class PlayerBulletEntity : Entity
    {

        private static string ENEMY_TAG = "Enemy";
        public override void DeSpawn()
        {
            base.DeSpawn();
            ObjectPool<PlayerBulletEntity>.Instance.ReleaseObject(this);
        }

        public override void OnSpawned(Transform parentTransform)
        {
            _entityZLayer = GameSettings.Instance.PlayerZLayer;
            transform.position = parentTransform.position;
            _entitySpeed = GameSettings.Instance.PlayerBulletSpeed;
            StartCoroutine(DeSpawnProcess());
        }


        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(ENEMY_TAG))
            {
                collision.gameObject.GetComponent<EnemyEntity>().DeSpawn();
                DeSpawn();
            }
        }
    }
}

