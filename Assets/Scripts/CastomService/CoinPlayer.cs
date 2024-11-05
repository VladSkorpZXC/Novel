using Naninovel;
using Naninovel.Commands;
using UnityEngine;

static public class CoinPlayer 
{
    static public int scorePlayer;

    static public int AddScore(int count)
    {
        scorePlayer += count;
        return scorePlayer;
    }

    static public int CheackScore()
    {
        return scorePlayer;
    }
}

[CommandAlias("cheackScore")]
public class cheackScore : Command
{
    public override UniTask ExecuteAsync (AsyncToken asyncToken = default)
    {
        Debug.Log(CoinPlayer.CheackScore());
        return UniTask.CompletedTask;
    }
}

[CommandAlias("addScore")]
public class addScore : Command
{
    public IntegerParameter score;

    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        CoinPlayer.AddScore(score);

        if (score >= 0)
        {
            Debug.Log($"Добавлено {score} очков");
        }
        else
        {
            Debug.Log($"Вычетто {score} очков");
        }
        return UniTask.CompletedTask;
    }
}
