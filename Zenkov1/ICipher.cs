using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zenkov1
{
    public interface ICipher
    {
        string Encrypting(string text, object key);
        string Decrypting(string cipher, object key);
        (string text, string cipherKey) Breaking(string cipher);
    }
}
