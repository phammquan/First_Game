using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] GameObject _arrow;
    [SerializeField] GameObject _magic;
    float count = 0.2f;
    PlayerController _playerController;
    [SerializeField] float _timeAttack = 0;
    void Start()
    {

    }

    void Update()
    {
        _timeAttack -= Time.deltaTime;
    }
    public void Attack()
    {
        if (_timeAttack > 0)
            return;
        if (_playerController.getPlayerSelect() == 2)
        {
            GameObject arrow = Object_Pooling.Instance.getPreFabs(_arrow);
            arrow.transform.position = this.transform.position;
            arrow.transform.rotation = Quaternion.Euler(0, 0, this.transform.parent.localScale.x == 1 ? 0 : 180);
            arrow.SetActive(true);
        }
        if (_playerController.getPlayerSelect() == 3)
        {
            GameObject magic = Object_Pooling.Instance.getPreFabs(_magic);
            magic.transform.position = this.transform.position;
            magic.transform.rotation = Quaternion.Euler(0, 0, this.transform.parent.localScale.x == 1 ? 0 : 180);
            magic.SetActive(true);
        }
        _timeAttack = count;

    }
}
