using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client
{
    public sealed class FxService : MonoBehaviour
    {
        [SerializeField] Transform _uiFx;

        public void Play(string name, Vector3 position)
        {
            var fx = transform.Find(name);
            if (fx != null)
            {
                fx.transform.position = position;
                fx.GetComponent<ParticleSystem>().Play();
            }
        }

        public void PlayUi(string name)
        {
            var fx = _uiFx.Find(name);
            if (fx != null)
            {
                fx.GetComponent<ParticleSystem>().Play();
            }
        }

        public void StopUi(string name)
        {
            var fx = _uiFx.Find(name);
            if (fx != null)
            {
                fx.GetComponent<ParticleSystem>().Stop();
            }
        }
    }
}