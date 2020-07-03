using UnityEngine;

public class CameraRaycaster : MonoBehaviour
{

    public float distance = 100f;
    Camera viewCamera;

    RaycastHit m_hit;
    public RaycastHit hit
    {
        get { return m_hit; }
    }

    public Layer[] layerPriorities = {
        Layer.Enemy,
        Layer.Walkable
    };
    Layer m_layerHit;
    public Layer layerHit
    {
        get { return m_layerHit; }
    }


    // Start is called before the first frame update
    void Start()
    {
        viewCamera = Camera.main;
        layerChange += LayerChangeHandler;
        layerChange();
    }

    public delegate void OnLayerChange();
    public OnLayerChange layerChange;

    void LayerChangeHandler()
    {
        print("pechat");
    }

    // Update is called once per frame
    void Update()
    {
        // priorty of layer that is hit
        foreach (Layer layer in layerPriorities)
        {
            var hit = RaycastForLayer(layer);
            if (hit.HasValue)
            {
                m_hit = hit.Value;
                m_layerHit = layer;
                return;
            }
        }

        // artificial hit , background-a
        m_hit.distance = distance;
        m_layerHit = Layer.RaycastEndStop;// break
    }

    //error nav mesh active agent :@:@:@: ... :@:@:@

    // question for null 
    RaycastHit? RaycastForLayer(Layer layer)
    {
        int layerMask = 1 << (int)layer; // static_cast, layer to int 
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit; // vij prezentaciqta pak
        bool hasHit = Physics.Raycast(ray, out hit, distance, layerMask);
        if (hasHit)
        {
            return hit;
        }
        return null;
    }
}
