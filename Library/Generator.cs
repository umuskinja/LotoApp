using System;
using System.Security.Cryptography;

namespace Library
{
    public class Generator
    {
        public static int GenerateRandom(int cap)
        {
            if (cap < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(cap), "cap must be non-negative");
            }

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] randomNumber = new byte[4];
                rng.GetBytes(randomNumber);

                int randomInt = BitConverter.ToInt32(randomNumber, 0) & int.MaxValue;

                // Ensuring the distribution is uniform by reducing bias
                int range = cap + 1;
                int max = int.MaxValue - (int.MaxValue % range);

                while (randomInt >= max)
                {
                    rng.GetBytes(randomNumber);
                    randomInt = BitConverter.ToInt32(randomNumber, 0) & int.MaxValue;
                }

                return randomInt % range + 1;
            }
        }
    }
}