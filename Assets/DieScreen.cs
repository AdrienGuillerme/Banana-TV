using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets
{
    public class DieScreen : MonoBehaviour {    

        public void Retry()
        {
            Time.timeScale = 1; 
            gameObject.SetActive(false);
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
        }

        public void Quit()
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
            SceneManager.LoadScene("HomePageScene", LoadSceneMode.Single);
        }
    }
}
