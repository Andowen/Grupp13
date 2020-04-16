using System;


namespace WebApplicationGrupp13.Enums
{
    [Flags]
    public enum NotificationType
    {
        None = 0,
        Formal = 1,
        Informal = 2,
        Education = 4,
        Research = 8,
        Calender = 16
    }
}