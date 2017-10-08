using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{
    public class Restarter : MonoBehaviour
    {
        public GameObject DieMenu;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                Time.timeScale = 0;
               
                DieMenu.SetActive(true);
            }
            if (other.tag == "Ennemy")
            {
               Destroy(other.gameObject);
            }
        }
    }
}
