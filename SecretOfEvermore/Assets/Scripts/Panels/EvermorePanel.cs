using UnityEngine;
using System.Collections;

public abstract class EvermorePanel : MonoBehaviour {

    /*private GameObject _panel;
    public GameObject Panel
    {
        get { return _panel; }
        set 
        {
            if (Panel == null)
            {
                _panel = value;
            }    
        }
    }*/

    public virtual void Initialize()
    { }

    public virtual void Refresh()
    { }

    // Add methods when needed later on
}
