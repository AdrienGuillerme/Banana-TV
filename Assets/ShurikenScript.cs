using System.Linq;
using UnityEngine;

namespace Assets
{
    public class ShurikenScript : MonoBehaviour
    {

        private float _gravityOfObjectWhoHaveBeenCollied;
        private Rigidbody2D _rbCollidedObject;


        void OnCollisionEnter2D(Collision2D coll)
        {
            coll.otherCollider.gameObject.SetActive(false);

            if (coll.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                if (coll.gameObject.tag == "Player")
                {

                    Time.timeScale = 0;
                    SettingsConstants.DieMenu.SetActive(true);
                }
                Destroy(coll.otherCollider.gameObject);
            }



        }



        void SetGravityBack()
        {
            _rbCollidedObject.gravityScale = 1;
        }

        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
