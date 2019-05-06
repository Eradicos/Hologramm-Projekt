using UnityEngine;
using UnityEngine.UI;

public class GazeAndWaitController : MonoBehaviour {

    public delegate void LoadingStarted();
    public event LoadingStarted loadingStarted;

    public delegate void LoadingAborted();
    public event LoadingAborted loadingAborted;

    public delegate void LoadingFinished();
    public event LoadingFinished loadingFinished;

    public float GazeTrigger = 0.4f;
    public float LoadingAnimationTime = 3.0f;

    private Animator animator;
    private bool isLoading;
    private Vector3 colliderPosition;
    private float colliderAngleMax;

    private void Awake() {
        // Adjust icon rotation to look at world center
        //transform.LookAt(Camera.main.transform.position);
        transform.LookAt(Vector3.zero);

        // Get animator
        animator = GetComponent<Animator>();

        // Calculate the max angle for the outer collider
        SphereCollider sphereCollider = GetComponent<SphereCollider>();
        colliderPosition = transform.TransformPoint(sphereCollider.center);
        //Debug.Log("CenterPosition: " + colliderPosition);
        Vector3 outerPosition = (
            transform.TransformPoint(Vector3.right * sphereCollider.radius)
        );
        //Debug.Log("OuterPosition: " + outerPosition);
        colliderAngleMax = Vector3.Angle(colliderPosition, outerPosition);
        //Debug.Log("ColliderAngleMax: " + colliderAngleMax);
    }

    private void OnEnable() {
        ResetAnimation();
    }

    private void ResetAnimation() {
        isLoading = false;
        animator.speed = 0.0f;
        animator.Play("IconGrow", 0, 0.0f);
        animator.Play("IconLoadingBar", 1, 0.0f);

        CancelInvoke("FinishLoading");
    }

    private void StartLoading() {
        animator.speed = 1.0f / LoadingAnimationTime;
        animator.Play("IconLoadingBar", 1, 0.0f);

        Invoke("FinishLoading", LoadingAnimationTime);

        isLoading = true;

        if (loadingStarted != null) {
            loadingStarted();
        }
    }

    private void StopLoading() {
        ResetAnimation();

        if (loadingAborted != null) {
            loadingAborted();
        }
    }

    private void FinishLoading() {
        if (loadingFinished != null) {
            loadingFinished();
        }
    }

    private void UpdateGazeTrigger(GameObject reference) {
        Vector3 referenceForward = reference.transform.forward;
        float angleBetween = Vector3.Angle(referenceForward, colliderPosition - reference.transform.position);
        //Debug.Log("AngleBetween: " + angleBetween);

        float angleFactor = Mathf.Clamp(
            1.0f - (angleBetween / colliderAngleMax), 0.0f, 1.0f
        );

        if (angleFactor >= GazeTrigger) {
            if (!isLoading) {
                StartLoading();
            }
        } else {
            if (isLoading) {
                StopLoading();
            }

            float animationFactor = Mathf.Min(1.0f, angleFactor / GazeTrigger);
            animator.Play("IconGrow", 0, animationFactor);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("MainCamera")) {
            UpdateGazeTrigger(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("MainCamera")) {
            UpdateGazeTrigger(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.CompareTag("MainCamera")) {
            UpdateGazeTrigger(other.gameObject);
        }
    }

}
