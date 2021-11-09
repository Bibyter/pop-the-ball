using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client.Game
{
    public sealed class Lobby : MonoBehaviour
    {
        [SerializeField] GameObject _lobbyScreen; // can use the injector
        [SerializeField] GameObject _runState;

        private void OnEnable()
        {
            _lobbyScreen.SetActive(true);
        }

        private void OnDisable()
        {
            _lobbyScreen.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                ToRun();
            }
        }

        private void ToRun()
        {
            gameObject.SetActive(false);
            _runState.SetActive(true);
        }
    }
}