using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  ScoreboardLink : MonoBehaviour
{
    // Start is called before the first frame update
        public string url = "http://localhost/Site%20GY-RACE/";

    	public void OpenLink()
    	{
        	Application.OpenURL(url);
    	}
}
