using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client.Game
{
    public sealed class Lobby : MonoBehaviour
    {
        [SerializeField] GameObject _runState;

        Ui.LobbyScreen _screen;
        FxService _fxService;

        private void Awake()
        {
            _screen = FindObjectOfType<Ui.LobbyScreen>(true);
            _fxService = FindObjectOfType<FxService>();
        }

        private void OnEnable()
        {
            Time.timeScale = 1f;

            _screen.gameObject.SetActive(true);

            _fxService.PlayUi("FX_Magic_Lights_01");
        }

        private void OnDisable()
        {
            _screen.gameObject.SetActive(false);

            _fxService.StopUi("FX_Magic_Lights_01");
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