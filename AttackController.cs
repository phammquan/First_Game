using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] GameObject _arrow;
    [SerializeField] GameObject _magic;
    float count = 0.75f;
    [SerializeField] PlayerController _playerController;
    [SerializeField] float _timeAttack = 0;
    GameObject bullet;
    Collider2D attackarea;
    void Start()
    {


    }

    void Update()
    {
        _timeAttack -= Time.deltaTime;
        if (_playerController.getPlayerSelect() == 0)
        {
            attackarea = this.GetComponent<Collider2D>();
        }
        else
        {
            attackarea = null;
        }
        //attackarea.enabled = false;

    }
    public void Attack()
    {
        if (_timeAttack > 0)
            return;
        if (_playerController.getPlayerSelect() == 0)
        {
            attackarea.enabled = true;
            _timeAttack = count;
            return;
        }
        else if (_playerController.getPlayerSelect() == 1)
        {
            bullet = Object_Pooling.Instance.getPreFabs(_arrow);
        }
        else if (_playerController.getPlayerSelect() == 2)
        {
            bullet = Object_Pooling.Instance.getPreFabs(_magic);
        }
        bullet.transform.position = _playerController.transform.position;
        bullet.transform.rotation = Quaternion.Euler(0, 0, this.transform.parent.localScale.x == 1 ? 0 : 180);
        bullet.SetActive(true);
        _timeAttack = count;
    }
}
