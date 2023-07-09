using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class ScoreBoardLink : MonoBehaviour
{   
    public string url = "http://gy-race/";

    public void OpenLink()
    {
        Application.OpenURL(url);
    }
    
}
