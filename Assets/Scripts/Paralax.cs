using UnityEngine;

public class Paralax : MonoBehaviour
{
    [SerializeField] private Transform followingTarget;
    [SerializeField, Range(0f, 1f)] private float parallaxStrength;
    [SerializeField] private bool disableVecrticalParallax;
    Vector3 targetPreviuosPosition;

    private void Start()
    {
        if (!followingTarget)
        {
            followingTarget = Camera.main.transform;
        }
        targetPreviuosPosition = followingTarget.position;
    }

    private void Update()
    {
        var delta = followingTarget.position - targetPreviuosPosition;
        if (disableVecrticalParallax)
        {
            delta.y = 0;
        }
        targetPreviuosPosition = followingTarget.position;

        transform.position += delta * parallaxStrength;
    }
}
