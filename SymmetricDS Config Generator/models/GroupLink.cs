using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricDS_Config_Generator.models
{
    public class GroupLink
    {
        public string SourceNodeGroup { get; set; }
        public string TargetNodeGroup { get; set; }
        public enum Action
        {
            P,
            W
        }
        public Action DataEventAction { get; set; }
        public string Hash
        {
            get
            {
                using (var sha = new SHA512Managed())
                {
                    var input = UTF8Encoding.UTF8.GetBytes(SourceNodeGroup + TargetNodeGroup);
                    return Convert.ToBase64String(sha.ComputeHash(input));
                }
            }
        }
    }
}
