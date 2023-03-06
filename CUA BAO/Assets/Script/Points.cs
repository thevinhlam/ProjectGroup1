using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Points : MonoBehaviour
{

    public Text _Point;
    public void _AddPoint(int point)
    {
        if (point < 6)
        {
            _Point.text = "" + point + "/5";
        }
        else
        {
            _Point.text = "5/5";
        }

    }
}
