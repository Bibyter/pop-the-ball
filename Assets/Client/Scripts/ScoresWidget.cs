using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client
{
    public sealed class ScoresWidget : MonoBehaviour
    {
        [SerializeField] TMPro.TextMeshProUGUI _label;
        SceneData _sceneData;
        int _cache;

        private void Awake()
        {
            _sceneData = FindObjectOfType<SceneData>();
        }

        private void OnEnable()
        {
            _cache = -1;
        }

        private void Update()
        {
            if (_cache != _sceneData.currentScores)
            {
                _label.text = _sceneData.currentScores.ToString();
                _cache = _sceneData.currentScores;
            }
        }
    }
}