using System.Linq;
using UnityEngine;

namespace Assets
{
    public class ShurikenScript : MonoBehaviour
    {

        private float _gravityOfObjectWhoHaveBeenCollied;
        private Rigidbody2D _rbCollidedObject;

        public GameObject DieMenu;

        void OnCollisionEnter2D(Collision2D coll)
        {
            coll.otherCollider.gameObject.SetActive(false);

            if (coll.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                if (coll.gameObject.tag == "Player")
                {
                   GameObject dieMenu = coll.gameObject.transform.Find("DieScreenCanvas").gameObject;

                    Time.timeScale = 0;
                    dieMenu.SetActive(true);
                }

                _gravityOfObjectWhoHaveBeenCollied = coll.gameObject.GetComponent<Rigidbody2D>().gravityScale;
                _rbCollidedObject = coll.gameObject.GetComponent<Rigidbody2D>();
                coll.gameObject.GetComponent<Rigidbody2D>().gravityScale = 2.5f;
                Invoke("SetGravityBack", 0.5f);
            }



        }

        void Hide()
        {
            gameObject.SetActive(false);
        }

        void SetGravityBack()
        {
            _rbCollidedObject.gravityScale = 1;
        }

        // Use this for initialization
        void Start()
        {

            Debug.Log(DieMenu);
            Invoke("Hide", 0.65f);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
