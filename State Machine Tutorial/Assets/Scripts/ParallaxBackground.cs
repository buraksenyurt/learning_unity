using UnityEngine;
public class ParallaxBackground
    : MonoBehaviour
{
    private GameObject mainCamera;
    [SerializeField]
    private float parallaxEffect;
    private float xPos;
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        xPos = transform.position.x;
    }
    void Update()
    {
        float distToMove = mainCamera.transform.position.x * parallaxEffect;
        transform.position = new Vector3(xPos + distToMove, transform.position.y);
    }
}
