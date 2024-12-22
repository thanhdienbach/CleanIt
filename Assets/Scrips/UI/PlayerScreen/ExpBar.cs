using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    [SerializeField] Slider expBar;
    [SerializeField] PointLight levleUpLight;
    void Start()
    {
        
    }

    
    void Update()
    {
        expBar.value = PlayerEvent.Instance.playerExp;
    }
}
