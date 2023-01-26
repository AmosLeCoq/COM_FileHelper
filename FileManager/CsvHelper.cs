namespace InOutLib
{
    public class CsvHelper : FileHelper
    {
        #region private attributs
        //TODO Private attributs - 2pts
        private string _path;
        private string _fileName;
        private char _separaor;
        #endregion private attributs

        #region constructor
        public CsvHelper(string path, string fileName, char separator = ';') : base(path, fileName)
        {
            //TODO Constructor - 3pts
            _path = path;
            _fileName = fileName;
            _separaor = separator;   
        }
        #endregion constructor

        #region public methods 
        public void ExtractFileContent()
        {
            //TODO ExtractFileContent - 6pts
            StreamReader streamReader = new StreamReader(_fullPath);
            string line;
            // Reads and stores lines from the file until eof.
            
            while ((line = streamReader.ReadLine()) != null)
            {
                //if(line... )
                //throw new CsvHelper.CsvHelperException();
                this.Lines.Add(line);
            }
            streamReader.Close();
            
            if (this.Lines.Count == 0)
            {
                throw new EmptyFileException();
            }
        }
        #endregion public methods

        #region private methods
        private bool IsCharSupported(char separator)
        {
            //TODO IsCharSupported - 2pts
            if (separator==';')
            {
                return true;
            }
            throw new UnsupportedSeparatorException();
        }
        #endregion privates methods

        #region nested classes
        public class CsvHelperException : FileHelperException{}
        public class UnsupportedSeparatorException : CsvHelperException { }
        public class StructureException : CsvHelperException { }
        #endregion nested classes
    }
}
