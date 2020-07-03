using UnityEngine;


public class EnemyUI : MonoBehaviour
{


    public GameObject enemyCanvasPrefab = null;

    Camera cameraToLookAt;

    // Start is called before the first frame update
    void Start()
    {
        cameraToLookAt = Camera.main;
        Instantiate(enemyCanvasPrefab, transform.position, Quaternion.identity, transform);
    }

    // Update is called once per frame 
    void LateUpdate()
    {
        transform.LookAt(cameraToLookAt.transform);
        transform.rotation = Quaternion.LookRotation(cameraToLookAt.transform.forward);
    }
}