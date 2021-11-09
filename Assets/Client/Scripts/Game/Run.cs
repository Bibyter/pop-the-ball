using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client.Game
{
    public sealed class Run : MonoBehaviour
    {
        [SerializeField] GameObject _gameScreen;
        [SerializeField] GameObject _failState;

        Spawner _spawner;
        SceneData _sceneData;

        private void Awake()
        {
            _spawner = FindObjectOfType<Spawner>(); // can use the injector
            _sceneData = FindObjectOfType<SceneData>(); // can use the injector
        }

        private void OnEnable()
        {
            _spawner.BeginSpawn();
            StartCoroutine(BallVelocityProcess());
            _sceneData.ballDeadBorder = -5f; // can calk value with camera size
            _gameScreen.SetActive(true);
        }

        private void OnDisable()
        {
            _spawner.EndSpawn();
            _gameScreen.SetActive(false);
        }

        private void Update()
        {
            if (_sceneData.playerHealth.isZero)
            {
                ToFail();
            }
        }

        IEnumerator BallVelocityProcess()
        {
            _sceneData.ballStartVelocity.y = -2f;

            while(true)
            {
                _sceneData.ballStartVelocity.y -= Time.deltaTime / 17f;
                yield return null;
            }
        }

        private void ToFail()
        {
            gameObject.SetActive(false);
            _failState.SetActive(true);
        }
    }
}