using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client
{
    public sealed class Spawner : MonoBehaviour
    {
        [SerializeField] Ball _ballPrefab;
        [SerializeField] AnimationCurve _spawnPeriodCurve;
        [SerializeField] float _spawnPositionRange = 1f;

        Coroutine _coroutine;

        IEnumerator SpawnProcess()
        {
            while(true)
            {
                yield return new WaitForSeconds(_spawnPeriodCurve.Evaluate(Random.value));

                var ballPosition = new Vector3(transform.position.x + Random.Range(_spawnPositionRange * -0.5f, _spawnPositionRange * 0.5f), transform.position.y, 0);
                var ballInstance = Instantiate(_ballPrefab, ballPosition, Quaternion.identity, null);
            }
        }

        public void BeginSpawn()
        {
            _coroutine = StartCoroutine(SpawnProcess());
        }

        public void EndSpawn()
        {
            StopCoroutine(_coroutine);
        }

        #region
#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireCube(transform.position, new Vector3(_spawnPositionRange, 0.1f, 0f));
        }
#endif
        #endregion
    }
}