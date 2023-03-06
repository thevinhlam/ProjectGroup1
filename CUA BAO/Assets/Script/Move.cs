using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{

    [SerializeField] public float runSpeed = 3f;
    [SerializeField] public float jumpSpeed = 1f;


    Rigidbody2D _myRigidbody;
    public DisableObjective _disableobj1;
    public DisableObjective _disableobj2;
    public DisableObjective _disableobj3;
    public DisableObjective _disableobj4;
    public DisableObjective _disableobj5;
    public DisableObjective _GATE;

    public Points _point;

    public BoxCollider2D _myBoxCollider;

    public int _obpoint = 0;

    public float _manaMax = 100;
    public float _manaAmount = 100;
    public float _manaRegen = 1f;

    public bool _isflying;
    public bool _canJump;

    //public Image _fillimage;
    //public Slider _slider;
    //public float _fillvalue;
    // Start is called before the first frame update
    void Start()
    {
        _myRigidbody = GetComponent<Rigidbody2D>();
        _myBoxCollider = GetComponent<BoxCollider2D>();
        //_slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        _running();
        _flying();
        _Gateoff();
        //_flying2();
        //_manaSys();
        //_manabar();
    }

    void _running()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _myRigidbody.velocity = new Vector2(runSpeed, _myRigidbody.velocity.y);
        }

        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _myRigidbody.velocity = new Vector2(-runSpeed, _myRigidbody.velocity.y);
        }

        //else if (Input.GetKey(KeyCode.Space))
        //{
        //    myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpSpeed);
        //}

        else
        {
            _myRigidbody.velocity = new Vector2(_myRigidbody.velocity.x, _myRigidbody.velocity.y);
        }
    }

    void _flying()
    {
        bool _isGround = _myBoxCollider.IsTouchingLayers(LayerMask.GetMask("floor"));

        if (_isGround)
        {
            _manaSysP();
            if (Input.GetKeyDown(KeyCode.Space) && _canJump == true)
            {
                _myRigidbody.velocity = new Vector2(_myRigidbody.velocity.x, jumpSpeed);
                _canJump = false;
            }

            if(Input.GetKeyUp(KeyCode.Space))
            {
                _canJump = true;
            }
            //_canJump = true;
            _isflying = false;
        }
        else
        {   
            if(Input.GetKeyUp(KeyCode.Space))
            {
                _canJump= true;
            }

            if (Input.GetKey(KeyCode.Space) && _canJump == true)
            {
                _flying2();
            }
            else
            {
                _manaSysP();
            }
            _isflying = true;
            return;
        }

    }

    void _flying2()
    {
        if (_isflying == true)
        {
            if (_manaAmount > 5)
            {
                _myRigidbody.velocity = new Vector2(_myRigidbody.velocity.x, 0.5f * jumpSpeed);
                _manaSys();
            }
        }
    }

    void _manaSys()
    {
        if(_manaAmount >= 1)
        {
            _manaAmount -= _manaRegen * 2 * Time.deltaTime;
            _manaMax = Convert.ToInt32(_manaAmount);
        }
        else
        {
            _manaAmount = 0;
        }
    }

    void _manaSysP()
    {
        if (_manaAmount <= 100)
        {
            _manaAmount += _manaRegen * Time.deltaTime;
            _manaMax = Convert.ToInt32(_manaAmount);
        }
        else
        {
            _manaAmount = 100;
        }
    }

    //void _manabar()
    //{
    //    _fillvalue = _manaAmount / 100;
    //    _slider.value = _fillvalue;
    //}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Point1")
        {
            _obpoint++;
            _point._AddPoint(_obpoint);
            _disableobj1._HideObj();
        }

        if (collision.tag == "Point2")
        {
            _obpoint++;
            _point._AddPoint(_obpoint);
            _disableobj2._HideObj();
        }

        if (collision.tag == "Point3")
        {
            _obpoint++;
            _point._AddPoint(_obpoint);
            _disableobj3._HideObj();
        }

        if (collision.tag == "Point4")
        {
            _obpoint++;
            _point._AddPoint(_obpoint);
            _disableobj4._HideObj();
        }

        if (collision.tag == "Point5")
        {
            _obpoint++;
            _point._AddPoint(_obpoint);
            _disableobj5._HideObj();
        }
    }

    public void _Gateoff()
    {
        if (_obpoint == 5)
        {
            _GATE._HideGate();
        }
    }
}
