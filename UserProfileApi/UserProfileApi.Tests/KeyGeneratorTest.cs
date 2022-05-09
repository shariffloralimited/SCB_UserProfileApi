using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography;
using System.Diagnostics;

namespace UserProfileApi.Tests
{
    [TestClass]
    public class KeyGeneratorTest
    {
        [TestMethod]
        public void TestKeyGeneration()
        {
            var generatedKey = GenerateUniqueKey(32);
            Debug.WriteLine(generatedKey);
        }

        private string GenerateUniqueKey(int keyLength)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var bit_count = (keyLength * 6);
                var byte_count = ((bit_count + 7) / 8); // rounded up
                var bytes = new byte[byte_count];
                rng.GetBytes(bytes);
                return Convert.ToBase64String(bytes);
            }
        }
    }
}
