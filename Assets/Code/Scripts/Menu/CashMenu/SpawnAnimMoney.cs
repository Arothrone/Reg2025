using UnityEngine;

public class SpawnAnimMoney : MonoBehaviour
{
    [SerializeField] GameObject prefabToSpawn;
    [SerializeField] Transform whereToSpawn;
    [SerializeField] Transform moveForwardTo;

    Canvas canvas;

    private void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
    }
    public void Spawn()
    {
        for (int i = 0; i <= 10; i++)
        {
            GameObject gm = Instantiate(prefabToSpawn);
            gm.GetComponent<TempCoinThrow>().targetTransform = moveForwardTo;
            gm.transform.SetParent(canvas.transform, false);
            gm.transform.position = whereToSpawn.position;
        }
    }
}
