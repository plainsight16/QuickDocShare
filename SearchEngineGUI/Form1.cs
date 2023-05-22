using DocRanker;
using DocRepresentation;

namespace SearchEngineGUI
{
    public partial class Form1 : Form
    {
        Dictionary<int, string> documentPathAndID;
        Dictionary<string, List<int>> mergedIndex;

        public Form1()
        {
            InitializeComponent();
            InitializeIndexer();
        }

        private void InitializeIndexer()
        {
            DocumentRepresentation docRep = LocalStorage.LoadObjectFromFile();
            documentPathAndID = docRep.documentPathAndID;
            mergedIndex = docRep.mergedIndex;
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            string query = TextBoxQuery.Text;

            Ranker ranker = new Ranker(mergedIndex);
            List<int> rankedDocuments = ranker.RankQuery(query);

            foreach (var item in rankedDocuments)
            {
                string path = documentPathAndID[item];
                string message = string.Format("Document Id: {0}, Path: {1}", item, path);
                MessageBox.Show(message);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}