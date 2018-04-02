using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace Xml
{
    public class SafeXmlDocument : XmlDocument
    {
        public override void Load(string filename)
        {
            ThrowIfFileNameInvalid(filename);
            if (!File.Exists(filename)) throw new FileNotFoundException();
            var tempFilePath = Path.GetTempFileName();
            File.Copy(filename, tempFilePath, true);
            base.Load(tempFilePath);
            File.Delete(tempFilePath);
        }
        public override void Save(string filename)
        {
            ThrowIfFileNameInvalid(filename);
            var tempFilePath = Path.GetTempFileName();
            base.Save(tempFilePath);
            File.Copy(tempFilePath, filename, true);
            File.Delete(tempFilePath);
        }
        private void ThrowIfFileNameInvalid(string filename)
        {
            if (filename == null) throw new ArgumentNullException("文件名为空");
            if (filename.Length == 0) throw new ArgumentException("文件名为空");
            var invalidChars = Path.GetInvalidPathChars();
            foreach (var target in Path.GetFileName(filename))
            {
                foreach (var sample in invalidChars)
                {
                    if (target == sample)
                    {
                        throw new ArgumentException(string.Format("文件名中不允许包含{0}", sample));
                    }
                }
            }
        }
    }
}
