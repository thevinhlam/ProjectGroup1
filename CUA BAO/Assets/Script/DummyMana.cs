using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DummyMana : MonoBehaviour
{

    public Move _move;

    public Image _fillimage1;
    public Slider _slider1;
    public float _fillvalue1;
    public GameObject _fillbar;
    // Start is called before the first frame update
    void Start()
    {
       _slider1= GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        _manabar1();
    }

    void _manabar1()
    {
        _fillvalue1 = _move._manaMax / 100;
        _slider1.value = _fillvalue1;

        if (_slider1.value <= 0.06)
        {
            _fillbar.SetActive(false);
        }
        else
        {
            _fillbar.SetActive(true);
        }
    }
}
