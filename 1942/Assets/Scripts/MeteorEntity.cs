namespace com.emad.game
{
    using UnityEngine;

    public class MeteorEntity : Entity
    {
        public override void Init()
        {
            base.Init();
            transform.Rotate(0, 0, Random.Range(0, 360));
            _entitySpeed = GameSettings.Instance.MeteorSpeed;
        }
    }

}