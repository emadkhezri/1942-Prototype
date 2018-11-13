namespace com.emad.game.spawners
{

    public class EnemyBulletSpawner : EntitySpawner<EnemyBulletEntity>
    {
            protected override float SpawningInterval => GameSettings.Instance.EnemyBulletSpawningInterval;

    }

}