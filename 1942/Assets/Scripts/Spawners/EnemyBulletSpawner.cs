namespace com.emad.game.spawners
{
    using com.emad.game.entities;

    public class EnemyBulletSpawner : EntitySpawner<EnemyBulletEntity>
    {
        protected override float SpawningInterval => GameSettings.Instance.EnemyBulletSpawningInterval;

        protected override void StartSpawningProcess() { }

        public void DeSpawn()
        {
            StopCoroutine(SpawnerProcess());
        }

        public void Spawn()
        {
            StartCoroutine(SpawnerProcess());
        }
    }

}