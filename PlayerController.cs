using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    static int _playerSelect;
    public int PlayerSelect => _playerSelect;
    public int getPlayerSelect()
    {
        return _playerSelect;
    }
    [SerializeField] float _speed = 500, checkSpeed;
    [SerializeField] float _jumpForce;
    [SerializeField] PlayerState _playState = PlayerState.IDLE;
    [SerializeField] Satebase _satebase;
    bool _isGrounded = true;
    float _timeAttack = 0;
    Rigidbody2D _rigi;
    void Start()
    {
        _playerSelect = 0;
        checkSpeed = _speed;
        _rigi = this.GetComponent<Rigidbody2D>();
        _satebase = this.transform.GetChild(0).gameObject.GetComponent<AnimationBase>();
        if (_satebase != null)
        {
            _satebase._Start();
        }
        else
        {
            Debug.LogError("Satebase is null");
        }
    }

    void Update()
    {
        move();
        ChangePlayer();
        UpdateState();
        if (_satebase != null)
            _satebase.UpdateAnimation(_playState);
        // getPlayerSelect();
        // Attack();
    }
    void UpdateState()
    {
        if (!_isGrounded)
        {
            _playState = PlayerState.JUMP;

        }
        else
        {
            if (_rigi.velocity.x != 0)
            {
                _playState = PlayerState.RUN;
            }
            else
            {
                _playState = PlayerState.IDLE;
            }
        }
    }
    void move()
    {
        _rigi.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * _speed * Time.deltaTime, _rigi.velocity.y);
        if (_rigi.velocity.x > 0)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (_rigi.velocity.x < 0)
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetAxisRaw("Vertical") == 1 && _isGrounded)
        {
            _speed /= 2;
            _rigi.AddForce(new Vector2(0, _jumpForce));
            _isGrounded = false;
        }
    }
    void ChangePlayer()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (_playerSelect < 2)
            {
                _playerSelect++;
            }
            else
            {
                _playerSelect = 0;
            }
            if (this.GetComponent<PlayerController>().isActiveAndEnabled)
            {
                this.GetComponent<PlayerController>().enabled = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform") || other.gameObject.CompareTag("Player"))
        {
            _isGrounded = true;
            if (_speed < checkSpeed)
            {
                _speed = _speed * 2;
            }
        }
    }
    // void Attack()
    // {
    //     if(Input.GetKeyDown(KeyCode.Space))
    //     {
    //         Debug.LogError("Attack");
    //         _playState = PlayerState.ATTACK;
    //         _attack.Attack();
    //         return;
    //     }
    //     _playState = PlayerState.IDLE;
    // }
    public enum PlayerState
    {
        IDLE,
        RUN,
        JUMP,
        ATTACK,
        DIE
    }
}
