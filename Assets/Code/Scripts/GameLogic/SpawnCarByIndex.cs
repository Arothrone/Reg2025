using UnityEngine;
[DefaultExecutionOrder(-101)]
public class SpawnCarByIndex : MonoBehaviour
{
    [SerializeField] ListOfGOScriptableObject cars;
    [SerializeField] int carIndex;
    [SerializeField] Transform whereToSpawn;

    private void Awake()
    {
        Instantiate(cars.listOfGO[carIndex], whereToSpawn);
    }
}
