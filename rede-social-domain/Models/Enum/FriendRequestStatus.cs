namespace rede_social_domain.Models.Enum
{
    public enum FriendStatusEnum
    {
        Pendent,
        Accepted,
        Refused,
        Removed
    }

    public static class FriendRequestStatusEnumConverter
    {
        public static char ToChar(FriendStatusEnum friendStatusEnum)
        {
            switch (friendStatusEnum)
            {
                case FriendStatusEnum.Pendent: return 'P';
                case FriendStatusEnum.Accepted: return 'A';
                case FriendStatusEnum.Refused: return 'R';
                case FriendStatusEnum.Removed: return 'C';
                default: return 'P';
            }
        }

        public static FriendStatusEnum ToEnum(char charEnum)
        {
            switch (charEnum)
            {
                case 'P': return FriendStatusEnum.Pendent;
                case 'A': return FriendStatusEnum.Accepted;
                case 'R': return FriendStatusEnum.Refused;
                case 'C': return FriendStatusEnum.Removed;
                default: return FriendStatusEnum.Pendent;
            }
        }
    }
}
