namespace com.emad.game.entities
{
    using UnityEngine;

    public class EnemyBulletEntity : Entity
    {
        private static string PLAYER_TAG = "Player";

        public override void DeSpawn()
        {
            base.DeSpawn();
            ObjectPool<EnemyBulletEntity>.Instance.ReleaseObject(this);
        }

        public override void OnSpawned(Transform parentTransform)
        {
            _entityZLayer = GameSettings.Instance.EnemyZLayer;
            transform.position = parentTransform.position;
            _entitySpeed = GameSettings.Instance.EnemyBulletSpeed;
            StartCoroutine(DeSpawnProcess());
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(PLAYER_TAG))
            {
                collision.GetComponent<PlayerEntity>().DeSpawn();
                DeSpawn();
            } 
        }
    }
}

