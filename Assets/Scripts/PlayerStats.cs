
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money; // Деньги
    public static int Lives; // Жизни
    public int StartMoney = 400;
    public int StartLives = 10;
    public static int Rounds;

    private void Start() {
        Money = StartMoney;
        Lives = StartLives;
        Rounds = 0;
    }
}
