namespace com.emad.game.spawners
{

    public class PlayerBulletSpawner : EntitySpawner<PlayerBulletEntity>
    {
        protected override float SpawningInterval => GameSettings.Instance.PlayerBulletSpawningInterval;
    }

}