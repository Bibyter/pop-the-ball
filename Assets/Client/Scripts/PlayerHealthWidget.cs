using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Client
{
    public sealed class PlayerHealthWidget : MonoBehaviour
    {
        [SerializeField] Image _image;

        SceneData _sceneData;
        float _cache;

        private void Awake()
        {
            _sceneData = FindObjectOfType<SceneData>();
        }

        private void OnEnable()
        {
            _cache = -1f;
        }

        private void Update()
        {
            if (_cache != _sceneData.playerHealth.normalized)
            {
                _cache = _sceneData.playerHealth.normalized;
                _image.fillAmount = _cache;
            }
        }
    }
}