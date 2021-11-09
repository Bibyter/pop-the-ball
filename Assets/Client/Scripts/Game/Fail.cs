using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client.Game
{
    public sealed class Fail : MonoBehaviour
    {
        [SerializeField] GameObject _failScreen;

        SceneData _sceneData;

        private void Awake()
        {
            _sceneData = FindObjectOfType<SceneData>();
        }

        private void OnEnable()
        {
            _sceneData.BestScoresUpdate(_sceneData.currentScores);

            _failScreen.SetActive(true);
            _failScreen.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = $"Best {_sceneData.bestScores}\nCurrent {_sceneData.currentScores}";
        }

        public void Restart()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
        }
    }
}