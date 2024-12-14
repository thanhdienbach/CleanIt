using UnityEngine;

public class TouchController : MonoBehaviour
{
    
    public FixedTouchField _FixedTouchField;
    public CameraLook _CameraLook;

    void Start()
    {
        
    }

    
    void Update()
    {
        _CameraLook.lockAxis = _FixedTouchField.TouchDist;
    }
}
