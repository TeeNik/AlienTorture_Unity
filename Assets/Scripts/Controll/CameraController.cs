using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 _target,_center;
    private Rigidbody2D _rb;
    private GameObject _player;
    private CompositeDisposable _subscriptions;

    public void Init()
    {
        _rb = GetComponent<Rigidbody2D>();
        _center = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        _subscriptions = new CompositeDisposable();
        _subscriptions.Add(Game.Get().Player.Subscribe(OnPlayerChanged));
    }

    private void OnPlayerChanged(CharacterModel model)
    {
        if (model != null)
        {
            _player = model.gameObject;
        }
    }

    void Update()
    {
        if (_player != null)
        {          
            
            var mousePosition = (Input.mousePosition - _center)*0.007f+new Vector3(0,0,-10);
            Debug.Log(transform.position);
            transform.position = _player.transform.position + mousePosition;
            Vector2 center = new Vector2(Screen.width / 2, Screen.height / 2);
            if (Mathf.Abs(mousePosition.x - center.x) > 0.35 * Screen.width || Mathf.Abs(mousePosition.y - center.y) > 0.35 * Screen.height)
            {
                Vector3 mouseDir = mousePosition - new Vector3(Screen.width, Screen.height) / 2;
                _target = _player.transform.position + mouseDir.normalized * 4;
            }
            else
                _target = _player.transform.position;
            if ((transform.position - _target).magnitude > 0.5)
                _rb.velocity = (_target - transform.position).normalized * 40;
        }
    }

    void OnDestroy()
    {
        Utils.DisposeAndSetNull(ref _subscriptions);
    }
}
