using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Chapter2
{

    /// The .net Framework offers a special class that can help to minimize 
    /// the surface area an attacker has: System.Security.SecureString
    /// 
    /// A SecureString automatically encrypts its value so the possibility
    /// of an attacker finding a plain text version of your string is decreased.
    /// 
    /// A SecureString is also pinned to a specific memory location.
    /// 
    /// The garbage collector doesn't move the string around so you avoid
    /// the problem of having multiple copies.
    /// SecureString is a mutable string that can be made read-only when
    /// necessary.
    /// 
    /// SecureString implements IDispossable so you can make sure that its
    /// content is removed from memory whenever you're done with it.
    /// 
    /// Because SecureString needs to be initialized at some point, the data
    /// that is used to initialize it is still in memory. To minimize the risk
    /// SecureSTring can deal with only individual characters at a time. 
    /// It's not possible to pass a string directly to a SecureString.
    public static class SecureStringData
    {
        public static void Start()
        {
            using (SecureString secureString = new SecureString())
            {
                Console.Write("Please enter password: ");

                while (true)
                {
                    ConsoleKeyInfo cki = Console.ReadKey(true);

                    if (cki.Key == ConsoleKey.Enter)
                    {
                        break;
                    }

                    secureString.AppendChar(cki.KeyChar);

                    Console.Write("*");
                }

                Console.WriteLine();

                secureString.MakeReadOnly();

                ConvertToUnsecureString(secureString);
            }
        }

        // Convert the SecureString back to a normal string.
        // It's important to make sure that the regular string is cleared from memory
        // as soon as possible. This is why there is a try/finally statement
        // around the code. The finally statement makes sure that the string
        // is removed from memory even if there is an exception thrown in the code.
        private static void ConvertToUnsecureString(SecureString secureString)
        {
            IntPtr unmanagedString = IntPtr.Zero;

            try
            {
                Console.Write("Your password is: ");
                // The Marshall clss is located in the System.Runtime.InteropServices namespace.
                // It offers five methods that can be used when decrypting a SecureString.
                // Those methods accept a SecureString and return a IntPtr.
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);

                Console.WriteLine(Marshal.PtrToStringUni(unmanagedString));
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}