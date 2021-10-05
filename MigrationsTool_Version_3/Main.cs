using System.Collections.Generic;

namespace MigrationsTool_Version_3
{
    public class Main
    {
        private string csvPath;
        private List<string[]> varList;
        private string xmlPath;

        public void SetCsvPath(string path)
        {
            csvPath = path;
        }

        public void SetXmlPath(string path)
        {
            xmlPath = path;
        }

        public void Read()
        {
            var dr = new DatevRead();
            dr.Read(csvPath);
            varList = dr.GetVarList();
        }

        public void Write()
        {
            XRechnung xr = new XRechnung();
            xr.MakeXml(xmlPath, varList);
        }
    }
}