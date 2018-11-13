namespace com.emad.game.spawners
{
    using com.emad.game.entities;

    public class EnemyBulletSpawner : EntitySpawner<EnemyBulletEntity>
    {
            protected override float SpawningInterval => GameSettings.Instance.EnemyBulletSpawningInterval;
    }

}