namespace TextChat.Collections
{
    using System.Collections.Generic;
    public class Player
    {
        public Player() { }
        public Player(ReferenceHub referenceHub)
        {
            Ply = new Exiled.API.Features.Player(referenceHub);
        }
        public void SetMessage(Message message)
        {
            MessageList.Add(message);
        }
        private readonly Exiled.API.Features.Player Ply;
        private List<Message> MessageList=new List<Message>();
        public void BeSentMessages()
        {
            string s = $"\n\n\n<pos=-70%><size=30>{Ply.Getcolor()}按~键打开控制台输入.c团队聊天.bc全体聊天哦</color>";
            List<Message> messagesToRemove = new List<Message>();
            foreach (var message in MessageList)
            {
                if (message == null || !message.IsOnline())
                {
                    messagesToRemove.Add(message); 
                    continue;
                }
                s += '\n';
                s += message.Text;
                s += '\n';
            }
            foreach (var messageToRemove in messagesToRemove)
            {
                MessageList.Remove(messageToRemove);
            }
            Ply.Broadcast(new Exiled.API.Features.Broadcast(s, 1));
        }
    }
}
