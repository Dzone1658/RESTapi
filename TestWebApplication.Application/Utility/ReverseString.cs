using System;

namespace TestWebApplication.Application.Utility
{
    public static class ReverseString
    {
        public static string ReverseCharacters(string str)
        {
            char[ ] array = str.ToCharArray( );
            Array.Reverse( array );
            return new string( array );
        }
    }
}
