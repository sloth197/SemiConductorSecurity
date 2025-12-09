using SemiconSecuirty.Core.Models;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SemiconSecuirty.Core.Security
{
    public class FileiIntegrityChecker
    {
        private string _lastHash = "";
        public List<SecurityEvent> CheckFile(string path)
        {
            var result = new List<SecurityEvent>();
            if (!File.Exists(path))
            {
                return result;
            }
            string hash = ComputeHash(File.ReadAllBytes(path));

            if (_lastHash != "" && hash != _lastHash)
            {
                result.Add(new SecurityEvent
                {
                    Timestamp = DateTime.Now,
                    Type = "FileChange",
                    Message = $"Recipe file changed: {path}",
                    Severity = "Critical"
                });
            }
            _lastHAsh = hash;
            return result;
        }
        private string ComputeHash(byte[] bytes)
        {
            using var sha = SHA256.Create();
            return Convert.ToHexString(sha.ComputeHash(bytes));
        }
    }
}