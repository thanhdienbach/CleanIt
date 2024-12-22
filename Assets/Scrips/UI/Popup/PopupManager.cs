using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{

    [SerializeField] List<PopupBase> popups = new List<PopupBase>();

    public void ShowPopup<T>() where T : PopupBase
    {
        foreach (var popup in popups)
        {
            if (popup is T)
            {
                popup.Show();
            }
        }
    }
    public void HidePopup<T>() where T : PopupBase
    {
        foreach (var popup in popups)
        {
            if (popup is T)
            {
                popup.Hide();
            }
        }
    }
    public void ShowAllPopup()
    {
        foreach (var popup in popups)
        {
            popup.Show();
        }
    }
    public void HideAllPopup()
    {
        foreach(var popup in popups)
        {
            popup.Hide();
        }
    }
}
