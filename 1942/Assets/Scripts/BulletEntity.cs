namespace com.emad.game
{
    using UnityEngine;
    public class BulletEntity : Entity
    {
        [SerializeField]
        private bool _isPlayerBullet;

        public override void Init(Transform parentTransform)
        {
            _entityZLayer = GameSettings.Instance.EnemyZLayer;
            transform.position = parentTransform.position;
            if (_isPlayerBullet)
            {
                _entitySpeed = -1f * GameSettings.Instance.BulletSpeed;
            }
            else
            {
                _entitySpeed = GameSettings.Instance.BulletSpeed;
            }
        }
    }
}

