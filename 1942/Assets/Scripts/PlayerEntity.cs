namespace com.emad.game
{
    using UnityEngine;
    public class PlayerEntity : MonoBehaviour
    {

        private void Update()
        {
            //Update X axis
            float xOffset = Input.GetAxis("Horizontal") * Time.deltaTime * GameSettings.Instance.PlayerSpeed;
            Update(new Vector3(xOffset, 0));

            //Update Y axis
            float yOffset = Input.GetAxis("Vertical") * Time.deltaTime * GameSettings.Instance.PlayerSpeed;
            Update(new Vector3(0, yOffset));
        }

        private void Update(Vector3 offset)
        {
            Vector3 position = transform.position;
            position += offset;
            if (GameSettings.Instance.ScreenBound.Contains(position))
            {
                transform.position = position;
            }
        }
    }

}