using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client.Controllers
{
    public sealed class PausePopupController : MonoBehaviour
    {
        SimpleEventBus _eventBus;
        Ui.PausePopup _popup;
        Ui.GameScreen _gameScreen;

        private void Awake()
        {
            _eventBus = FindObjectOfType<SimpleEventBus>();
            _popup = FindObjectOfType<Ui.PausePopup>(true);
            _gameScreen = FindObjectOfType<Ui.GameScreen>(true);
        }

        private void OnEnable()
        {
            _eventBus.Register<ClickEvent>(OnClick);
        }

        private void OnDisable()
        {
            _eventBus.Unregister<ClickEvent>(OnClick);
        }

        private void OnClick(ClickEvent data)
        {
            if (data.name == "pause.restart")
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
            }

            if (data.name == "pause.continue")
            {
                _popup.gameObject.SetActive(false);
                _gameScreen.gameObject.SetActive(true);
                Time.timeScale = 1f;
            }

            if (data.name == "game.pause")
            {
                _popup.gameObject.SetActive(true);
                _gameScreen.gameObject.SetActive(false);
                Time.timeScale = 0f;
            }
        }
    }
}