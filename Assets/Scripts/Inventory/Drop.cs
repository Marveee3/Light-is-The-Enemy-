using UnityEngine;

public class Drop : MonoBehaviour
{
    [SerializeField] private GameObject item;
    private Transform player;
    private bool _isFacingRight;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void SpawnDroppedItem()
    {
        _isFacingRight = player.gameObject.GetComponent<PlayerMove>().isFacingRight;
        if (_isFacingRight == true)
        {
            Vector2 playerPos = new Vector2(player.position.x + 1, player.position.y);
            Instantiate(item, playerPos, Quaternion.identity);
        }
        else
        {
            Vector2 playerPos = new Vector2(player.position.x - 1, player.position.y);
            Instantiate(item, playerPos, Quaternion.identity);
        }
    }
}
