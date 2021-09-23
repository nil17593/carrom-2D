using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BSWCarrom
{
    public class StrikerController : MonoBehaviour
    {
        //private Rigidbody2D rigidbody;
        //public int strikerSpeed = 500;
        //[SerializeField] private GameObject arrow;
        //// public GameObject arrow;
        //Transform arrowTransform;
        //[SerializeField] private Slider strikerSlider;
        //private Vector2 dir;

        //private void Awake()
        //{
        //    rigidbody = GetComponent<Rigidbody2D>();
        //    arrowTransform = arrow.transform;
        //}

        //private void Start()
        //{
        //    strikerSlider.onValueChanged.AddListener(StrikerPosition);
        //}

        //private void FixedUpdate()
        //{
        //    if (Input.GetKeyDown(KeyCode.Space))
        //    {
        //        ShootStriker();
        //    }
        //    if (rigidbody.velocity.magnitude < 0.5f)
        //    {
        //        arrow.SetActive(true);
        //    }
        //    else
        //    {
        //        arrow.SetActive(false);
        //    }
        //}

        //private void ShootStriker()
        //{
        //    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    dir = (Vector2)(mousePos - transform.position);
        //    dir.Normalize();
        //    rigidbody.AddForce(dir * strikerSpeed);
        //}

        //private void StrikerPosition(float pos)
        //{
        //    transform.position = new Vector3(pos, -1.73f, 0f);
        //}





        private Rigidbody2D rigidbody;
        [SerializeField] private int strikerSpeed;
        [SerializeField] private GameObject arrow;
        [SerializeField] private LineRenderer lineRenderer;
        private Transform strikerTransform;
        [SerializeField] private Slider strikerSlider;
        private Vector2 startPos;
        private Vector2 dir;
        Vector3 mousePos;
        Vector3 inverseMousePos;
        private bool hasStriked=false;
        private bool isPosSet = false;

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            strikerTransform = transform;
            startPos = transform.position;
        }
        //private void Update()
        //{
          
          
        //}



        private void FixedUpdate()
        {
            lineRenderer.enabled = false;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            inverseMousePos = new Vector3(-mousePos.x, -mousePos.y, mousePos.z);
            if (Input.GetMouseButtonDown(0) && rigidbody.velocity.magnitude == 0 && isPosSet)
            {
                ShootStriker();
            }

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (!isPosSet)
                    {
                        isPosSet = true;
                    }
                }
            }
            if (!hasStriked)
            {
                SetStriker();
            }

            if (isPosSet && rigidbody.velocity.magnitude == 0)
            {
                SetLineRenderer();
            }
            if (rigidbody.velocity.magnitude <= 0.2f && rigidbody.velocity.magnitude != 0)
            {
                ResetSriker();
            }
        }

        private void SetStriker()
        {
            strikerTransform.position = new Vector2(strikerSlider.value, startPos.y);
        }

        private void ShootStriker()
        {
            float x=0;
            if(isPosSet && rigidbody.velocity.magnitude == 0)
            {
                x = Vector2.Distance(transform.position, mousePos);
            }
            dir = (Vector2)(inverseMousePos - transform.position);
            dir.Normalize();
            rigidbody.AddForce(dir *x* strikerSpeed);
            hasStriked = true;
        }

        private void ResetSriker()
        {
            rigidbody.velocity = Vector2.zero;
            hasStriked = false;
            isPosSet = false;
            lineRenderer.enabled = true;
        }

        private void SetLineRenderer()
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, strikerTransform.position);
            lineRenderer.SetPosition(1, inverseMousePos);
        }
        //Rigidbody2D rigidbody;
        //Transform strikerTransform;
        //Vector2 startPos;
        //public Slider strikerSlider;
        //Vector2 dir;
        //Vector3 mousePos;
        //Vector3 mousePos2;
        //public float strikerForce;

        //private void Start()
        //{
        //    rigidbody = GetComponent<Rigidbody2D>();
        //    strikerTransform = transform;
        //    startPos = transform.position;
        //}

        //private void ShootStriker()
        //{
        //    rigidbody.AddForce(dir * strikerForce);
        //}

        //private void Update()
        //{
        //    mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    mousePos2 = new Vector3(-mousePos.x, -mousePos.y, mousePos.z);
        //    strikerTransform.position = new Vector3(0f, -1.73f, 0f);

        //    ShootStriker();
        //}
    }
}