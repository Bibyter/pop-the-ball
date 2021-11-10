using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client.Game
{
    public sealed class Fail : MonoBehaviour
    {
        [SerializeField] GameObject _failScreen;

        SceneData _sceneData;
        SimpleEventBus _eventBus;

        private void Awake()
        {
            _sceneData = FindObjectOfType<SceneData>();
            _eventBus = FindObjectOfType<SimpleEventBus>();
        }

        private void OnEnable()
        {
            _sceneData.BestScoresUpdate(_sceneData.currentScores);

            _failScreen.SetActive(true);
            _failScreen.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = $"Best {_sceneData.bestScores}\nCurrent {_sceneData.currentScores}";

            _eventBus.Register<ClickEvent>(OnClick);
        }

        private void OnDisable()
        {
            _eventBus.Unregister<ClickEvent>(OnClick);
        }

        private void OnClick(ClickEvent data)
        {
            if (data.name == "fail.restart")
            {
                Restart();
            }
        }

        private void Restart()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
        }
    }
}