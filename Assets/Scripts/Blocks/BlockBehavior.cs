using UnityEngine;

public class BlockBehavior : MonoBehaviour
{
    public BlockType level;

    [SerializeField] AudioClip[] SFXs;
    [SerializeField] ParticleSystem VFX;
    [SerializeField] Sprite[] BlockSprites;
    [SerializeField] int pointsPerHit;

    private int hits;
    private int maxHits;
    private LevelManager manager;

    private void Awake()
    {
        manager = FindObjectOfType<LevelManager>();
        switch (level)
        {
            case BlockType.One:
                maxHits = 1;
                break;
            case BlockType.Two:
                maxHits = 2;
                break;
            case BlockType.Tree:
                maxHits = 3;
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (level == BlockType.Unbreakable) return;
        hits++;
        TriggerParticles(collision.GetContact(0).point);
        var points = Random.Range(pointsPerHit, pointsPerHit + 20);
        manager.increaseScore(points);
        if (hits >= maxHits)
        {
            manager.DecreaseBlockAmount();
            Destroy(gameObject);
        }
        if (hits >= BlockSprites.Length) return;
        GetComponent<SpriteRenderer>().sprite = BlockSprites[hits];
    }

    void TriggerParticles(Vector2 point)
    {
        var particles = Instantiate(VFX.gameObject, point, Quaternion.identity);
    }
}
