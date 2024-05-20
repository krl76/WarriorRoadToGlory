using UnityEngine;

public class PointOfAttack : MonoBehaviour
{
    [SerializeField] public Transform[] _pointsForSpawn;
    [SerializeField] public Transform[] _allPoints;

    private void Awake()
    {
        for (int i = 0; i < _pointsForSpawn.Length; i++)
        {
            _pointsForSpawn[i] = GameObject.FindGameObjectWithTag("Point").transform;
            _allPoints[i] = GameObject.FindGameObjectWithTag("Point").transform;
        }
    }
}
