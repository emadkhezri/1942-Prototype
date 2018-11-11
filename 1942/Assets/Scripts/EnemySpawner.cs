namespace com.emad.game
{

    public class EnemySpawner : EntitySpawner<EnemyEntity>
    {
        protected override void Initialize()
        {
            base.Initialize();
            _spawningIntervals = GameSettings.Instance.EnemySpawningInterval;
        }
    }

}