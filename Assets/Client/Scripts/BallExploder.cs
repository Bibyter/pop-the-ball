using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client.Game
{
    public sealed class BallExploder : MonoBehaviour
    {
        Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out var hitInfo) &&
                    hitInfo.collider.TryGetComponent(out Ball ball))
                {
                    ball.Explode();
                }
            }
        }
    }
}