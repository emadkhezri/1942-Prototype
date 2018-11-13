namespace com.emad.game.entities
{
    using UnityEngine;
    public class PlayerEntity : Entity
    {
        void Start()
        {
            EntityManager.Instance.Add(this);
        }

        public override void Tick()
        {
            //Update X axis
            float xOffset = Input.GetAxis("Horizontal") * Time.deltaTime * GameSettings.Instance.PlayerSpeed;
            UpdatePosition(new Vector3(xOffset, 0));

            //Update Y axis
            float yOffset = Input.GetAxis("Vertical") * Time.deltaTime * GameSettings.Instance.PlayerSpeed;
            UpdatePosition(new Vector3(0, yOffset));
        }

        private void UpdatePosition(Vector3 offset)
        {
            Vector3 position = transform.position;
            position += offset;
            if (GameSettings.Instance.ScreenBound.Contains(position))
            {
                transform.position = position;
            }
        }

        public override void DeSpawn()
        {
            base.DeSpawn();
            gameObject.SetActive(false);
        }
    }

}