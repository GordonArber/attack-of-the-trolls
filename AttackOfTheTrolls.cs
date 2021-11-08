using System;

public enum AccountType
{
    Guest,
    User,
    Moderator
}
[Flags]
public enum Permission
{
    None = 0,
    Read = 1,
    Write = 2,
    Delete = 4,
    All = Delete | Read | Write
}

static class Permissions
{
    static Permission guestPermissions = Permission.Read;
    public static Permission Default(AccountType accountType)
    {
        switch (accountType)
        {
            case AccountType.Guest:
                return guestPermissions;
            case AccountType.User:
                return (Permission.Read | Permission.Write);
            case AccountType.Moderator:
                return Permission.All;
            default:
                return Permission.None;
        }
    }

    public static Permission Grant(Permission current, Permission grant)
    {
        return current | grant;
    }

    public static Permission Revoke(Permission current, Permission revoke)
    {
        return current & ~revoke;
    }

    public static bool Check(Permission current, Permission check)
    {
        return (current & check) == check;
    }
}
