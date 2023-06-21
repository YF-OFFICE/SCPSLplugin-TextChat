namespace TextChat
{
    using System.Collections.Generic;
    using TextChat.Collections;
    public static class PlayerManager
    {
        //存储玩家实例
        private static Dictionary<ReferenceHub, Player> playerInstances = new Dictionary<ReferenceHub, Player>();
        public static void DictClear()=>playerInstances.Clear();
        //通过ReferenceHub获取玩家实例如果没有则创建
        public static Player GetPlayerInstance(ReferenceHub referenceHub)
        {
            if (playerInstances.ContainsKey(referenceHub))
            {
                return playerInstances[referenceHub];
            }
            else
            {
                Player playerInstance = new Player(referenceHub);
                playerInstances.Add(referenceHub, playerInstance);
                return playerInstance;
            }
        }
    }
}
