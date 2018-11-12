namespace com.emad.game
{

    public class BulletSpawner : EntitySpawner<BulletEntity>
    {
        protected override void Tick()
        {
            _spawningIntervals = GameSettings.Instance.BulletSpawningInterval;
        }
    }

}