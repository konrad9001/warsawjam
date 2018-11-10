using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{

    public class Weapons
    {
        public static string SHOTGUN = "shotgun";
        public static string CAMERA = "camera";
    }

    public class EnemyAnimations
    {
        public static string ATTACK = "AttackTrigger";
        public static string DEATH = "Death";
        public static string WALK_RUN_BLEND = "WalkRun";
        public static string HIT = "HitTrigger";

        public static string ATTACK_BOOL = "AttackBool";
        public static string HIT_BOOL = "HitBool";
        public static string DEATH_BOOL = "DeathBool";

    }

    public class WeaponsAnimations
    {
        public static string ON = "on";
        public static string RELOAD = "reload";
    }

    public class Tags
    {
        public static string CLAWS = "ClawsCollider";
    }

}