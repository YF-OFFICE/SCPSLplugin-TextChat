namespace TextChat
{
    using Exiled.API.Features;
    using MEC;
    using System.Collections.Generic;
    public class EventHandlers
    {
        private CoroutineHandle coroutine;
        private IEnumerator<float> SendMessage()
        {
            yield return Timing.WaitForSeconds(1f);
            //每秒发送一次消息
            while (true)
            {
                foreach (Player player in Player.List)
                {
                    var p = PlayerManager.GetPlayerInstance(player.ReferenceHub);
                    p?.BeSentMessages();
                }
                yield return Timing.WaitForSeconds(1f);
            }
        }
        public void OnRoundstarted()
        {
            coroutine=Timing.RunCoroutine(SendMessage());
        }
        public void RestartingRound()
        {
            Timing.KillCoroutines(coroutine);
            //清除玩家实例
            PlayerManager.DictClear();
        }
    }
}
