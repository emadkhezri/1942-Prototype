namespace com.emad.game
{

    public class EnemySpawner : EntitySpawner<EnemyEntity>
    {

        protected override void Tick()
        {
            _spawningIntervals = GameSettings.Instance.EnemySpawningInterval;
        }
    }

}