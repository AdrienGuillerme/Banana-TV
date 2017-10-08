using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{
    public class Restarter : MonoBehaviour
    {
        public GameObject DieMenu;
		public bool enabled = true;
		
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (enabled && other.tag == "Player")
            {
                Time.timeScale = 0;
                DieMenu.SetActive(true);
            }
		}

		private void OnCollisionEnter2D(Collision2D other)
        {
            if (enabled && other.gameObject.tag == "Player")
            {
                Time.timeScale = 0;
                DieMenu.SetActive(true);
            }
		}
    }
}
