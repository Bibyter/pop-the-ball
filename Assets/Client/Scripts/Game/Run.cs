using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client.Game
{
    public sealed class Run : MonoBehaviour
    {
        [SerializeField] GameObject _failState;

        Ui.GameScreen _screen;
        Spawner _spawner;
        SceneData _sceneData;

        private void Awake()
        {
            _spawner = FindObjectOfType<Spawner>();
            _sceneData = FindObjectOfType<SceneData>();
            _screen = FindObjectOfType<Ui.GameScreen>(true);
        }

        private void OnEnable()
        {
            _spawner.BeginSpawn();
            StartCoroutine(BallVelocityProcess());
            _sceneData.ballDeadBorder = -5f; // can calk value with camera size
            _screen.gameObject.SetActive(true);
        }

        private void OnDisable()
        {
            // trouble on destroy scene - var is null
            if (_spawner != null) _spawner.EndSpawn();

            _screen.gameObject.SetActive(false);
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