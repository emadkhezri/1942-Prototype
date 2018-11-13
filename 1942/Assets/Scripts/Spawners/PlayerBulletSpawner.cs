namespace com.emad.game.spawners
{
    using com.emad.game.entities;

    public class PlayerBulletSpawner : EntitySpawner<PlayerBulletEntity>
    {
        protected override float SpawningInterval => GameSettings.Instance.PlayerBulletSpawningInterval;
    }

}