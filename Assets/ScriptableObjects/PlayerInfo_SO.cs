using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInfo_SO", menuName = "Scriptable Objects/PlayerInfo_SO")]
public class PlayerInfo_SO : ScriptableObject
{
    public string playerName;
    public int playerLevel;
    public float playerHealth;
}
