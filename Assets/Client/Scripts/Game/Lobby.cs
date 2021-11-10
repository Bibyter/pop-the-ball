using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client.Game
{
    public sealed class Lobby : MonoBehaviour
    {
        [SerializeField] GameObject _runState;

        Ui.LobbyScreen _screen;

        private void Awake()
        {
            _screen = FindObjectOfType<Ui.LobbyScreen>(true);
        }

        private void OnEnable()
        {
            Time.timeScale = 1f;

            _screen.gameObject.SetActive(true);
        }

        private void OnDisable()
        {
            _screen.gameObject.SetActive(false);
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