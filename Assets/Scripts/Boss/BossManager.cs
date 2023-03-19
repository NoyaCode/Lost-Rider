
using UnityEngine;
using UnityEngine.UI;

public class BossManager : MonoBehaviour
{
    [SerializeField] private float bossMaxHp;
    [SerializeField] private float bossHp;
    [SerializeField] private float damage;
    [SerializeField] private float bumpPower;
    [SerializeField] private float stunDuration;

    private Animator animator;
    public BoxCollider hitBox;
    public BoxCollider hurtBox;
    public Image healthBar;
    public GameObject healthBarObject;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        hitBox = GetComponent<BoxCollider>();
        bossMaxHp = 5;
        bossHp = bossMaxHp;
        damage = -0.5f;
        bumpPower = 10;
        stunDuration = 0.5f;

        GameEvents.current.OnEnterBossArea += BossTriggered;
        GameEvents.current.OnBossGotHit += HitBoss;
    }

    private void OnDestroy()
    {
        GameEvents.current.OnEnterBossArea -= BossTriggered;
        GameEvents.current.OnBossGotHit -= HitBoss;
    }
    private void BossTriggered()
    {
        healthBarObject.SetActive(true);
        animator.SetTrigger("trigger");
    }

    private void HitBoss()
    {
        bossHp -= 1;
        if(bossHp <= 0)
        {
            hitBox.enabled = false;
            hurtBox.enabled = false;
            animator.SetTrigger("dead");
        }
        else
        {
            animator.SetTrigger("hit");
        }
        healthBar.fillAmount = bossHp / bossMaxHp;
    }
    public void Dead()
    {
        StopAllCoroutines();
        GameEvents.current.CrossedFinishLine();
    }

    private void OnTriggerEnter(Collider other)
    {
        GameEvents.current.PlayerHpUpdate(damage, true);
        Vector3 force = (gameObject.transform.forward + Vector3.up) * bumpPower;
        GameEvents.current.CollisionPlayerEnemy(force, stunDuration);
        GameEvents.current.BossGotHit();
    }

}
