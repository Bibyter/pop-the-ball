using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client
{
    // can do separation
    public sealed class SceneData : MonoBehaviour
    {
        #region
        [SerializeField] Health _playerHealth;
        public Health playerHealth => _playerHealth;
        #endregion

        #region
        [System.NonSerialized] public float ballDeadBorder;
        [System.NonSerialized] public int fallsCount;
        [System.NonSerialized] public Vector2 ballStartVelocity;
        #endregion

        #region
        [System.NonSerialized] public int currentScores;
        public int bestScores { private set { PlayerPrefs.SetInt("bs", value); } get { return PlayerPrefs.GetInt("bs", 0); } }

        public void BestScoresUpdate(int v)
        {
            bestScores = Mathf.Max(v, bestScores);
            PlayerPrefs.Save();
        }
        #endregion
    }
}