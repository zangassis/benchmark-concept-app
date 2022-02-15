using BenchmarkDotNet.Attributes;
using System.Security.Cryptography;

namespace BenchmarkConceptApp
{
    [RankColumn]
    [MemoryDiagnoser]
    public class CryptoComparison
    {
        private const int itemQuantity = 10000;
        private readonly byte[] data;

        private readonly SHA256 sha256 = SHA256.Create();
        private readonly MD5 md5 = MD5.Create();

        public CryptoComparison()
        {
            data = new byte[itemQuantity];
            new Random(42).NextBytes(data);
        }

        [Benchmark]
        public byte[] Sha256() => sha256.ComputeHash(data);

        [Benchmark]
        public byte[] Md5() => md5.ComputeHash(data);
    }
}