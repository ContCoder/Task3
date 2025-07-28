using System.Security.Cryptography;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Parameters;
using System.Web;
namespace Task3
{
    public static class SecureKeyGenerator
    {
        public static byte[] GenerateSecureKey(int length) //at least 256 bits (32 bytes)
        {
            if (length <= 0)
            {
                throw new ArgumentException("Length must be a positive integer.", nameof(length));
            }
            return RandomNumberGenerator.GetBytes(length);
        }

        public static int GenerateSecureRandomInt(int minValue, int maxValue)
        {
            return RandomNumberGenerator.GetInt32(minValue, maxValue);
        }

        public static string HmacSha3(byte[] secretkey, int message)
        {
            var hmac = new HMac(new Sha3Digest(256));
            hmac.Init(new KeyParameter(secretkey));
            byte[] messageBytes = BitConverter.GetBytes(message);
            hmac.BlockUpdate(messageBytes, 0, messageBytes.Length);
            byte[] result = new byte[hmac.GetMacSize()];
            hmac.DoFinal(result, 0);
            return Convert.ToHexString(result);
        }

    }
}