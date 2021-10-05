using System.Collections.Generic;
using System.IO;

namespace MigrationsTool_Version_3
{
    internal class DatevRead
    {
        // String Array Namens Content mit Inhalt der CSV Datei
        private string[] _content;

        // internal damit Semi nicht darauf zugreifen kann, Filepath ist der Übergabeparameter
        internal void Read(string filePath)
        {
            /*  Liest die CSV Datein ein. 
                Eine Zeile ist ein String Element des Arrays */
            _content = File.ReadAllLines(filePath);
        }

        // Gibt als Rückgabewert eine List aus String Arrays zurück 
        internal List<string[]> GetVarList()
        {
            // Die zurückgegebene Strings werden in einer neuen Liste initialisiert.
            var tempList = new List<string[]>();

            /* Für jeden String im Array "content" unterteilt die Methode
             * den String nach dem Split Parameter ( Semicolon ) und speichert dieses als
             * neues Array und fügt es der tempListe hinzu.
             */
            foreach (var rows in _content) tempList.Add(rows.Split(';'));
            // Gibt die gefüllte tempList als Rückgabeparameter
            return tempList;
        }
    }
}