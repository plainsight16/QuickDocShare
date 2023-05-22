using DocRanker;
using DocRepresentation;

namespace SearchEngineGUI
{
    public partial class HomeForm : Form
    {
        Dictionary<int, string> documentPathAndID;
        Dictionary<string, List<int>> mergedIndex;

        public HomeForm()
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

            new ResultsForm(rankedDocuments, documentPathAndID).Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}