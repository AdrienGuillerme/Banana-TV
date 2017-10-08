using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets
{
    public class DieScreen : MonoBehaviour {

        public void Retry()
        {
            Time.timeScale = 1; 
            gameObject.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
        }

        public void Quit()
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
            SceneManager.LoadScene("HomePageScene", LoadSceneMode.Single);
        }
    }
}
