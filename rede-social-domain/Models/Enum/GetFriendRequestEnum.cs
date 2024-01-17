namespace rede_social_application.Models.Enum
{
    public enum GetFriendEnum
    {
        Null = 'N',
        Receiver = 'R',
        Sender = 'S'
    };

    public static class GetFriendRequestEnum
    {
        public static char ToChar(GetFriendEnum friendEnum)
        {
            return friendEnum switch
            {
                GetFriendEnum.Sender => 'S',
                GetFriendEnum.Receiver => 'R',
                _ => 'N'
            };
        }

        public static GetFriendEnum ToEnum(char friendEnum)
        {
            return friendEnum switch
            {
                'S' => GetFriendEnum.Sender,
                'R' => GetFriendEnum.Receiver,
                _ => default
            };
        }
    }
}
