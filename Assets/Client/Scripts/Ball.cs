using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client
{
    public sealed class Ball : MonoBehaviour
    {

        [System.Serializable]
        struct Style
        {
            public string explodeFx;
            public Material material;
        }
        [SerializeField] Style[] _styles;
        [SerializeField] int _damageMin = 1, _damageMax = 5;
        [SerializeField] int _scoreMin = 1, _scoresMax = 5;

        FxService _fxService;
        SceneData _sceneData;
        Style _currentStyle;
        Vector3 _position;
        Vector3 _velocity;


        private void Awake()
        {
            _fxService = FindObjectOfType<FxService>();
            _sceneData = FindObjectOfType<SceneData>();
        }

        private void OnEnable()
        {
            _position = transform.position;
            _velocity = _sceneData.ballStartVelocity;

            ApplyStyle();
        }

        private void ApplyStyle()
        {
            _currentStyle = _styles[Random.Range(0, _styles.Length)];

            transform.GetChild(0).GetComponent<MeshRenderer>().sharedMaterial = _currentStyle.material;
        }

        private void Update()
        {
            Move();
            GroundCollision();
        }

        private void Move()
        {
            _position += _velocity * Time.deltaTime;
            transform.position = _position;
        }

        private void GroundCollision()
        {
            if (_position.y < _sceneData.ballDeadBorder)
            {
                _sceneData.playerHealth.Take(Random.Range(_damageMin, _damageMax));
                Destroy(gameObject);
            }
        }

        public void Explode()
        {
            _sceneData.currentScores += Random.Range(_scoreMin, _scoresMax);
            _fxService.Play(_currentStyle.explodeFx, _position);
            Destroy(gameObject);
        }
    }
}