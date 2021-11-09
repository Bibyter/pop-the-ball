using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client
{
    [System.Serializable]
    public sealed class Health
    {
        [SerializeField] int _max, _current;

        public int max { private set { _max = value; } get => _max; }
        public int current { private set { _current = value; } get => _current; }
        public bool isZero => current == 0;
        public bool isMax => current == max;
        public float normalized => current / ((float)max);

        public Health(int start)
        {
            max = start;
            current = start;
        }

        public Health(int current, int max)
        {
            this.max = max;
            this.current = current;
        }

        public void Take(int v)
        {
            if (v <= 0) return;
            current = Mathf.Max(0, current - v);
        }

        public void Heal(int v)
        {
            if (v <= 0) return;
            current = Mathf.Min(current + v, max);
        }
    }
}
