using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client
{
    public sealed class SceneData : MonoBehaviour
    {
        [SerializeField] Health _playerHealth;
        public Health playerHealth => _playerHealth;

        [System.NonSerialized] public float ballDeadBorder;
        [System.NonSerialized] public int fallsCount;
        [System.NonSerialized] public Vector2 ballStartVelocity;

        public int currentScores;
        public int bestScores { set { PlayerPrefs.SetInt("bs", value); } get { return PlayerPrefs.GetInt("bs", 0); } }

        public void BestScoresUpdate(int v)
        {
            bestScores = Mathf.Max(v, bestScores);
            PlayerPrefs.Save();
        }
    }
}