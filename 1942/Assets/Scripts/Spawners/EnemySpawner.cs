namespace com.emad.game.spawners
{
    using com.emad.game.entities;

    public class EnemySpawner : EntitySpawner<EnemyEntity>
    {
        protected override float SpawningInterval => GameSettings.Instance.EnemySpawningInterval;
    }

}