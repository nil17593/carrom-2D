using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BSWCarrom
{
    public class StrikerController : MonoBehaviour
    {
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
    }
}