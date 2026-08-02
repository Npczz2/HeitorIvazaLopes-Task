using System.Collections;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [Header("External scripts")]
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private PlayerInterfaceManager _playerInterfaceManager;
    private SpriteRenderer _spriteRender;

    private int _life;
    private int _maxLife = 5;

    private bool _hit = false;
    private float _invulnerabilityTimer = 1f;

    void Awake()
    {
        _life = _maxLife;
        _spriteRender = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        _playerInterfaceManager.RenderLife(_life);
    }

    //------------------------------------------------------------------

    public void TakeDamage()
    {
        _life--;
        _hit = true;

        if(_life <= 0)
        {
            _gameManager.GameOver();
        }

        _playerInterfaceManager.RenderLife(_life);

        AudioManager.Instance.PlayAudio(2);

        StartCoroutine(InvulnerabilityCoroutine());
    }

    IEnumerator InvulnerabilityCoroutine()
    {
        Color invColor = _spriteRender.color;
        invColor.a = 0.5f;
        _spriteRender.color = invColor;

        yield return new WaitForSeconds(_invulnerabilityTimer);

        _hit = false;
        Color normalColor = _spriteRender.color;
        normalColor.a = 1f;
        _spriteRender.color = normalColor;
    }

    //------------------------------------------------------------------

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Enemy"))
        {
            if(!_hit) TakeDamage();
        }
    }
}
