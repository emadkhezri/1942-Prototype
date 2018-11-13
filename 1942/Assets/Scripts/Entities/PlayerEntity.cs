﻿namespace com.emad.game.entities
{
    using UnityEngine;
    public class PlayerEntity : MonoBehaviour
    {

        void Update()
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
    }

}