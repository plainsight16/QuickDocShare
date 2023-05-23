using DocRanker;
using DocRepresentation;

namespace SearchEngineGUI
{
    public partial class HomeForm : Form
    {
        Dictionary<int, string> documentPathAndID;
        Dictionary<string, List<Token>> mergedIndex;
        AutoCompleteStringCollection searchQueries = new AutoCompleteStringCollection();

        public HomeForm()
        {
            InitializeComponent();
            InitializeIndexer();
            InitializeTextFieldSearch();
        }

        private void InitializeIndexer()
        {
            DocumentRepresentation docRep = LocalStorage.LoadObjectFromFile();
            mergedIndex = docRep.mergedIndex;
        }

        private void InitializeTextFieldSearch()
        {
            TextBoxQuery.AutoCompleteMode = AutoCompleteMode.Suggest;
            TextBoxQuery.AutoCompleteSource = AutoCompleteSource.CustomSource;

            // Example queries
            searchQueries.Add("Previous Query 1");
            searchQueries.Add("Previous Query 2");
            searchQueries.Add("Previous Query 3");

            //  GET SAVED SEARCH QUERIES

            TextBoxQuery.AutoCompleteCustomSource = searchQueries;

        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            string query = TextBoxQuery.Text;

            Ranker ranker = new Ranker(mergedIndex);
            List<Token> rankedDocuments = ranker.RankQuery(query);

            searchQueries.Add(query);

            new ResultsForm(rankedDocuments).Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}