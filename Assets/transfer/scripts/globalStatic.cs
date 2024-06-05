using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PowerUp;

public class globalStatic 
{

    public static int targetFrameRate = 90;

    public static bool updateTheStackPlease = false;

    public static Dictionary<PowerUpType, string> powerUpHints = new Dictionary<PowerUpType, string>
    {
        { PowerUpType.AddBall, "Extra ball coming your way! More bounce, more fun!" },
        { PowerUpType.DoubleBalls, "Twice the balls, twice the chaos!" },
        { PowerUpType.DirectionalControl, "Point and shoot! Guide your balls to victory." },
        { PowerUpType.Explosive, "Boom! Say goodbye to those pesky blocks." },
        { PowerUpType.IncreaseSize, "Bigger balls, bigger bangs!" },
        { PowerUpType.InvincibleBall, "Nothing can stop this ball! Go ahead, break everything!" },
        { PowerUpType.IncreaseSpeed, "Speed boost! Faster balls, quicker wins." },
        { PowerUpType.Shield, "Bubble wrap for your balls! Stay safe, stay strong." },
        { PowerUpType.slowMotion, "Matrix mode activated. Dodge and weave in slow-mo." },
        { PowerUpType.magnet, "Attraction mode on! Power-ups, come to me!" },
        { PowerUpType.tripleScrore, "Triple points! Score big or go home." },
        { PowerUpType.DoubleScore, "Double points! Score more with each hit." },
        { PowerUpType.ExtraBounce, "Boing! Extra bouncy balls for extra fun." },
        { PowerUpType.SplitBallOnCollision, "Divide and conquer! Balls multiply on impact." },
        { PowerUpType.extraTime, "More time to shine! Clock's ticking slower for you." },
        { PowerUpType.DecreaseSize, "Tiny balls, tiny troubles. Good luck!" },
        { PowerUpType.DecreaseSpeed, "Slow and steady... hopefully wins the race." },
        { PowerUpType.HalfBalls, "Half the balls, double the challenge!" },
        { PowerUpType.RandomDirection, "Where will they go? No one knows!" },
        { PowerUpType.DoubleGravity, "Heavyweight mode! Balls fall faster." },
        { PowerUpType.ReverseStack, "Flip-flop! Your power-ups are now in reverse order." },
        { PowerUpType.RandomizeStack, "Shuffle mode! Who knows what you'll get next?" },
        { PowerUpType.BlockRegeneration, "Blocks are back! Did you miss them?" },
        { PowerUpType.popTop4Powers, "Top four? Gone. Hope you didn't need those." },
        { PowerUpType.popTop2Powers, "Top two? Popped! Plan accordingly." },
    };

}
