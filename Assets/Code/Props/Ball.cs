using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
public class Ball : MonoBehaviour
{
    #region Properties
    [Header("Settings")]
    [SerializeField] int damage;
    [SerializeField] float speed;

    [Header("Child settings")]
    [SerializeField] int totalChilds;
    [SerializeField] byte maxParentLevel;
    [SerializeField] AssetReference childBall;
    private List<GameObject> ball;
    private Vector3 direction;
    private Collider2D trigger;
    private Rigidbody2D rigid;
    private Vector2 lastVelocity;
    public bool crossedOnSide { get; set; }
    public byte parentLevel { get; set; } = 0;
    public int Damage { get => damage; set => damage = value; }
    #endregion
    #region Unity Methods
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        trigger = GetComponentInChildren<Collider2D>();
    }
    private void Start()
    {
        ball = new List<GameObject>();
        direction = Random.insideUnitCircle.normalized;
        childBall.LoadAssetAsync<GameObject>().Completed += OnComplete;
    }
    void FixedUpdate()
    {
        lastVelocity = rigid.velocity;
        rigid.velocity = direction.normalized * speed;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            if (other.gameObject.name == "onside" && !crossedOnSide) crossedOnSide = true;
            else
            {
                var speed = lastVelocity.magnitude;
                direction = Vector2.Reflect(lastVelocity.normalized, other.contacts[0].normal);
                rigid.SetVelocity(direction * Mathf.Max(speed, 0f));
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.IsTouching(trigger))
        {
            other.GetComponent<Game.Player.Health>().AddDamage(damage);
            Break();
        }
    }
    #endregion
    private void OnComplete(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<GameObject> obj)
    {
        for (int i = 0; i < totalChilds; i++)
        {
            ball.Add(obj.Result);
        }
    }
    public void Break()
    {
        if (parentLevel <= maxParentLevel)
        {
            foreach (var item in ball)
            {
                var ball = Instantiate(item, transform.position, Quaternion.identity, null);
                var component = ball.GetComponent<Ball>();
                component.crossedOnSide = true;
                component.parentLevel++;
                component.Damage--;
                ball.transform.localScale = new Vector3(transform.localScale.x / 2, transform.localScale.y / 2);
                print("XD");
            }
        }
        Destroy(gameObject);
    }
}
