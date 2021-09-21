using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BSWCarrom
{
    public class StrikerController : MonoBehaviour
    {
        private Rigidbody2D rigidbody;
        public int strikerSpeed = 500;
        [SerializeField] private GameObject arrow;
        // public GameObject arrow;
        Transform arrowTransform;
        [SerializeField] private Slider strikerSlider;
        private Vector2 dir;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            arrowTransform = arrow.transform;
        }

        private void Start()
        {
            strikerSlider.onValueChanged.AddListener(StrikerPosition);
        }

        private void FixedUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ShootStriker();
            }
            if (rigidbody.velocity.magnitude < 0.5f)
            {
                arrow.SetActive(true);
            }
            else
            {
                arrow.SetActive(false);
            }
        }

        private void ShootStriker()
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dir = (Vector2)(mousePos - transform.position);
            dir.Normalize();
            rigidbody.AddForce(dir * strikerSpeed);
        }

        private void StrikerPosition(float pos)
        {
            transform.position = new Vector3(pos, -1.73f, 0f);
        }
    }
}