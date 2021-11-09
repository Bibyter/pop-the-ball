using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client
{
    public sealed class FxService : MonoBehaviour
    {
        public void Play(string name, Vector3 position)
        {
            var fx = transform.Find(name);
            if (fx != null)
            {
                fx.transform.position = position;
                fx.GetComponent<ParticleSystem>().Play();
            }
        }
    }
}