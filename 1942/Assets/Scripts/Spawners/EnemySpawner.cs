namespace com.emad.game.spawners
{

    public class EnemySpawner : EntitySpawner<EnemyEntity>
    {
        protected override float SpawningInterval => GameSettings.Instance.EnemySpawningInterval;
    }

}